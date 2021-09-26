using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceTe
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        static void Main(string[] args)
        {
            if (System.Environment.UserInteractive)
            {
                string parameter = string.Concat(args);
                switch (parameter)
                {
                    case "--install":
                        ManagedInstallerClass.InstallHelper(new string[] { Assembly.GetExecutingAssembly().Location });
                        break;
                    case "--uninstall":
                        ManagedInstallerClass.InstallHelper(new string[] { "/u", Assembly.GetExecutingAssembly().Location });
                        break;
                    default:
                        ServiceController sc = new ServiceController();
                        sc.ServiceName = "WindowsServiceTe";
                        if (sc.Status == ServiceControllerStatus.Stopped)
                        {
                            // Start the service if the current status is stopped.

                            Console.WriteLine("Starting the service...");
                            try
                            {
                                // Start the service, and wait until its status is "Running".
                                sc.Start();
                                sc.WaitForStatus(ServiceControllerStatus.Running);

                                // Display the current service status.
                                Console.WriteLine("The service status is now set to {0}.",
                                                   sc.Status.ToString());
                            }
                            catch (InvalidOperationException)
                            {
                                Console.WriteLine("Could not start the service.");
                            }
                        }
                        break;
                }
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new WindowsServiceTe()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
