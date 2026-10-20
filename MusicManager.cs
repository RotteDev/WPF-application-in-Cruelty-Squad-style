using System;
using System.Windows.Media;

namespace A_corporate_bureaucratic_application_for_optimizing_managers_and_their_professional_activities
{
    public static class MusicManager
    {
        private static MediaPlayer _player;
        private static double _currentVolume = SettingsStorage.MusicVolume;

        public static void Play(string path, bool loop = true)
        {
            Stop();

            _player = new MediaPlayer();
            _player.Open(new Uri(path, UriKind.Relative));
            _player.Volume = _currentVolume;

            if (loop)
                _player.MediaEnded += OnMediaEnded;

            _player.Play();
        }

        public static void Stop()
        {
            if (_player != null)
            {
                _player.MediaEnded -= OnMediaEnded;
                _player.Stop();
                _player.Close();
                _player = null;
            }
        }

        public static double GetVolume()
        {
            return _currentVolume;
        }

        public static void SetVolume(double volume)
        {
            _currentVolume = Math.Max(0, Math.Min(1, volume));
            SettingsStorage.MusicVolume = _currentVolume;

            if (_player != null)
                _player.Volume = _currentVolume;
        }

        public static bool IsPlaying => _player != null;

        private static void OnMediaEnded(object sender, EventArgs e)
        {
            if (_player != null)
            {
                _player.Position = TimeSpan.Zero;
                _player.Play();
            }
        }
    }
}