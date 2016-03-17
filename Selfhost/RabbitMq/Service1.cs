using Hangfire;
using Hangfire.SqlServer;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceProcess;
using Microsoft.Owin.Hosting;

namespace RabbitMq
{
    public partial class Service1 : ServiceBase
    {
        public ServiceHost serviceHost = null;
        private BackgroundJobServer _server;
        private IDisposable _host;
        private const string hangfireEndpoint = "http://localhost:12346";
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            string baseAddress = "";
            //http://docs.hangfire.io/en/latest/background-processing/processing-jobs-in-windows-service.html
            //http://www.techrepublic.com/article/hangfire-simplifies-job-processing-and-fills-gap-in-net-development/
            JobStorage.Current = new SqlServerStorage(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            _server = new BackgroundJobServer();
            var conn = GlobalConfiguration.Configuration.UseSqlServerStorage("ConnectionString");
            //http://weblog.west-wind.com/posts/2013/Sep/04/SelfHosting-SignalR-in-a-Windows-Service
            //LogManager.Current.LogInfo(String.Format("QueueManager Controller Started with {0} threads.",
            //                    Controller.ThreadCount));


            if (serviceHost != null)
            {
                serviceHost.Close();
            }
            _host = WebApp.Start<Startup>(hangfireEndpoint);

            serviceHost = new ServiceHost(typeof(Services.Service1));
            
            //// Enable metadata publishing.
            //ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            //smb.HttpGetEnabled = true;
            //smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            //serviceHost.Description.Behaviors.Add(smb);

            //ServiceEndpoint serviceEndpoint = serviceHost.AddServiceEndpoint(typeof(IService1), new WSHttpBinding(), string.Empty);
            //ServiceEndpoint basicEndpoint = serviceHost.AddServiceEndpoint(typeof(IService1), new BasicHttpBinding(), string.Empty);

            //ServiceDebugBehavior serviceDebugBehaviorstp = serviceHost.Description.Behaviors.Find<ServiceDebugBehavior>();
            //serviceDebugBehaviorstp.HttpHelpPageEnabled = false;
            //serviceHost.Faulted += new EventHandler(ProductHost_Faulted);
            serviceHost.Open();
        }
        static void ProductHost_Faulted(object sender, EventArgs e)
        {
            //TODO:Log exception
            //Console.WriteLine("The ProductService host has faulted.");
        }
        protected override void OnStop()
        {
            _server.Dispose();
            _host.Dispose();
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }
    }
}
