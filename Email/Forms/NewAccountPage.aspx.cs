//Gabriella Tuscano
//New Account Page
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
    public partial class NewAccountPage : System.Web.UI.Page
    {
        User user = new User();
        List<User> userList = new List<User>();
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

        //validation to make sure the account is not a duplicate and that all values are entered
        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            User user = new User();

            if (InputValidation() == false || DuplicateCheck() == false)
            {
                Response.Write("One or more values are not filled.");
            }
            else if (DuplicateCheck() == false)
            {
                Response.Write("This email address has already been taken, please try again.");
            }

            //generates avatars
            else
            {
                String avatar = "";
                if (radioAvatar1.Checked == true)
                {
                    avatar = Request["Avatar"].ToString();
                }
                if (radioAvatar2.Checked == true)
                {
                    avatar = Request["Avatar"].ToString();
                }
                if (radioAvatar3.Checked == true)
                {
                    avatar = Request["Avatar"].ToString();
                }
                if (radioAvatar4.Checked == true)
                {
                    avatar = Request["Avatar"].ToString();
                }
                if (radioAvatar5.Checked == true)
                {
                    avatar = Request["Avatar"].ToString();
                }
                if (radioAvatar6.Checked == true)
                {
                    avatar = Request["Avatar"].ToString();
                }
                if (radioAvatar7.Checked == true)
                {
                    avatar = Request["Avatar"].ToString();
                }
                if (radioAvatar8.Checked == true)
                {
                    avatar = Request["Avatar"].ToString();
                }
                if (radioAvatar9.Checked == true)
                {
                    avatar = Request["Avatar"].ToString();
                }
                if (radioAvatar10.Checked == true)
                {
                    avatar = Request["Avatar"].ToString();
                }

                //creates new account

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "UpdateDatabase";

                objCommand.Parameters.AddWithValue("@Name",txtName.Text);
                objCommand.Parameters.AddWithValue("@Phone",txtPhone.Text);
                objCommand.Parameters.AddWithValue("@Address", txtStreet.Text + "," + txtCity.Text + "," + txtState.Text + "," + txtZip.Text);
                objCommand.Parameters.AddWithValue("@NewEmail", txtNewEmail.Text + "@fmail.com");
                objCommand.Parameters.AddWithValue("@ContactEmail", txtContactEmail.Text);
                objCommand.Parameters.AddWithValue("@Avatar", avatar);
                objCommand.Parameters.AddWithValue("@Password", txtPassword.Text);
                objCommand.Parameters.AddWithValue("@Active", "True");
                objCommand.Parameters.AddWithValue("@Type", ddlUserType.Text);

                dBConnect.DoUpdateUsingCmdObj(objCommand);

                String name = txtName.Text;
                String phone = txtPhone.Text;
                String address = txtStreet.Text + ", " + txtCity.Text + " " + txtState.Text + ", "+ txtZip.Text;
                String newEmail = txtNewEmail.Text + "@fmail.com";
                String contactEmail = txtContactEmail.Text;
                String password = txtPassword.Text;
                String active = "True";
                String type = ddlUserType.Text;

                user.Name = name;
                user.Phone = phone;
                user.Address = address;
                user.NewEmail = newEmail;
                user.ContactEmail = contactEmail;
                user.Avatar = avatar;
                user.Password = password;
                user.Active = active;
                user.Type = type;


                //hides all labels and textboxes after a new user is created
                lblName.Visible = false;
                lblPhoneNumber.Visible = false;
                lblAddress.Visible = false;
                lblCity.Visible = false;
                lblCreate.Visible = false;
                lblEmailExtension.Visible = false;
                lblContactEmail.Visible = false;
                lblNewEmail.Visible = false;
                lblState.Visible = false;
                lblType.Visible = false;
                lblZipCode.Visible = false;
                lblStreet.Visible = false;
                lblPassword.Visible = false;
                txtCity.Visible = false;
                txtContactEmail.Visible = false;
                txtCity.Visible = false;
                txtName.Visible = false;
                txtNewEmail.Visible = false;
                txtPhone.Visible = false;
                txtState.Visible = false;
                txtStreet.Visible = false;
                txtZip.Visible = false;
                ddlUserType.Visible = false;
                txtPassword.Visible = false;
                lblSuccess.Visible = true;
                btnBack.Visible = true;
                btnCreateAccount.Visible = false;
                radioAvatar1.Visible = false;
                radioAvatar2.Visible = false;
                radioAvatar3.Visible = false;
                radioAvatar4.Visible = false;
                radioAvatar5.Visible = false;
                radioAvatar6.Visible = false;
                radioAvatar7.Visible = false;
                radioAvatar8.Visible = false;
                radioAvatar9.Visible = false;
                radioAvatar10.Visible = false;
                Response.Redirect("AccountCreated.aspx");
                
            }

        }

        //ensures no textbox is empty
        public bool InputValidation()
        {
            if (txtName.Text == "" || txtStreet.Text == "" || txtCity.Text == "" || txtState.Text == "" || txtZip.Text == "" ||
                txtPhone.Text == "" || txtNewEmail.Text == "" || txtContactEmail.Text == "" || txtPassword.Text == "")
            {
                return false;
            }
            else
                return true;

        }

        //takes user back to login page
        protected void btnBack_Click(object sender, EventArgs e)
        {

            Response.Redirect("EmailLogin.aspx");

        }

        //ensures email address is not already taken
        public bool DuplicateCheck()
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "SelectFromUsers";

            DataSet myData = dBConnect.GetDataSet("SelectFromUsers");
            DataTable userData = myData.Tables[0];
            String newEmail = txtNewEmail.Text + "@fmail.com";

            for (int i = 0; i < userData.Rows.Count; i++)
            {

                DataRow userDataRow = userData.Rows[i];
                if (newEmail == userDataRow["NewEmail"].ToString())
                {
                    return false;
                }
                
            }

            return true;
        }
    }
}