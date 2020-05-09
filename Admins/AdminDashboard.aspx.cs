using System;
using Qup.Business.AccountsManagement.Models;
using System.Collections.Generic;
using Qup.Business.AccountsManagement;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Qup.Admins
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected IEnumerable<UserDetails> userSearchResults = new List<UserDetails>();
        protected int searchResultsCount = -1; 
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
                userSearchResults = searchHandler.GetUsersByUserGroupsAndName(searchUserTypeSelected);
                searchResultsCount = userSearchResults.Count();
            }
        }
    }
}