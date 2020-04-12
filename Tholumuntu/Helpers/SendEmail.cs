using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace Tholumuntu.Helpers
{
    public static class SendEmail
    {
        public static void SendUserEmail(string emailAddress, string tempPass, string path, string name)
        {
            var pass = ConfigurationManager.AppSettings["EmailPassword"];
            var webUrl = ConfigurationManager.AppSettings["website_url"];

            var template = SetUp(tempPass, path, name);

            var sender = ConfigurationManager.AppSettings["sender"];
            var mail = new MailMessage(sender, emailAddress);

            mail.To.Add(emailAddress);
            mail.From = new MailAddress(sender, "Tholumuntu Administrator");
            mail.Subject = "User Registration";
            mail.Body = template;
            // mail.Body = string.Format("Please be advised that you have been added as a user to Insedlu System Website. Click here {0} <br/> to reset your password", link);
            mail.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                smtp.EnableSsl = true;

                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new NetworkCredential(sender, pass);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(mail);

            }

        }
        public static void SendUserEmail(string emailAddress, string password)
        {
            var pass = ConfigurationManager.AppSettings["EmailPassword"];
            var webUrl = ConfigurationManager.AppSettings["website_url"];
            var siteUrl = ConfigurationManager.AppSettings["live_website_url"];
            var sender = ConfigurationManager.AppSettings["sender"];

            var mail = new MailMessage();
            var link = $"Please click <a href='{webUrl}home/emailverification?username={emailAddress}&confirm_id={password}'>here</a> to confirm your email";
            mail.To.Add(emailAddress);
            mail.From = new MailAddress(sender, "Tholumuntu Administrator");
            mail.Subject = "User Registration";
            mail.Body = $"Please be advised that you have been added as a user to #Tholumuntu System Website.<br/> {link} ";
            mail.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                smtp.EnableSsl = true;

                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(sender, pass);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(mail);

            }

        }
        private static string SetUp(string tempPass, string tempPath, string name)
        {
            var appConfig = ConfigurationManager.AppSettings["email_templates_path"];

            var siteUrl = ConfigurationManager.AppSettings["live_website_url"];
            var footerImage = $"{siteUrl}Images/insedluLog.png";
            var link = $"<a href={siteUrl}resetpassword.aspx?temppass={tempPass}>create</a>";
            //var path = string.Format("{0}emailtemplate.txt", appConfig);
            var template = string.Empty;

            using (var reader = new StreamReader(tempPath))
            {
                template = reader.ReadToEnd();
            }

            template = template.Replace("{USERNAME}", name);
            template = template.Replace("{LINK}", link);
            template = template.Replace("{DATE}", DateTime.Now.Date.ToShortDateString());
            template = template.Replace("{FOOTERIMAGE}", footerImage);

            return template;
        }
    }
}