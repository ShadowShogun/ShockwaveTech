﻿/*
 * References:
 * https://stackoverflow.com/questions/9201239/send-e-mail-via-smtp-using-c-sharp
 * https://docs.microsoft.com/en-us/dotnet/api/system.net.mail?view=netframework-4.7.
 * 
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace mock_up.Classes
{
    class NotificationController
    {
        public void Notifiy(string be, string ce, string bp)
        {
            string BusinessEmail = be;
            string CustomerEmail = ce;
            string BusinessPassword = bp;

            //Port only works for gmail at the maybe a selection for different email providers
            // or store email provider in business database
            //https://myaccount.google.com/u/1/lesssecureapps?pli=1&pageId=none
            //have to allow less secure apps for the email to go through
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(BusinessEmail, BusinessPassword);
            MailMessage mail = new MailMessage(BusinessEmail, CustomerEmail);
            client.Host = "smtp.gmail.com";
            //Might add business name in body or subject
            //subject and body are just test text for now
            //maybe add optional notification form?
            mail.Subject = "You're Up!";
            mail.Body = "You're next in line";
            mail.BodyEncoding = UTF8Encoding.UTF8;
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.Send(mail);
        }
    }
}
