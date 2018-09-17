#region
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
#endregion

namespace EquipmentSupply.API.Services
{
    /// <summary>
    /// Реализация сервиса - отправителя нотификационных сообщений
    /// </summary>
    public class NotificationSender : Domain.Contracts.Services.INotificationSender
    {
        private readonly Domain.Contracts.Repositories.IConfigRepository configRepository;

        #region Constrcutor
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="configRepository">конфигурация</param>
        public NotificationSender(Domain.Contracts.Repositories.IConfigRepository configRepository)
        {
            this.configRepository = configRepository;
        }

        #endregion


        public async Task<bool> SendAsync(object data)
        {
            var config = configRepository.Get().EmailConfiguration;
            string body = null;

            try
            {
                body = JsonConvert.SerializeObject(data);
            }
            catch (Exception)
            {
                return false;
            }

            bool result = false;
            using (SmtpClient smtpClient = new SmtpClient(config.SmtpServer, (int)config.Port))
            {
                smtpClient.EnableSsl = config.EnableSSL;
                if (!string.IsNullOrWhiteSpace(config.Password))
                {
                    smtpClient.Credentials = new System.Net.NetworkCredential(config.Login, config.Password);
                }

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(config.EmailFrom);
                mailMessage.To.Add(config.EmailTo);
                mailMessage.Body = body;
                mailMessage.Subject = "Notification";

                try
                {

                    await smtpClient.SendMailAsync(mailMessage);
                    result = true;

                }
                catch (SmtpException smtpEx)
                {

                }
                catch (Exception ex)
                {

                }
            }
            return result;

        }
    }
}
