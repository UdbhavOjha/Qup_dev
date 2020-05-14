using System;
using Qup.Business.AccountsManagement.Models;
using Qup.Business.AccountsManagement;
using Qup.Business.Transactions;
using Qup.Business.Transactions.Models;

namespace Qup.Clients
{
    public partial class JoinQueue : System.Web.UI.Page
    {
        protected BusinessDetails BusinessConfig = new BusinessDetails();

        protected bool disableJoinQueueButton;

        protected bool enableLeaveQueueButton;

        protected string UserMessage;
        protected void Page_Load(object sender, EventArgs e)
        {
            var businessId = Request.QueryString["profile"];

            if (businessId != null && int.TryParse(businessId, out int queueBusinessId))
            {
                var searchQueryHandler = new SearchHandler();
                BusinessConfig = searchQueryHandler.GetBusinessDetailsByBusinessId(queueBusinessId);
            }
            else
            {
                Response.Redirect("/Errors/404.aspx");
            }
        }

        protected void joinQueue_Click(object sender, EventArgs e)
        {
            var bizId = Request["businessId"];

            var validSubmit = int.TryParse(bizId, out int id);

            // Get Patron Id
            var sessionId = Request.Cookies["SessionInfo"].Value;

            var userSearchHandler = new SearchHandler();
            var patronId = userSearchHandler.GetPatronIdBySessionId(sessionId);

            if (validSubmit)
            {
                var queueHandler = new QueueLedger();
                queueHandler.AddCustomerToQueue(new QueueInstruction()
                {
                    BusinessId = id,
                    QueueJoinTime = DateTime.Now,
                    ExpectedEntryTime = DateTime.Now,
                    ActualEntryTime = DateTime.Now,
                    PatronId = patronId
                });

                disableJoinQueueButton = true;
                enableLeaveQueueButton = true;
                UserMessage = "Please click Leave button before leaving our premises.";
            }
            
        }

        protected void leaveQueue_Click(object sender, EventArgs e)
        {
            var bizId = Request["businessId"];

            var validSubmit = int.TryParse(bizId, out int id);

            // Get Patron Id
            var userSession = Request.Cookies["SessionInfo"].Value;

            if (validSubmit)
            {
                var queueHandler = new QueueLedger();
                queueHandler.LeaveQueue(new QueueInstruction()
                {
                    BusinessId = id,
                    SessionId = userSession
                });

                disableJoinQueueButton = true;
                enableLeaveQueueButton = false;

                UserMessage = "Thanks for your visit.";
            }
        }
    }
}