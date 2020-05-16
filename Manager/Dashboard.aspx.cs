using System;
using Qup.Business.Transactions.Models;
using Qup.Business.Transactions;
using System.Collections.Generic;

namespace Qup.Manager
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected ManagerDashboardViewModel ManagerDasboardData = new ManagerDashboardViewModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetCustomerData();
            }

            if (Request["deleteId"] != null )
            {
                SaveCustomerExitTime(Request["deleteId"]);
            }

            Response.AddHeader("Refresh", "30");
        }

        protected void saveSubmit_Click(object sender, EventArgs e)
        {
            // ValidateData()
            var clientName = name.Value.Trim();
            var clientEmail = email.Value.Trim();
            var clientPhone = mobile.Value.Trim();

            var registerNewUser = new UserRegistration()
            {
                Name = clientName,
                Email = clientEmail,
                Phone = clientPhone
            };

            var userRegistrationHandler = new UserLedger();
            userRegistrationHandler.RegisterCustomerInQueue(registerNewUser);

            SetCustomerData();
        }

        private void SaveCustomerExitTime(string queueId)
        {
            int id = Convert.ToInt32(queueId);
            var queueHandler = new QueueLedger();
            queueHandler.SaveCustomerQueueExit(id);
            SetCustomerData();
        }
        private void SetCustomerData()
        {
            // Get Customers in Queue
            var queueHandler = new QueueLedger();
            var fromDate = DateTime.Now.Date;
            var toDate = DateTime.Now.Date.AddDays(1);
            int businessId = 1;
            ManagerDasboardData.Customers = queueHandler.GetCustomersInQueue(businessId, fromDate, toDate);

            foreach (var item in ManagerDasboardData.Customers)
            {
                if (item.QueueExitTime != null)
                {
                    ManagerDasboardData.CustomersServedToday += 1;
                }
                else 
                {
                    ManagerDasboardData.CustomersAtPresent += 1;
                }
                ManagerDasboardData.Capacity = item.Capacity;
            }

            name.Value = string.Empty;
            email.Value = string.Empty;
            mobile.Value = string.Empty;
        }
    }    

    public class ManagerDashboardViewModel
    {
        public IEnumerable<CustomerInQueue> Customers { get; set; }

        public int CustomersServedToday { get; set; }

        public int CustomersAtPresent { get; set; }

        public int Capacity { get; set; }
    }
}