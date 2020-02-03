//Gabriella Tuscano
//Created Account Page
//Email System

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project3
{
    public partial class AccountCreated : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //takes user back to login page
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmailLogin.aspx");
        }
    }
}