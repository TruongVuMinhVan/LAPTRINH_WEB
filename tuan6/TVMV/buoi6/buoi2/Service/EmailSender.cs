using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

public class EmailSettings
{
    public string SmtpServer { get; set; }
    public int Port { get; set; }
    public string SenderName { get; set; }
    public string SenderEmail { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}

public interface IEmailSender
{
    Task SendEmailAsync(string toEmail, string subject, string message);
}

public class EmailSender : IEmailSender
{
    private readonly EmailSettings _emailSettings;

    public EmailSender(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        var email = new MimeMessage();
        email.Sender = MailboxAddress.Parse(_emailSettings.SenderEmail);
        email.To.Add(MailboxAddress.Parse(toEmail));
        email.Subject = subject;

        var builder = new BodyBuilder { HtmlBody = message };
        email.Body = builder.ToMessageBody();

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_emailSettings.Username, _emailSettings.Password);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }
}
