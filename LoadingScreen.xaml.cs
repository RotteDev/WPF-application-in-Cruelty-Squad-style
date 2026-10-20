using System;
using System.Windows;
using System.Windows.Media;

namespace A_corporate_bureaucratic_application_for_optimizing_managers_and_their_professional_activities
{
    public partial class LoadingScreen : Window
    {
        private MediaPlayer _soundPlayer;

        public LoadingScreen()
        {
            InitializeComponent();
            PlayLoadingSound();
        }

        private void PlayLoadingSound()
        {
            try
            {
                _soundPlayer = new MediaPlayer();
                _soundPlayer.Open(new Uri("Assets/LoadingScreenSound.mp3", UriKind.Relative));
                _soundPlayer.Volume = 0.5;
                _soundPlayer.Play();
            }
            catch
            {
            }
        }

        public void SetStatus(string main)
        {
            StatusText.Text = main;
        }

        public void StopLoadingSound()
        {
            if (_soundPlayer != null)
            {
                _soundPlayer.Stop();
                _soundPlayer.Close();
                _soundPlayer = null;
            }
        }
    }
}