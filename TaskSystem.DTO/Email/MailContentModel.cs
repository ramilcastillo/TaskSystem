using System;
using System.Collections.Generic;
using System.Text;

namespace TaskSystem.DTO.Email
{
    public class MailContentModel
    {
        public string MailTo { get; set; }
        public string MailCC { get; set; }
        //public string MailBCC { get; set; }
        public string MailFrom { get; set; }
        public string MailBody { get; set; }
        public string MailSubject { get; set; }
        public string MailServer { get; set; }
    }
}
