using System;
using System.Windows.Forms;

namespace Client
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var app = new App();

            app.Show();

            while (app.IsRunning)
            {
                Application.DoEvents();
                app.Update();
            }
        }
    }
}