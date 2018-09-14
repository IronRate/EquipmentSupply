using Microsoft.Extensions.DependencyInjection;
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
        //private readonly Domain.Contracts.Services.INotificationWorkerService sendNotificationService;
        private readonly Domain.Contracts.Repositories.IConfigRepository configRepository;
        private readonly System.Timers.Timer _timer;
        private readonly IServiceProvider serviceProvider;
        private bool _isDisposed = false;

        #region Constructor

        public NotificationSenderHost(
            IServiceProvider serviceProvider,
            Domain.Contracts.Repositories.IConfigRepository configRepository
            )
        {
            this.configRepository = configRepository;

            var period = configRepository.GetAsync().Result.Period;

            _timer = new System.Timers.Timer
            {
                Enabled = true,
                AutoReset = false,
                Interval = (double)period
            };
            this.serviceProvider = serviceProvider;
            this.configRepository = configRepository;
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
                using (IServiceScope serviceScope = serviceProvider.CreateScope())
                {
                    var notificationWorker = serviceScope.ServiceProvider.GetService<Domain.Contracts.Services.INotificationWorkerService>();
                    notificationWorker.DoWorkAsync().Wait();
                }
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
