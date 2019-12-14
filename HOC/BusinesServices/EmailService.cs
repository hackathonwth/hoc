using System;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using MailKit.Security;

namespace HOC.BusinessService
{
    public class EmailService
    {
        private readonly string emailAddress;
        private readonly string name;
        private readonly string subject;
        private readonly string bodyMessage;

        public EmailService(string emailAddress, string name, string subject, string bodyMessage)
        {
            this.emailAddress = emailAddress;
            this.name = name;
            this.subject = subject;
            this.bodyMessage = bodyMessage;
        }

        public void Send()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("WhatTheHack", "WhatTheHackLCG@gmail.com"));
            message.To.Add(new MailboxAddress(name, emailAddress));
            message.Subject = subject;

            message.Body = new TextPart("plain")
            {
                Text = bodyMessage
            };

            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTlsWhenAvailable);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("WhatTheHackLCG", "LCGHackathon");

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}