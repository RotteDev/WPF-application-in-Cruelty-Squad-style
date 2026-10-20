using System;
using System.Threading.Tasks;
using System.Windows;
using A_corporate_bureaucratic_application_for_optimizing_managers_and_their_professional_activities.Views;

namespace A_corporate_bureaucratic_application_for_optimizing_managers_and_their_professional_activities
{
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            if (SettingsStorage.SelfKilled)
            {
                SettingsStorage.CurrentUI = 1;
            }

            var splash = new LoadingScreen();
            splash.Show();

            splash.SetStatus("INITIALIZING...");
            await Task.Delay(800);

            splash.SetStatus("LOADING CORE MODULES...");
            await Task.Delay(1200);

            splash.SetStatus("LOADING ASSETS...");
            HRExecutionerView hrView = null;
            try
            {
                hrView = new HRExecutionerView();
            }
            catch { }

            await Task.Delay(800);

            splash.SetStatus("CALIBRATING PROFESSIONALISM...");
            await Task.Delay(1400);

            splash.SetStatus("OPTIMIZING MANAGERS...");
            await Task.Delay(2100);

            splash.SetStatus("FINALIZING...");
            await Task.Delay(900);

            splash.StopLoadingSound();

            var main = new MainScreen(hrView);
            main.Show();

            splash.Close();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            if (MainWindow is MainScreen main)
                main.ShutdownViews();

            base.OnExit(e);
        }
    }
}