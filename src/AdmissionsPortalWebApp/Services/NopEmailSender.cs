using Microsoft.AspNetCore.Identity.UI.Services;

namespace AdmissionsPortalWebApp.Services;

public class NopEmailSender : IEmailSender
{
    readonly ILogger<NopEmailSender>? logger;

    public NopEmailSender(ILogger<NopEmailSender>? logger = null)
    {
        this.logger = logger;
    }

    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        this.logger?.LogWarning("正在使用模拟邮件发送器，该发送器不会实际执行邮件发送任务。");
        this.logger?.LogInformation("已向{recipiant}发送标题为{subject}的邮件。", email, subject);
        return Task.CompletedTask;
    }
}
