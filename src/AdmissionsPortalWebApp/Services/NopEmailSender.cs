using Microsoft.AspNetCore.Identity.UI.Services;

namespace AdmissionsPortalWebApp.Services;

public class NopEmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        return Task.CompletedTask;
    }
}
