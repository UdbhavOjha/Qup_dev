using System;
using System.Collections.Generic;
using System.Globalization;
using Qup.Business.Transactions;
using Qup.Business.Transactions.Models;
using Qup.Security;

namespace Qup.Manager
{
    public partial class SearchHistory : WebPage
    {
        protected IEnumerable<CustomerInQueue> customerSearchResults;

        protected string fromDateSearched;

        protected string toDateSearched;

        protected bool noResults = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            AuthenticateUser();
        }

        protected void searchSubmit_Click(object sender, EventArgs e)
        {
            var fromDateSelected = Request.Form["fromDate"];
            var toDateSelected = Request.Form["toDate"];
            int businessId = BusinessId;

            var fromDateParsed = ParseSelectedDate(fromDateSelected.Trim());
            var toDateParsed = ParseSelectedDate(toDateSelected.Trim());

            // Put Validation
            if (fromDateParsed != DateTime.MinValue && toDateParsed != DateTime.MinValue)
            {
                var queueHandler = new QueueLedger();
                customerSearchResults = queueHandler.GetCustomersInQueue(businessId, fromDateParsed, toDateParsed);

                foreach (var item in customerSearchResults)
                {
                    noResults = false;
                    break;
                }

                fromDateSearched = fromDateSelected;
                toDateSearched = toDateSelected;
            }            
        }

        private DateTime ParseSelectedDate(string searchDate)
        {
            DateTime parsedDate;
            DateTime.TryParseExact(
                                   searchDate,
                                   "dd/MM/yyyy",
                                   CultureInfo.InvariantCulture,
                                   DateTimeStyles.None,
                                   out parsedDate
                                  );
            return parsedDate;
        }
    }
}