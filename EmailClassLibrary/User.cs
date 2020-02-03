using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EmailClassLibrary
{
    public class User
    {
        private String name;
        private String address;
        private String phoneNumber;
        private String newEmail;
        private String contactEmail;
        private String avatar;
        private String password;
        private String active;
        private String type;

        public User()
        {

        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String Address
        {
            get { return address; }
            set { address = value; }
        }

        public String Phone
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public String NewEmail
        {
            get { return newEmail; }
            set { newEmail = value; }
        }

        public String ContactEmail
        {
            get { return contactEmail; }
            set { contactEmail = value; }
        }

        public String Avatar
        {
            get { return avatar; }
            set { avatar = value; }
        }

        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        public String Active
        {
            get { return active; }
            set { password = value; }
        }

        public String Type
        {
            get { return type; }
            set { type = value; }
        }
    }
}
