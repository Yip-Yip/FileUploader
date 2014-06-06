using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceProcess;
using Prototype.RestService;

namespace Prototype.WindowsService
{
    partial class WindowsService : ServiceBase
    {
        ServiceHost _wcfServiceHost = null;
        ConsoleColor consoleColor = ConsoleColor.DarkGray;
        String serviceName = ".NET Reference Project - WCF Restful Service";

        public WindowsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (_wcfServiceHost != null)
            {
                _wcfServiceHost.Close();
            }

            _wcfServiceHost = new WebServiceHost(typeof(CustomerRestService));
            _wcfServiceHost.Open();
        }

        protected override void OnStop()
        {
            if (_wcfServiceHost != null)
            {
                _wcfServiceHost.Close();
                _wcfServiceHost = null;
            }
        }

        internal void ConsoleRun()
        {
            try
            {
                Console.Title = serviceName;
                Console.ForegroundColor = consoleColor;
                Console.WriteLine("{0} Service starting...", serviceName);

                OnStart(null);

                Console.WriteLine("{0} Running - Press the Enter key to STOP the Service!", serviceName);

                Console.ReadLine();
                OnStop();
                Console.WriteLine(string.Format("{0}::stopped", GetType().FullName));
            }
            catch (System.ServiceProcess.TimeoutException timeoutException)
            {
                Console.WriteLine("Timeout Exception. Exception Message: {0}", timeoutException.Message);
                if (_wcfServiceHost != null && _wcfServiceHost.State == CommunicationState.Faulted)
                {
                    _wcfServiceHost.Abort();
                }
                Console.WriteLine("Service Errored!!");
                Console.ReadLine();
            }
            catch (CommunicationException communicationException)
            {
                Console.WriteLine("Communication Exception. Exception Message: {0}", communicationException.Message);
                if (_wcfServiceHost != null && _wcfServiceHost.State == CommunicationState.Faulted)
                {
                    _wcfServiceHost.Abort();
                }
                Console.WriteLine("Service Errored!!");
                Console.ReadLine();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception. Exception Message: {0}", exception.Message);
                Console.WriteLine("Service Errored!!");
                Console.ReadLine();
            }
            finally
            {
                if (_wcfServiceHost != null && _wcfServiceHost.State != CommunicationState.Faulted)
                {
                    _wcfServiceHost.Close();
                }
            }
        }


    }
}
