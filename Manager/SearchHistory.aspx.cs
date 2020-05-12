using System;
using System.Collections.Generic;
using Qup.Business.Transactions;
using Qup.Business.Transactions.Models;

namespace Qup.Manager
{
    public partial class SearchHistory : System.Web.UI.Page
    {
        protected IEnumerable<CustomerInQueue> customerSearchResults;

        protected bool noResults = true;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void searchSubmit_Click(object sender, EventArgs e)
        {
            var fromDateSelected = fromDate.Value;
            var toDateSelected = toDate.Value;
            int businessId = 1;

            // Put Validation

            var queueHandler = new QueueLedger();
            customerSearchResults = queueHandler.GetCustomersInQueue(businessId, Convert.ToDateTime(fromDateSelected).Date, Convert.ToDateTime(toDateSelected).Date);

            foreach (var item in customerSearchResults)
            {
                noResults = false;
                break;
            }
        }
    }
}