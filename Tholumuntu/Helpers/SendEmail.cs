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
            var siteUrl = ConfigurationManager.AppSettings["live_website_url"];
            var sender = ConfigurationManager.AppSettings["sender"];
            var link = $"Please click <a href='{webUrl}home/emailverification?username={emailAddress}&confirm_id={tempPass}'>here</a> to confirm your email";

            using (var smtpClient = new SmtpClient())
            {
                var credentials = new NetworkCredential(sender, pass);

                using (var message = new MailMessage())
                {
                    var fromAddress = new MailAddress(sender);

                    smtpClient.Host = "mail.tholaumuntu-dev.co.za";
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = credentials;

                    message.From = fromAddress;
                    message.Subject = "User email verification";
                    // Set IsBodyHtml to true means you can send HTML email.
                    message.IsBodyHtml = true;
                    message.Body = $"Please be advised that you have been added as a user to #Tholumuntu System Website.<br/> {link} ";
                    message.To.Add(emailAddress);

                    try
                    {
                        smtpClient.Send(message);
                    }
                    catch (Exception ex)
                    {
                        //Error, could not send the message
                        Console.Write(ex.Message);
                    }
                }
            }

        }
        public static void SendUserEmail(string emailAddress, string password)
        {
            var pass = ConfigurationManager.AppSettings["EmailPassword"];
            var webUrl = ConfigurationManager.AppSettings["website_url"];
            var siteUrl = ConfigurationManager.AppSettings["live_website_url"];
            var sender = ConfigurationManager.AppSettings["sender"];
            var link = $"Please click <a href='{webUrl}home/emailverification?username={emailAddress}&confirm_id={password}'>here</a> to confirm your email";

            using (var smtpClient = new SmtpClient())
            {
                var credentials = new NetworkCredential(sender, pass);

                using (var message = new MailMessage())
                {
                    var fromAddress = new MailAddress(sender);

                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.Port = 587;
                    //smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = credentials;
                    smtpClient.EnableSsl = true;

                    message.From = fromAddress;
                    message.Subject = "User email verification";
                    message.IsBodyHtml = true;
                    message.Body = $"Please be advised that you have been added as a user to #Tholumuntu System Website.<br/> {link} ";
                    message.To.Add(emailAddress);

                    try
                    {
                        smtpClient.Send(message);
                    }
                    catch (Exception ex)
                    {
                        //Error, could not send the message
                        Console.Write(ex.Message);
                    }
                }
            }
        }

        public static bool SendMessageToAdmin(string subject, string messageBody, string userEmailAddress, string contactNumber, string fullName)
        {
            var pass = ConfigurationManager.AppSettings["EmailPassword"];
            var toEmailAddress = "ayandapatrick@gmail.com";//ConfigurationManager.AppSettings["MatchMe"];
            var sender = ConfigurationManager.AppSettings["sender"];

            using (var smtpClient = new SmtpClient())
            {
                var credentials = new NetworkCredential(sender, pass);

                using (var message = new MailMessage())
                {
                    var fromAddress = new MailAddress(sender);

                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.Port = 587;
                    smtpClient.Credentials = credentials;
                    smtpClient.EnableSsl = true;

                    message.From = fromAddress;
                    message.Subject = subject;
                    message.IsBodyHtml = true;
                    message.Body = $"Dear Tholaumuntu, <br/><br/> <b>{subject}</b> Request. The details are as follow, <br/><br/>Full name: {fullName} <br/> Email address: {userEmailAddress} <br/> Contact number: {contactNumber} <br/> Message: {messageBody} <br/><br/> Message generated from the <b>Tholaumuntu Web Application </b>";
                    message.To.Add(toEmailAddress);

                    try
                    {
                        smtpClient.Send(message);

                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.Message);
                        return false;
                    }
                }
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