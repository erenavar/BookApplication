using Microsoft.AspNetCore.Identity.UI.Services;

namespace BookApplication.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Added for Email Error
            return Task.CompletedTask;
        }
    }
}
