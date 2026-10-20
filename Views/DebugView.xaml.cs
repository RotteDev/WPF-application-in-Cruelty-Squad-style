using System;
using System.Windows;
using System.Windows.Controls;

namespace A_corporate_bureaucratic_application_for_optimizing_managers_and_their_professional_activities.Views
{
    public partial class DebugView : UserControl
    {
        private MainScreen _mainScreen;

        public DebugView(MainScreen mainScreen)
        {
            InitializeComponent();
            _mainScreen = mainScreen;

            UpdateAll();
        }

        private void UpdateAll()
        {
            CurrentUIText.Text = $"CURRENT UI: {SettingsStorage.CurrentUI}";
            MentalTestStatusText.Text = $"LAST RESULT: {(SettingsStorage.MentalTestLastPassed ? "PASSED" : "FAILED / NOT TAKEN")}";
            PlayerIDText.Text = $"ID: {SettingsStorage.PlayerID}";
            BrainWashStatusText.Text = _mainScreen?.IsBrainWashEnabled == true ? "ON" : "OFF";

            var lastRest = SettingsStorage.LastRestTime;
            string restInfo;

            if (lastRest == DateTime.MinValue)
                restInfo = "REST: NEVER";
            else
            {
                TimeSpan since = DateTime.Now - lastRest;
                restInfo = $"REST: {since.Hours}h {since.Minutes}m {since.Seconds}s AGO";
            }

            InfoText.Text = $"{restInfo}\n" +
                            $"MUSIC VOLUME: {MusicManager.GetVolume():F2}\n" +
                            $"SOUND VOLUME: {SettingsStorage.SoundVolume:F2}\n" +
                            $"SELF-KILLED: {SettingsStorage.SelfKilled}";
        }

        private void SetUI1_Click(object sender, RoutedEventArgs e)
        {
            _mainScreen?.ApplyUI(1);
            UpdateAll();
        }

        private void SetUI2_Click(object sender, RoutedEventArgs e)
        {
            _mainScreen?.ApplyUI(2);
            UpdateAll();
        }

        private void SetUI3_Click(object sender, RoutedEventArgs e)
        {
            _mainScreen?.ApplyUI(3);
            UpdateAll();
        }

        private void PassMentalTest_Click(object sender, RoutedEventArgs e)
        {
            SettingsStorage.MentalTestLastPassed = true;
            SettingsStorage.MentalTestLastCorrect = 20;
            SettingsStorage.MentalTestLastTotal = 25;
            UpdateAll();
        }

        private void FailMentalTest_Click(object sender, RoutedEventArgs e)
        {
            SettingsStorage.MentalTestLastPassed = false;
            SettingsStorage.MentalTestLastCorrect = 5;
            SettingsStorage.MentalTestLastTotal = 25;
            UpdateAll();
        }

        private void ResetMentalTest_Click(object sender, RoutedEventArgs e)
        {
            SettingsStorage.MentalTestLastPassed = false;
            SettingsStorage.MentalTestLastCorrect = -1;
            SettingsStorage.MentalTestLastTotal = -1;
            UpdateAll();
        }

        private void ResetRestTimer_Click(object sender, RoutedEventArgs e)
        {
            SettingsStorage.Reset();
            UpdateAll();
        }

        private void SetRestReady_Click(object sender, RoutedEventArgs e)
        {
            SettingsStorage.LastRestTime = DateTime.Now.AddHours(-8);
            UpdateAll();
        }

        private void SetRestCooldown_Click(object sender, RoutedEventArgs e)
        {
            SettingsStorage.LastRestTime = DateTime.Now;
            UpdateAll();
        }

        private void ToggleBrainWash_Click(object sender, RoutedEventArgs e)
        {
            if (_mainScreen == null) return;
            _mainScreen.IsBrainWashEnabled = !_mainScreen.IsBrainWashEnabled;
            UpdateAll();
        }

        private void ShowBrainWashNow_Click(object sender, RoutedEventArgs e)
        {
            //i am fucked up
        }

        private void KillSelf_Click(object sender, RoutedEventArgs e)
        {
            SettingsStorage.SelfKilled = true;
            SettingsStorage.CurrentUI = 1;
            SettingsStorage.MentalTestLastPassed = false;

            CrueltyMessageBox.Show("OPERATOR WAS LIQUIDATED (DEBUG).");
            UpdateAll();
        }

        private void CopyID_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(SettingsStorage.PlayerID);
            MessageBox.Show("ID COPIED.");
        }

        private void ResetAll_Click(object sender, RoutedEventArgs e)
        {
            SettingsStorage.Reset();
            SettingsStorage.CurrentUI = 2;
            SettingsStorage.MentalTestLastPassed = false;
            SettingsStorage.MentalTestLastCorrect = -1;
            SettingsStorage.MentalTestLastTotal = -1;
            SettingsStorage.SelfKilled = false;

            UpdateAll();
        }

        private void ResetBio_Click(object sender, RoutedEventArgs e)
        {
            NoteStorage.Save("");
            UpdateAll();
        }

        private void ResetSelfKill_Click(object sender, RoutedEventArgs e)
        {
            SettingsStorage.SelfKilled = false;
            UpdateAll();
        }

        private void RefreshInfo_Click(object sender, RoutedEventArgs e)
        {
            UpdateAll();
        }
    }
}