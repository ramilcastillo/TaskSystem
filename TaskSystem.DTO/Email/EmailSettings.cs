using System;
using System.Collections.Generic;
using System.Text;

namespace TaskSystem.DTO.Email
{
    public class Email
    {
        private MailContentModel emailSettings;
        //MailContentModel mailSettings = EmailSettings;

        /// <summary>
        /// Email Settings
        /// </summary>
        public MailContentModel EmailSettings
        {
            get
            {
                return emailSettings;
            }
        }
    }
}
