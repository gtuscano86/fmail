using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EmailClassLibrary
{
    public class ClassEmail
    {
        private String sender;
        private String receiver;
        private String subject;
        private String content;
        private DateTime createdTime;
        private String tag;

        public ClassEmail()
        {

        }

        public String Sender
        {
            get { return sender; }
            set { sender = value; }
        }

        public String Receiver
        {
            get { return receiver; }
            set { receiver = value; }
        }

        public String Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        public String Content
        {
            get { return content; }
            set { content = value; }
        }

        public DateTime CreatedTime
        {
            get { return createdTime; }
            set { createdTime = value; }
        }

        public String Tag
        {
            get { return tag; }
            set { tag = value; }
        }


    }
}
