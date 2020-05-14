using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Qup.Security
{
    public class WebPage : System.Web.UI.Page
    {
        public int? UserId { get; set; }

        //public void AuthenticateUser()
        //{
        //    string sessionId = Request.Cookies.Get("SessionInfo")?.Value != null ? Request.Cookies.Get("SessionInfo")?.Value.Remove(0, 8) : string.Empty;
        //    // Session Id is stored in the cookie like "Session=" - so 8 characters need to be removed

        //    try
        //    {
        //        if (sessionId != string.Empty)
        //        {
        //            // verify session id from DB 
        //            using (var context = new ZeroDbContext())
        //            {
        //                var userSessionDetails = context.UserCredentials.First(u => u.SessionKey == sessionId);

        //                // session time of 30 minutes Max
        //                if (userSessionDetails != null && userSessionDetails.DateLastLogged >= DateTime.Now.AddMinutes(-30) && userSessionDetails.DateLastLogged <= DateTime.Now.AddMinutes(30))
        //                {
        //                    if (userSessionDetails.Active == true && IsRequestedPagePermissionedToUser(userSessionDetails.UserId, Request.RawUrl))
        //                    {
        //                        // update DateLastLogged to 30 minutes from now for session expiry
        //                        userSessionDetails.DateLastLogged = DateTime.Now;
        //                        context.SaveChanges();

        //                        UserId = userSessionDetails.UserId;
        //                    }
        //                    else
        //                    {
        //                        // Expire Session 
        //                        userSessionDetails.SessionKey = string.Empty;
        //                        userSessionDetails.DateLastLogged = DateTime.Now.AddMinutes(-60);
        //                        context.SaveChanges();

        //                        DeleteSession();
        //                        Response.Redirect("/AccessDenied.aspx");
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            DeleteSession();
        //            Response.Redirect("/AccessDenied.aspx");
        //        }
        //    }
        //    catch
        //    {
        //        DeleteSession();
        //        Response.Redirect("/AccessDenied.aspx");
        //    }

        //}

        //private void DeleteSession()
        //{
        //    HttpCookie sessionCookie = new HttpCookie("SessionInfo");
        //    sessionCookie["Session"] = string.Empty;
        //    Response.Cookies.Set(sessionCookie);
        //}

        //public void LogOutUser()
        //{
        //    string sessionId = Request.Cookies.Get("SessionInfo")?.Value != null ? Request.Cookies.Get("SessionInfo")?.Value.Remove(0, 8) : string.Empty;
        //    // Session Id is stored in the cookie like "Session=" - so 8 characters need to be removed

        //    if (sessionId != string.Empty)
        //    {
        //        // verify session id from DB 
        //        using (var context = new ZeroDbContext())
        //        {
        //            var userSessionDetails = context.UserCredentials.First(u => u.SessionKey == sessionId);

        //            // session time of 30 minutes Max
        //            if (userSessionDetails != null)
        //            {
        //                // update DateLastLogged to 30 minutes from now for session expiry
        //                userSessionDetails.SessionKey = string.Empty;
        //                userSessionDetails.DateLastLogged = DateTime.Now.AddMinutes(-60);
        //                context.SaveChanges();
        //            }
        //        }
        //    }
        //    else
        //    {
        //        Response.Redirect("/AccessDenied.aspx");
        //    }

        //    HttpCookie sessionCookie = new HttpCookie("SessionInfo");
        //    sessionCookie["Session"] = string.Empty;
        //    Response.Cookies.Set(sessionCookie);
        //}

        //public bool IsRequestedPagePermissionedToUser(int? userId, string pageUrl)
        //{
        //    var context = new ZeroDbContext();
        //    var pageAccessible = from c in context.vwUserPagePermissions
        //                         where c.UserId == userId && c.PageUrl == pageUrl
        //                         select c;

        //    if (pageAccessible.Any())
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        //public int? GetUserIdFromSessionId(string sessionId)
        //{
        //    using (var context = new ZeroDbContext())
        //    {
        //        var userSessionDetails = context.UserCredentials.First(u => u.SessionKey == sessionId);
        //        return userSessionDetails.UserId;
        //    }
        //}
    }
}