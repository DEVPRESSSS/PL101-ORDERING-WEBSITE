using Microsoft.AspNetCore.Identity.UI.Services;

namespace ONLINE_BUSINESS_PROJECT_FOR_PL101_SUBJECT.Utilities
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}
