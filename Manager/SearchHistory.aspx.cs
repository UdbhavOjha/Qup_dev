using System;
using System.Collections.Generic;
using Qup.Business.Transactions;
using Qup.Business.Transactions.Models;

namespace Qup.Manager
{
    public partial class SearchHistory : System.Web.UI.Page
    {
        protected IEnumerable<CustomerInQueue> customerSearchResults;

        protected DateTime fromDateConverted;

        protected DateTime toDateConverted;

        protected bool noResults = true;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void searchSubmit_Click(object sender, EventArgs e)
        {
            var fromDateSelected = fromDate.Value;
            var toDateSelected = toDate.Value;
            int businessId = 1;

            var fromDateConvertTest = DateTime.TryParse(fromDateSelected.Trim(), out DateTime fromDateConverted);
            var toDateConvertTest = DateTime.TryParse(toDateSelected.Trim(), out DateTime toDateConverted);

            // Put Validation
            if (fromDateConvertTest && toDateConvertTest)
            {
                var queueHandler = new QueueLedger();
                customerSearchResults = queueHandler.GetCustomersInQueue(businessId, fromDateConverted, toDateConverted);

                foreach (var item in customerSearchResults)
                {
                    noResults = false;
                    break;
                }
            }
            

            
        }
    }
}