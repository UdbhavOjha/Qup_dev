﻿using Qup.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Qup.Admins
{
    public partial class ViewBusinessProfile : WebPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AuthenticateUser();
        }
    }
}