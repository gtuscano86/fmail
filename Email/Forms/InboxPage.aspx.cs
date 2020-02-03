//Gabriella Tuscano
//Inbox Page
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
    public partial class InboxPage : System.Web.UI.Page
    {
        DBConnect dBConnect = new DBConnect();
        ClassEmail email = new ClassEmail();
        SqlCommand objCommand = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Generates inbox
            if (!IsPostBack)
            {

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "Login";

                String username = Session["username"].ToString() + "@fmail.com";
                String password = Session["password"].ToString();

                objCommand.Parameters.Clear();
                objCommand.Parameters.AddWithValue("@username", username);
                objCommand.Parameters.AddWithValue("@password", password);

                lblWelcome.Text = "Welcome, " + username + "!";

                DataSet myUserData; 
                myUserData = dBConnect.GetDataSetUsingCmdObj(objCommand);
                gvImage.DataSource = myUserData;
                gvImage.DataBind();


                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetInbox";

                objCommand.Parameters.Clear();
                objCommand.Parameters.AddWithValue("@username", username);
                objCommand.Parameters.AddWithValue("@emailTag", "Inbox");

                DataSet myData; 
                myData = dBConnect.GetDataSetUsingCmdObj(objCommand);
                gvEmail.DataSource = myData;
                gvEmail.DataBind();

                lblFolder.Text = "Main Inbox";

            }
        }

        //When create new email is clicked
        protected void btnCreateEmail_Click(object sender, EventArgs e)
        {
            gvEmail.Visible = false;
            btnCreateEmail.Visible = false;
            lblWelcome.Visible = false;
            btnSend.Visible = true;
            lblFrom.Visible = true;
            lblTo.Visible = true;
            lblContent.Visible = true;
            txtFrom.Visible = true;
            txtTo.Visible = true;
            txtBody.Visible = true;
            btnBack.Visible = true;
            lblSubject.Visible = true;
            txtSubject.Visible = true;
            btnInbox.Visible = false;
            btnSent.Visible = false;
            btnTrash.Visible = false;
            btnJunk.Visible = false;
            btnDelete.Visible = false;
            btnSearch.Visible = false;
            txtSearch.Visible = false;
            lblFolder.Visible = false;
            btnFlag.Visible = false;
            lblFromExtension.Visible = true;
            lblToExtension.Visible = true;
            btnRead.Visible = false;
        }

        //takes user back to their inbox
        protected void btnBack_Click(object sender, EventArgs e)
        {
            gvEmail.Visible = true;
            btnCreateEmail.Visible = true;
            lblWelcome.Visible = true;
            btnSend.Visible = false;
            lblFrom.Visible = false;
            lblTo.Visible = false;
            lblContent.Visible = false;
            txtFrom.Visible = false;
            txtTo.Visible = false;
            txtBody.Visible = false;
            txtFrom.Text = "";
            txtTo.Text = "";
            txtBody.Text = "";
            txtSubject.Text = "";
            txtFrom.Enabled = true;
            txtTo.Enabled = true;
            txtSubject.Enabled = true;
            txtBody.Enabled = true;
            btnBack.Visible = false;
            lblSubject.Visible = false;
            txtSubject.Visible = false;
            btnInbox.Visible = true;
            btnSent.Visible = true;
            btnTrash.Visible = true;
            btnJunk.Visible = true;
            btnDelete.Visible = true;
            btnSearch.Visible = true;
            txtSearch.Visible = true;
            lblFolder.Visible = true;
            btnFlag.Visible = true;
            lblEmailSent.Visible = false;
            btnRead.Visible = true;
            lblFromExtension.Visible = false;
            lblToExtension.Visible = false;
        }

        //sends email
        protected void btnSend_Click(object sender, EventArgs e)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateEmailDatabase";

            objCommand.Parameters.AddWithValue("@SenderId", txtFrom.Text + "@fmail.com");
            objCommand.Parameters.AddWithValue("@RecieverId", txtTo.Text + "@fmail.com");
            objCommand.Parameters.AddWithValue("@Subject", txtSubject.Text);
            objCommand.Parameters.AddWithValue("@EmailBody", txtBody.Text);
            objCommand.Parameters.AddWithValue("@CreatedTime", DateTime.Now);
            objCommand.Parameters.AddWithValue("@EmailTag", "Inbox");

            dBConnect.DoUpdateUsingCmdObj(objCommand);

            String senderID = txtFrom.Text + "@fmail.com";
            String receiverID = txtTo.Text + "@fmail.com";
            String subject = txtSubject.Text;
            String content = txtBody.Text;
            DateTime createdTime = DateTime.Now;
            String tag = "Inbox";

            email.Sender = senderID;
            email.Receiver = receiverID;
            email.Subject = subject;
            email.Content = content;
            email.CreatedTime = createdTime;
            email.Tag = tag;

            lblEmailSent.Visible = true;
            lblContent.Visible = false;
            lblFrom.Visible = false;
            lblSubject.Visible = false;
            lblTo.Visible = false;
            lblFrom.Visible = false;
            txtBody.Visible = false;
            txtFrom.Visible = false;
            txtSubject.Visible = false;
            txtTo.Visible = false;
            btnSend.Visible = false;
            lblFromExtension.Visible = false;
            lblToExtension.Visible = false;
        }

        //flags email
        protected void btnFlag_Click(object sender, EventArgs e)
        {

            for (int row = 0; row < gvEmail.Rows.Count; row++)
            {
                CheckBox checkBox;
                checkBox = (CheckBox)gvEmail.Rows[row].FindControl("chkFlag");

                if (checkBox.Checked)
                {

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "FlagEmail";

                    objCommand.Parameters.Clear();
                    objCommand.Parameters.AddWithValue("@SenderId", gvEmail.Rows[row].Cells[1].Text);
                    objCommand.Parameters.AddWithValue("@Subject", gvEmail.Rows[row].Cells[2].Text);

                    dBConnect.DoUpdateUsingCmdObj(objCommand);
                }

            }
        }

        //goes back to inbox when user is looking in other folders
        //also moves email back to main inbox
        protected void btnInbox_Click(object sender, EventArgs e)
        {
            String username = Session["username"].ToString() + "@fmail.com";
            String emailTag = "Inbox";
            lblWelcome.Text = "Welcome, " + username + "!";

            for (int row = 0; row < gvEmail.Rows.Count; row++)
            {
                CheckBox checkBox;
                checkBox = (CheckBox)gvEmail.Rows[row].FindControl("chkSelect");

                if (checkBox.Checked)
                {

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "MoveToInbox";

                    objCommand.Parameters.Clear();
                    objCommand.Parameters.AddWithValue("@Subject", gvEmail.Rows[row].Cells[2].Text);
                    objCommand.Parameters.AddWithValue("@SenderId", gvEmail.Rows[row].Cells[1].Text);

                    dBConnect.DoUpdateUsingCmdObj(objCommand);

                    Response.Write("Email moved back to inbox");
                }

            }

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetInbox";

            objCommand.Parameters.Clear();
            objCommand.Parameters.AddWithValue("@username", username);
            objCommand.Parameters.AddWithValue("@emailTag", emailTag);

            DataSet myData; 
            myData = dBConnect.GetDataSetUsingCmdObj(objCommand);
            gvEmail.DataSource = myData;
            gvEmail.DataBind();

            lblFolder.Text = "Main Inbox";

        }

        //views user's sent mail
        protected void btnSent_Click(object sender, EventArgs e)
        {

            String username = Session["username"].ToString() + "@fmail.com";
            lblWelcome.Text = "Welcome, " + username + "!";

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetSentMail";

            objCommand.Parameters.Clear();
            objCommand.Parameters.AddWithValue("@username", username);

            DataSet myData; 
            myData = dBConnect.GetDataSetUsingCmdObj(objCommand);
            gvEmail.DataSource = myData;
            gvEmail.DataBind();

            lblFolder.Text = "Sent Mail";

        }

        //moves email to trash
        protected void btnTrash_Click(object sender, EventArgs e)
        {
            String username = Session["username"].ToString() + "@fmail.com";
            String emailTag = "Trash";
            lblWelcome.Text = "Welcome, " + username + "!";

            for (int row = 0; row < gvEmail.Rows.Count; row++)
            {
                CheckBox checkBox;
                checkBox = (CheckBox)gvEmail.Rows[row].FindControl("chkSelect");

                if (checkBox.Checked)
                {

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "MoveToTrash";

                    objCommand.Parameters.Clear();
                    objCommand.Parameters.AddWithValue("@Subject", gvEmail.Rows[row].Cells[2].Text);
                    objCommand.Parameters.AddWithValue("@SenderId", gvEmail.Rows[row].Cells[1].Text);

                    dBConnect.DoUpdateUsingCmdObj(objCommand);

                    Response.Write("Email moved to trash");
                }

            }

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetTrash";

            objCommand.Parameters.Clear();
            objCommand.Parameters.AddWithValue("@username", username);
            objCommand.Parameters.AddWithValue("@emailTag", emailTag);

            DataSet myData; 
            myData = dBConnect.GetDataSetUsingCmdObj(objCommand);
            gvEmail.DataSource = myData;
            gvEmail.DataBind();
            lblFolder.Text = "Trash Folder";
        }

        //moves email to junk
        protected void btnJunk_Click(object sender, EventArgs e)
        {
            String username = Session["username"].ToString() + "@fmail.com";
            String emailTag = "Junk";
            lblWelcome.Text = "Welcome, " + username + "!";

            for (int row = 0; row < gvEmail.Rows.Count; row++)
            {
                CheckBox checkBox;
                checkBox = (CheckBox)gvEmail.Rows[row].FindControl("chkSelect");

                if (checkBox.Checked)
                {

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "MoveToJunk";

                    objCommand.Parameters.Clear();
                    objCommand.Parameters.AddWithValue("@Subject", gvEmail.Rows[row].Cells[2].Text);
                    objCommand.Parameters.AddWithValue("@SenderId", gvEmail.Rows[row].Cells[1].Text);

                    dBConnect.DoUpdateUsingCmdObj(objCommand);

                    Response.Write("Email moved to junk");
                }

            }
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetJunk";

            objCommand.Parameters.Clear();
            objCommand.Parameters.AddWithValue("@username", username);
            objCommand.Parameters.AddWithValue("@emailTag", emailTag);

            DataSet myData; 
            myData = dBConnect.GetDataSetUsingCmdObj(objCommand);
            gvEmail.DataSource = myData;
            gvEmail.DataBind();

            lblFolder.Text = "Junk Folder";
        }

        //moves email to trash
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            String username = Session["username"].ToString() + "@fmail.com";
            String emailTag = "Trash";
            lblWelcome.Text = "Welcome, " + username + "!";

            for (int row = 0; row < gvEmail.Rows.Count; row++)
            {
                CheckBox checkBox;
                checkBox = (CheckBox)gvEmail.Rows[row].FindControl("chkSelect");

                if (checkBox.Checked)
                {

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "MoveToTrash";

                    objCommand.Parameters.Clear();
                    objCommand.Parameters.AddWithValue("@Subject", gvEmail.Rows[row].Cells[2].Text);
                    objCommand.Parameters.AddWithValue("@SenderId", gvEmail.Rows[row].Cells[1].Text);

                    dBConnect.DoUpdateUsingCmdObj(objCommand);

                    Response.Write("Email moved to trash");
                }

            }
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetTrash";

            objCommand.Parameters.Clear();
            objCommand.Parameters.AddWithValue("@username", username);
            objCommand.Parameters.AddWithValue("@emailTag", emailTag);

            DataSet myData; 
            myData = dBConnect.GetDataSetUsingCmdObj(objCommand);
            gvEmail.DataSource = myData;
            gvEmail.DataBind();

            lblFolder.Text = "Trash Folder";
        }

        //searches emails
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            String username = Session["username"].ToString() + "@fmail.com";
            String password = Session["password"].ToString();
            String searchTerm = txtSearch.Text;

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "Search";

            objCommand.Parameters.Clear();
            objCommand.Parameters.AddWithValue("@username", username);

            DataSet myEmailData; 
            myEmailData = dBConnect.GetDataSetUsingCmdObj(objCommand);
            DataTable emailData = myEmailData.Tables[0];

            for (int row = 0; row < emailData.Rows.Count; row++)
            {
                DataRow emailDataRow = emailData.Rows[row];

                if (searchTerm == emailDataRow["Subject"].ToString())
                {
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "SearchBySubject";

                    objCommand.Parameters.Clear();
                    objCommand.Parameters.AddWithValue("@username", username);
                    objCommand.Parameters.AddWithValue("@searchTerm", searchTerm);

                    DataSet myData; 
                    myData = dBConnect.GetDataSetUsingCmdObj(objCommand);

                    gvEmail.DataSource = myData;
                    gvEmail.DataBind();
                }
                else if (searchTerm == emailDataRow["SenderId"].ToString())
                {
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "SearchBySender";

                    objCommand.Parameters.Clear();
                    objCommand.Parameters.AddWithValue("@username", username);
                    objCommand.Parameters.AddWithValue("@searchTerm", searchTerm);

                    DataSet myData; 
                    myData = dBConnect.GetDataSetUsingCmdObj(objCommand);
                    gvEmail.DataSource = myData;
                    gvEmail.DataBind();
                }
                else if (searchTerm == emailDataRow["CreatedTime"].ToString())
                {
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "SearchByTime";

                    objCommand.Parameters.Clear();
                    objCommand.Parameters.AddWithValue("@username", username);
                    objCommand.Parameters.AddWithValue("@searchTerm", searchTerm);

                    DataSet myData; 
                    myData = dBConnect.GetDataSetUsingCmdObj(objCommand);
                    gvEmail.DataSource = myData;
                    gvEmail.DataBind();
                }

            }


        }

        //takes user back to login page
        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmailLogin.aspx");
        }

        //reads an individual email
        protected void btnRead_Click(object sender, EventArgs e)
        {
            String username = Session["username"].ToString() + "@fmail.com";
            lblWelcome.Text = "Welcome, " + username + "!";

            for (int row = 0; row < gvEmail.Rows.Count; row++)
            {
                CheckBox checkBox;
                checkBox = (CheckBox)gvEmail.Rows[row].FindControl("chkSelect");

                if (checkBox.Checked)
                {
                    txtFrom.Visible = true;
                    txtSubject.Visible = true;
                    txtBody.Visible = true;
                    txtFrom.Enabled = false;
                    txtBody.Enabled = false;
                    txtSubject.Enabled = false;
                    gvEmail.Visible = false;
                    btnBack.Visible = true;
                    btnDelete.Visible = false;
                    btnInbox.Visible = false;
                    btnRead.Visible = false;
                    btnTrash.Visible = false;
                    btnJunk.Visible = false;
                    btnFlag.Visible = false;
                    txtSearch.Visible = false;
                    btnSearch.Visible = false;
                    btnCreateEmail.Visible = false;
                    btnSent.Visible = false;
                    lblFolder.Visible = false;
                    lblFrom.Visible = true;
                    lblSubject.Visible = true;
                    lblContent.Visible = true;

                    txtFrom.Text = gvEmail.Rows[row].Cells[1].Text;
                    txtSubject.Text = gvEmail.Rows[row].Cells[2].Text;
                    txtBody.Text = gvEmail.Rows[row].Cells[3].Text;

                }

            }
        }
    }
}