using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace A_corporate_bureaucratic_application_for_optimizing_managers_and_their_professional_activities.Views
{
    public partial class RestView : UserControl
    {
        private DateTime _lastRestTime = DateTime.MinValue;
        private readonly TimeSpan _restDuration = TimeSpan.FromMinutes(1);
        private readonly TimeSpan _cooldownDuration = TimeSpan.FromHours(8);
        private DispatcherTimer _restTimer;
        private bool _isResting = false;

        private DateTime _restEndTime = DateTime.MinValue;
        private readonly TimeSpan _goToWorkDuration = TimeSpan.FromSeconds(10);

        private readonly TimeSpan _smileChangeInterval = TimeSpan.FromSeconds(1);
        private int _smileIndex = 1;

        private readonly string[] _smileFiles =
        {
            "Smile-1", "Smile0", "Smile1", "Smile2", "Smile3"
        };

        public RestView()
        {
            InitializeComponent();

            _lastRestTime = SettingsStorage.LastRestTime;
            SetSmile(1);

            _restTimer = new DispatcherTimer();
            _restTimer.Interval = TimeSpan.FromSeconds(1);
            _restTimer.Tick += RestTimer_Tick;
            _restTimer.Start();

            UpdateRestStatus();
        }

        private void NextButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (_isResting) return;
            if (DateTime.Now - _lastRestTime < _cooldownDuration) return;

            SoundManager.Play("RestSound.mp3");

            _isResting = true;
            _lastRestTime = DateTime.Now;
            SettingsStorage.LastRestTime = _lastRestTime;

            SetSmile(1);
            UpdateRestStatus();
        }

        private void RestTimer_Tick(object sender, EventArgs e)
        {
            if (_isResting && DateTime.Now - _lastRestTime >= _restDuration)
            {
                _isResting = false;
                _lastRestTime = DateTime.Now;
                _restEndTime = DateTime.Now;
                SettingsStorage.LastRestTime = _lastRestTime;
            }

            UpdateRestStatus();
        }

        private void UpdateRestStatus()
        {
            TimeSpan sinceLastRest = DateTime.Now - _lastRestTime;

            if (_isResting)
            {
                TimeSpan remaining = _restDuration - sinceLastRest;
                if (remaining < TimeSpan.Zero) remaining = TimeSpan.Zero;

                RestTextBox.Text = $"{remaining.Minutes:D2}:{remaining.Seconds:D2}";

                int targetSmile = 1 + (int)(sinceLastRest.TotalSeconds / _smileChangeInterval.TotalSeconds);
                if (targetSmile > 4) targetSmile = 4;

                if (targetSmile != _smileIndex) SetSmile(targetSmile);
            }
            else
            {
                TimeSpan sinceRestEnd = DateTime.Now - _restEndTime;

                if (_restEndTime != DateTime.MinValue && sinceRestEnd < _goToWorkDuration)
                {
                    RestTextBox.Text = "GO TO WORK!!!";

                    int targetSmile = 4 - (int)(sinceRestEnd.TotalSeconds / _smileChangeInterval.TotalSeconds);
                    if (targetSmile < 0) targetSmile = 0;

                    if (targetSmile != _smileIndex) SetSmile(targetSmile);
                }
                else if (sinceLastRest >= _cooldownDuration)
                {
                    RestTextBox.Text = "YOU CAN REST";
                    if (_smileIndex != 1) SetSmile(1);
                }
                else
                {
                    TimeSpan cooldownLeft = _cooldownDuration - sinceLastRest;
                    long totalSeconds = (long)cooldownLeft.TotalSeconds;
                    RestTextBox.Text = $"Next rest after {totalSeconds} seconds";

                    if (_smileIndex != 0) SetSmile(0);
                }
            }
        }

        private void SetSmile(int index)
        {
            if (index < 0) index = 0;
            if (index >= _smileFiles.Length) index = _smileFiles.Length - 1;

            _smileIndex = index;
            SmileImage.Source = new BitmapImage(
                new Uri($"pack://application:,,,/Assets/{_smileFiles[index]}.png", UriKind.Absolute));
        }

        public void OnClosed()
        {
            if (_isResting)
            {
                _isResting = false;
                _lastRestTime = DateTime.Now;
                _restEndTime = DateTime.Now;
                SettingsStorage.LastRestTime = _lastRestTime;
            }

            _restTimer.Stop();
        }
    }
}