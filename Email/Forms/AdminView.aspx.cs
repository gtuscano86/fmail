//Gabriella Tuscano
//Admin Page
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
    public partial class AdminView : System.Web.UI.Page
    {
        DBConnect dBConnect = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        //generates user table and flag table
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "SelectFromUsers";

                DataSet myData = dBConnect.GetDataSet("SelectFromUsers");
                gvUsers.DataSource = myData;
                gvUsers.DataBind();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetFlags";

                DataSet myData2 = dBConnect.GetDataSet("GetFlags");
                gvFlags.DataSource = myData2;
                gvFlags.DataBind();

                String username = Request["txtUsername"].ToString() + "@fmail.com";
                lblWelcome.Text = "Welcome, " + username + "!";
            }
        }

        //displays user table
        protected void btnUsers_Click(object sender, EventArgs e)
        {
            gvUsers.Visible = true;
            gvFlags.Visible = false;
            btnBan.Visible = true;
            btnUnBan.Visible = true;
        }

        //displays flag table
        protected void btnFlags_Click(object sender, EventArgs e)
        {
            gvUsers.Visible = false;
            gvFlags.Visible = true;
            btnBan.Visible = false;
            btnUnBan.Visible = false;
        }

        //hides both tables
        protected void btnClear_Click(object sender, EventArgs e)
        {
            gvUsers.Visible = false;
            gvFlags.Visible = false;
            btnBan.Visible = false;
            btnUnBan.Visible = false;
        }

        //bans selected user
        protected void btnBan_Click(object sender, EventArgs e)
        {
            for (int row = 0; row < gvUsers.Rows.Count; row++)
            {
                CheckBox checkBox;
                checkBox = (CheckBox)gvUsers.Rows[row].FindControl("chkBan");

                if (checkBox.Checked)
                {

                    Response.Write("Account Banned");

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "Ban";

                    objCommand.Parameters.AddWithValue("@ID", gvUsers.Rows[row].Cells[1].Text);
                    objCommand.Parameters.AddWithValue("@Name", gvUsers.Rows[row].Cells[2].Text);

                    dBConnect.DoUpdateUsingCmdObj(objCommand);
                }

            }

            DataSet myData = dBConnect.GetDataSet("SelectFromUsers");
            gvUsers.DataSource = myData;
            gvUsers.DataBind();
        }

        //unbans selected user
        protected void btnUnBan_Click(object sender, EventArgs e)
        {

            for (int row = 0; row < gvUsers.Rows.Count; row++)
            {
                CheckBox checkBox;
                checkBox = (CheckBox)gvUsers.Rows[row].FindControl("chkBan");

                if (checkBox.Checked)
                {

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "Unban";

                    objCommand.Parameters.AddWithValue("@ID", gvUsers.Rows[row].Cells[1].Text);
                    objCommand.Parameters.AddWithValue("@Name", gvUsers.Rows[row].Cells[2].Text);

                    dBConnect.DoUpdateUsingCmdObj(objCommand);

                    Response.Write("Account Unbanned");
                }

            }

            DataSet myData = dBConnect.GetDataSet("SelectFromUsers");
            gvUsers.DataSource = myData;
            gvUsers.DataBind();

        }

        //takes user back to login page
        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmailLogin.aspx");
        }
    }
}