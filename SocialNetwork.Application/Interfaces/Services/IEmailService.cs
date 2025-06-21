using MailKit.Net.Smtp;
using MimeKit;

namespace SocialNetwork.Application.Interfaces.Services;

public interface IEmailService
{
    public Task SendEmailAsync(string toEmail, string subject, string message);
    public Task SendMessage(MimeMessage message);

}
