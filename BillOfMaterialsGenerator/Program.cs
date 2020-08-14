using log4net;
using log4net.Config;
using System;
using System.IO;
using System.Reflection;

namespace BillOfMaterialsGenerator
{
    class Program
    {
        private const int ApplicationSuccess = 0;
        private const int ApplicationError = 1;
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static int Main(string[] args)
        {

            try
            {
                // Load log configuration
                var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
                XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

                log.Info("Application Start");

                //Simulator
                var demoCreator = new DemoCreator { Log = log };
                demoCreator.RunDemoWidgetCreation();

                log.Info("Application Complete");

                return ApplicationSuccess;
            }
            catch (Exception ex)
            {
                log.Fatal("Fatal error occurred during execution", ex);
                return ApplicationError;
            }
        }
    }
}
