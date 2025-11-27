using DataGridView.App.UI;
using DataGridView.Services;

namespace DataGridView.App
{
    internal static class Program
    {
        /// <summary>
        ///  Главный вход в приложение
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(new ApplicantService(new InMemoryStorage())));
        }
    }
}
