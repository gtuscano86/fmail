//Gabriella Tuscano
//Login Page
//Email System

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EmailClassLibrary;
using System.Data;
using System.Data.SqlClient;

namespace Project3
{
    public partial class EmailLogin : System.Web.UI.Page
    {
        DBConnect dBConnect = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        //generates user table
        protected void Page_Load(object sender, EventArgs e)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "SelectFromUsers";

            DataSet myData = dBConnect.GetDataSet("SelectFromUsers");
            DataTable userData = myData.Tables[0];

        }

        //uses validation to sign in user
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DataSet myData = dBConnect.GetDataSet("SelectFromUsers");
            DataTable userData = myData.Tables[0];
            String username = txtUsername.Text + "@fmail.com";

            Session["username"] = txtUsername.Text;
            Session["password"] = txtPassword.Text;

            if (InputValidation() == false)
            {
                Response.Write("One or more values not entered.");
            }
            else  
            {
                for (int i = 0; i < userData.Rows.Count; i++)
                {

                    DataRow userDataRow = userData.Rows[i];
                    if (username == userDataRow["NewEmail"].ToString() && txtPassword.Text == userDataRow["Password"].ToString())
                    {
                        if (userDataRow["Active"].ToString() == "False")
                        {
                            Response.Write("Your account has been banned.");
                        }
                        else if (userDataRow["Type"].ToString() == "Standard User")
                        {
                            Server.Transfer("InboxPage.aspx");
                        }
                        if (userDataRow["Type"].ToString() == "Administrator")
                        {
                            Server.Transfer("AdminView.aspx");
                        }
                    }
                }
            }

        } 

        //makes sure both username and password are entered
        public bool InputValidation()
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                return false;
            }
            else
                return true;
        }

        //takes user to create new account page
        protected void btnNewAccount_Click(object sender, EventArgs e)
        {
            Server.Transfer("NewAccountPage.aspx");
        }
    }
}