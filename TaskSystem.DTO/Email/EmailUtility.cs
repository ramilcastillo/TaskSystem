using System;
using System.Linq;
using System.Text;
using System.Net.Mail;
//using DCAA.Logger;

namespace TaskSystem.DTO.Email
{
    public class EmailUtility
    {
        #region Local Members
        private static string _namespace = "TaskSystem.DTO.Email";
        private static string _class = "EmailUtility";
        #endregion

        /// <summary>
        /// Send email notification...
        /// </summary>
        /// <param name="mailContent">Email configurations</param>
        /// <returns></returns>
        public static void SendMailMessage(MailContentModel mailContent)
        {
            //MailMessage message = new MailMessage();
           // LogEntry le = null;

            try
            {
                using (MailMessage message = new MailMessage())
                {
                    // Add subject...
                    message.Subject = mailContent.MailSubject;

                    // Add body...
                    message.Body = mailContent.MailBody;

                    // Add to recipient list -  throw error if no recipients found...
                    //string[] tokens = GetAddressStringArray(mailContent.MailTo);
                    //if (tokens == null || tokens.Count() == 0)
                    //    throw new Exception("No valid recipient email address was provided for sending mail.");

                    //foreach (string token in tokens)
                    //    message.To.Add(token);
                    message.To.Add(mailContent.MailTo);
                    
                    // Add carbon copy recipient list...  
                    //tokens = GetAddressStringArray(mailContent.MailCC);
                    //if (tokens != null && tokens.Count() != 0)
                    //    foreach (string token in tokens)
                    //        message.CC.Add(token);


                    // Add bcc recipient...
                    //if (!string.IsNullOrEmpty(mailContent.MailBCC) && isValidEmail(mailContent.MailBCC))
                    //    message.Bcc.Add(mailContent.MailBCC);

                    // Add from...
                    message.From = new MailAddress(mailContent.MailFrom);

                    // Encoding details...
                    message.BodyEncoding = Encoding.UTF8;
                    message.SubjectEncoding = Encoding.UTF8;

                    using (SmtpClient smtpClient = new SmtpClient(mailContent.MailServer))
                    {
                        smtpClient.Send(message);
                    }
                    //using ( SmtpClient smtpClient = new SmtpClient(mailContent.MailServer) ) {
                    //    smtpClient.SendCompleted += SendMailCompleted;
                    //    smtpClient.SendAsync(message, mailContent.MailSubject);
                    //}
                    //message.Dispose();
                }
            }
            catch (Exception e)
            {
                //le = new LogEntry()
                //{
                    //Severity = System.Diagnostics.TraceEventType.Warning,
                    //Message = string.Format("{0}.{1}.SendMailMessage " +
                    //    "Following error occurred while emailing notification: {2}.", _namespace, _class, e.Message)
                //};
                //EntLogger.Log(le);
            }
        }

        /// <summary>
        /// Log message if email not sent...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private static void SendMailCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e) {
        //    LogEntry le = null;
        //    string token = (string)e.UserState;

        //    if ( !(!e.Cancelled && e.Error == null) ) {
        //        le = new LogEntry() {
        //            Severity = System.Diagnostics.TraceEventType.Error,
        //            Message = string.Format("{0}.{1}.SendMailCompleted. *** Email Notification FAILED to send for Subject: {2} ***",
        //            _namespace, _class, token)
        //        };
        //        EntLogger.Log(le);
        //    }           
        //}

        /// <summary>
        /// Return array from string...
        /// </summary>
        /// <param name="addressString"></param>
        /// <returns></returns>
        private static string[] GetAddressStringArray(string addressString)
        {
            addressString = addressString.Trim();
            char[] delimiters = new char[] { ';' };
            string[] tokens = addressString.Split(delimiters, StringSplitOptions.None)
                                           .Where(e => !string.IsNullOrEmpty(e) && isValidEmail(e))
                                           .ToArray();
            return tokens;
        }

        /// <summary>
        /// Check the validity of email address....
        /// </summary>
        /// <param name="emailValue"></param>
        /// <returns></returns>
        private static bool isValidEmail(string emailValue)
        {
            string expression = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex(expression);

            return re.IsMatch(emailValue);
        }
    }
}
