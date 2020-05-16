using Qup.Database;
using System;
using System.Linq;
using System.Web;

namespace Qup.Security
{
    public class WebPage : System.Web.UI.Page
    {
        public int UserId { get; set; }

        public int BusinessId { get; set; }

        public string UserGroupOfUser { get; set; }

        public void AuthenticateUser()
        {
            string sessionId = Request.Cookies.Get("SessionInfo").Value != null ? Request.Cookies.Get("SessionInfo")?.Value : string.Empty;            

            try
            {
                if (sessionId != string.Empty)
                {
                    // verify session id from DB 
                    using (var context = new QupEntities())
                    {
                        var userSessionDetails = context.Users.First(u => u.SessionKey == sessionId);

                        // session time of 30 minutes Max
                        if (userSessionDetails != null && userSessionDetails.LastLogged >= DateTime.Now.AddMinutes(-60) && userSessionDetails.LastLogged <= DateTime.Now.AddMinutes(60))
                        {
                            if (IsRequestedPagePermissionedToUser(userSessionDetails.Id, Request.RawUrl))
                            {
                                // update DateLastLogged to 60 minutes from now for session expiry
                                userSessionDetails.LastLogged = DateTime.Now;
                                context.SaveChanges();

                                UserId = userSessionDetails.Id;

                                // Set Business Permissions 
                                var userGroupOfUser = context.UsersToUserGroups.First(u => u.UserId == UserId);
                                // clean the below later
                                switch (userGroupOfUser.UserGroupId)
                                {
                                    case 3:
                                        UserGroupOfUser = "AdminSupport";
                                        break;

                                    case 2:
                                        UserGroupOfUser = "Manager";
                                        var userBusiness = context.BusinessAccountSecurities.First(u => u.UserId == UserId);
                                        if (userBusiness != null && userBusiness.BusinessId.HasValue)
                                        {
                                            BusinessId = Convert.ToInt16(userBusiness.BusinessId);
                                        }
                                        else
                                        {
                                            // user not registered
                                            DeleteSession();
                                            Response.Redirect("/Errors/GenericError.aspx");
                                        }
                                        break;

                                    default:
                                        // user not registered
                                        DeleteSession();
                                        Response.Redirect("/Errors/GenericError.aspx");
                                        break;
                                }                                
                            }
                            else
                            {
                                // Expire Session 
                                userSessionDetails.SessionKey = string.Empty;
                                userSessionDetails.LastLogged = DateTime.Now.AddMinutes(-60);
                                context.SaveChanges();

                                DeleteSession();
                                Response.Redirect("/Errors/GenericError.aspx");
                            }
                        }
                    }
                }
                else
                {
                    DeleteSession();
                    Response.Redirect("/Errors/GenericError.aspx");
                }
            }
            catch
            {
                DeleteSession();
                Response.Redirect("/Errors/GenericError.aspx");
            }

        }

        private void DeleteSession()
        {
            HttpCookie sessionCookie = new HttpCookie("SessionInfo");
            sessionCookie["Session"] = string.Empty;
            Response.Cookies.Set(sessionCookie);
        }

        public void LogOutUser()
        {
            string sessionId = Request.Cookies.Get("SessionInfo")?.Value != null ? Request.Cookies.Get("SessionInfo")?.Value.Remove(0, 8) : string.Empty;
            // Session Id is stored in the cookie like "Session=" - so 8 characters need to be removed

            if (sessionId != string.Empty)
            {
                // verify session id from DB 
                using (var context = new QupEntities())
                {
                    var userSessionDetails = context.Users.First(u => u.SessionKey == sessionId);

                    // session time of 30 minutes Max
                    if (userSessionDetails != null)
                    {
                        // update DateLastLogged to 30 minutes from now for session expiry
                        userSessionDetails.SessionKey = string.Empty;
                        userSessionDetails.LastLogged = DateTime.Now.AddMinutes(-60);
                        context.SaveChanges();
                    }
                }
            }
            else
            {
                Response.Redirect("/Errors/GenericError.aspx");
            }

            HttpCookie sessionCookie = new HttpCookie("SessionInfo");
            sessionCookie["Session"] = string.Empty;
            Response.Cookies.Set(sessionCookie);
        }

        public bool IsRequestedPagePermissionedToUser(int? userId, string pageUrl)
        {
            // Remove query string if any from the url before checking
            var queryStringFreeUrl = pageUrl.Contains('?') ? pageUrl.Split('?')[0] : pageUrl;

            var context = new QupEntities();
            var pageAccessible = from c in context.vwUserPagePermissions
                                 where c.UserId == userId && c.Url == queryStringFreeUrl
                                 select c;

            if (pageAccessible.Any())
            {
                return true;
            }

            return false;
        }

        public int? GetUserIdFromSessionId(string sessionId)
        {
            using (var context = new QupEntities())
            {
                var userSessionDetails = context.Users.First(u => u.SessionKey == sessionId);
                return userSessionDetails.Id;
            }
        }
    }
}