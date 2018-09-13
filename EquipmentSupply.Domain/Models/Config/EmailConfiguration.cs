﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentSupply.Domain.Models.Config
{
    public class EmailConfiguration : ConfigValidatatbleObject
    {
        #region Constrcutor

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="enable"></param>
        /// <param name="smtpServer"></param>
        /// <param name="port"></param>
        /// <param name="from"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        public EmailConfiguration(bool enable, string smtpServer, uint port, string from, string login, string password, bool useNTLM)
        {
            this.Enabled = enable;
            this.SmtpServer = smtpServer;
            this.Port = port;
            this.EmailFrom = from;
            this.Login = string.IsNullOrWhiteSpace(login) ? null : login;
            this.Password = string.IsNullOrWhiteSpace(password) ? null : password;
            this.UseNTLM = useNTLM;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Признак включенности рассылки
        /// </summary>
        public bool Enabled { get; set; } = false;

        /// <summary>
        /// Адрес почтового сервера, через который бцдет осуществлятся отправка почты пользователям
        /// </summary>
        public string SmtpServer { get; set; }

        /// <summary>
        /// Порт
        /// </summary>
        public uint Port { get; set; } = 25;

        /// <summary>
        /// Электронный ящик, от имени которого будут отправлятся сообщения
        /// </summary>
        public string EmailFrom { get; set; }

        /// <summary>
        /// Логин для доступа к ящику, через который буду отправлятся почтовые сообщения
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль для доступа к ящику, через который буду отправлятся почтовые сообщения
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Использование аутентифкации Windows
        /// </summary>
        public bool UseNTLM { get; set; }

        #endregion

        public override void Validate()
        {
            if (Enabled)
            {
                if (string.IsNullOrWhiteSpace(SmtpServer))
                {
                    throw new ArgumentException("Не указан почтовый сервер", nameof(SmtpServer));
                }
            }
        }
    }
}