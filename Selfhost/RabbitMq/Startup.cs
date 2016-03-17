using Microsoft.Owin;
using Owin;
using Hangfire;
using Hangfire.SqlServer;
using System;


[assembly: OwinStartup(typeof(RabbitMq.Startup))]
namespace RabbitMq
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseErrorPage();
            app.UseWelcomePage("/");
            GlobalConfiguration.Configuration.UseSqlServerStorage(
                "ConnectionString",
                new SqlServerStorageOptions { QueuePollInterval = TimeSpan.FromSeconds(1) });

            app.UseHangfireDashboard();
            app.UseHangfireServer();

            RecurringJob.AddOrUpdate(
                () => Console.WriteLine("{0} Recurring job completed successfully!", DateTime.Now.ToString()),
                Cron.Minutely);
            //Hangfire.ConfigureHangfire()
        }
    }
}
