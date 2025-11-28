using DataGridView.App.UI;
using DataGridView.Repository;
using DataGridView.Services;
using Serilog;
using Serilog.Core;

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
            .WriteTo.Debug()
            .WriteTo.Seq("http://localhost:5341",
                 apiKey: "OrkBMDJ73lmcmhb1JXZF")
            .CreateLogger();

            Log.Debug("Тестовый лог в Debug окне");

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(new ApplicantService(new InMemoryStorage())));
        }
    }
}
