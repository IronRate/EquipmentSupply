using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EquipmentSupply.API.Services
{
    public class NotificationSenderHost : IHostedService, IDisposable
    {
        private readonly Domain.Contracts.Services.INotificationWorkerService sendNotificationService;
        private readonly System.Timers.Timer _timer;
        private bool _isDisposed = false;

        #region Constructor

        public NotificationSenderHost(Domain.Contracts.Services.INotificationWorkerService sendNotificationService)
        {
            this.sendNotificationService = sendNotificationService;

            _timer = new System.Timers.Timer
            {
                Enabled = true,
                AutoReset = false,
                Interval = 1000 //from configuration
            };
        }

        #endregion

        public void Dispose()
        {
            if (_isDisposed)
                return;
            _timer.Stop();
            _timer.Elapsed -= _timer_Elapsed;
            _timer.Dispose();
            _isDisposed = true;
            GC.SuppressFinalize(this);
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer.Elapsed += _timer_Elapsed;
            //запускаем
            _timer.Start();

            return Task.CompletedTask;
        }



        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                this.sendNotificationService.SendAsync().Wait();
            }
            catch (Exception)
            {

            }
            finally
            {
                _timer.Start();
            }
        }

    }
}
