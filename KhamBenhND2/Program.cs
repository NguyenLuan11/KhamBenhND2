using KhamBenhND2.Utils;

namespace KhamBenhND2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DatabaseHelper.serverName = "(local)";
            DatabaseHelper.databaseName = "KhamBenhND2";
            DatabaseHelper.userId = "sa";
            DatabaseHelper.password = "170502";
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Home());
        }
    }
}