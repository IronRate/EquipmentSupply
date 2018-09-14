using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EquipmentSupply.API.Services
{
    /// <summary>
    /// Реализация сервиса - отправителя нотификационных сообщений
    /// </summary>
    public class NotificationSender : Domain.Contracts.Services.INotificationSender
    {
        private readonly Domain.Contracts.Repositories.IConfigRepository configRepository;


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="configRepository">конфигурация</param>
        public NotificationSender(Domain.Contracts.Repositories.IConfigRepository configRepository)
        {
            this.configRepository = configRepository;
        }


        public async Task<bool> SendAsync(object data)
        {
            var config = configRepository.Get().EmailConfiguration;
            string body = null;

            try
            {
                body=JsonConvert.SerializeObject(data);
            }
            catch (Exception)
            {
                return false;
            }


            SmtpClient smtpClient = new SmtpClient(config.SmtpServer, (int)config.Port);
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(config.EmailFrom);
            mailMessage.To.Add(config.EmailTo);
            mailMessage.Body =body;
            mailMessage.Subject = "Notification";

            try
            {
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (SmtpException smtpEx)
            {
                
            }
            catch (Exception ex)
            {
                
            }
            return false;
            
        }
    }
}
