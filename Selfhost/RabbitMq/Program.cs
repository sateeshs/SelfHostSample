﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq
{
    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);
            
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException((Exception)e.ExceptionObject);
        }

        static void HandleException(Exception e)
        {
            //Handle your Exception here
        }
    }
}
