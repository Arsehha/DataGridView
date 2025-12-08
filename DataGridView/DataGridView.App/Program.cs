using DataGridView.App.UI;
using DataGridView.Repository;
using DataGridView.Services;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Extensions.Logging;

namespace DataGridView.App
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа в приложение 
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Seq("http://localhost:5341", apiKey: "OrkBMDJ73lmcmhb1JXZF")
            .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 7)
            .CreateLogger();

            var loggerFactory = new SerilogLoggerFactory(Log.Logger, dispose: true);

            var storage = new InMemoryStorage();
            var service = new ApplicantService(storage, loggerFactory);

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(service));
        }
    }
}
