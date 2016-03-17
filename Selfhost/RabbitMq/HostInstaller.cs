using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace selfhost
{
    [RunInstaller(true)]
    public class HostInstaller: Installer
    {
        private ServiceProcessInstaller process;
        private ServiceInstaller service;

        public HostInstaller()
        {
            process = new ServiceProcessInstaller();
            process.Account = System.ServiceProcess.ServiceAccount.User;
            
            service = new ServiceInstaller();
            
            service.ServiceName = "WCFWindowsServiceSample";
            service.DisplayName = "WCFWindowsServiceSample";
            service.Description = "Sample WCF Service";
            service.StartType = ServiceStartMode.Automatic;

            Installers.Add(process);
            Installers.Add(service);
        }
    }
}
