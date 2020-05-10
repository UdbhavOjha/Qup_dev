using System;
using Qup.Business.AccountsManagement.Models;
using System.Collections.Generic;
using Qup.Business.AccountsManagement;
using System.Linq;

namespace Qup.Admins
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected IEnumerable<UserDetails> userSearchResults = new List<UserDetails>();
        protected IEnumerable<BusinessDetails> businessSearchResults = new List<BusinessDetails>();
        protected int searchResultsCount = -1;
        protected bool userSearched;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void searchSubmit_Click(object sender, EventArgs e)
        {
            var searchTypeSelected = searchType.Value;
            var searchUserTypeSelected = userType.Value;
            var searchHandler = new SearchHandler();
            if (searchTypeSelected == "User")
            {
                userSearchResults = searchHandler.GetUsersByUserGroups(searchUserTypeSelected);
                searchResultsCount = userSearchResults.Count();
                userSearched = true;
            }
            else if (searchTypeSelected == "Business")
            {
                businessSearchResults = searchHandler.GetBusinesses();
                searchResultsCount = businessSearchResults.Count();
            }
        }
    }
}