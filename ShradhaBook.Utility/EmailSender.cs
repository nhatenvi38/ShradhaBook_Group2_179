using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace ShradhaBook.Utility
{
    public class EmailSender : IEmailSender
    {
        private readonly string _sendGridSecret;

        public EmailSender(IConfiguration config)
        {
            _sendGridSecret = config.GetValue<string>("SendGrid:SecretKey");
            if (string.IsNullOrEmpty(_sendGridSecret))
            {
                throw new ArgumentNullException(nameof(_sendGridSecret), "SendGrid API key is missing or invalid.");
            }
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                var client = new SendGridClient(_sendGridSecret);
                var from = new EmailAddress("Shradhabook@gmail.com", "Shradha Book");
                var to = new EmailAddress(email);
                var message = MailHelper.CreateSingleEmail(from, to, subject, "", htmlMessage);
                await client.SendEmailAsync(message);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error sending email: {ex.Message}");
                throw; // Rethrow the exception to be handled by the caller
            }
        }
    }
}
