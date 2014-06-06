using System.ServiceProcess;

namespace Prototype.WindowsService
{
    public static class Program
    {
        const string CONSOLE = "console";

        public static void Main(string[] args)
        {
            //NinjectSiteBindings.Configure(kernel);

            //System.Diagnostics.Debugger.Launch();

            if (args.Length == 1 && args[0].Equals(CONSOLE))
            {
                new WindowsService().ConsoleRun();
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                    new WindowsService()
                };
                ServiceBase.Run(ServicesToRun);
            }            
        }
    }
}
