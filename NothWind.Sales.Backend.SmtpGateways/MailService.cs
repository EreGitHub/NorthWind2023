namespace NothWind.Sales.Backend.SmtpGateways;

internal class MailService(IOptions<SmtpOptions> smtpOptions, Logger<MailService> logger)
    : IMailService
{
    public async ValueTask SendEmailToAdministrator(string subject, string body)
    {
        //servicio fake: https://mailtrap.io/inboxes/1916293/messages
        try
        {
            MailMessage Message =
                new MailMessage(smtpOptions.Value.SenderEmail, smtpOptions.Value.AdministratorEmail);

            Message.Body = body;
            Message.Subject = subject;

            SmtpClient Client = new SmtpClient(smtpOptions.Value.SmtpHost, smtpOptions.Value.SmtpHostPort)
            {
                Credentials = new NetworkCredential(smtpOptions.Value.SmtpUserName, smtpOptions.Value.SmtpPassword),
                EnableSsl = true
            };

            await Client.SendMailAsync(Message);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
        }
    }
}
