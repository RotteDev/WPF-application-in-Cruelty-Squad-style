using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using A_corporate_bureaucratic_application_for_optimizing_managers_and_their_professional_activities.Views;

namespace A_corporate_bureaucratic_application_for_optimizing_managers_and_their_professional_activities
{
    public partial class MainScreen : Window
    {
        [DllImport("user32.dll")]
        static extern bool ShowCursor(bool bShow);

        private bool _isCloseLocked = false;

        public bool IsCloseLocked
        {
            get => _isCloseLocked;
            set
            {
                _isCloseLocked = value;
                if (ClosePanelIcon != null)
                {
                    ClosePanelIcon.IsEnabled = !value;
                    ClosePanelIcon.IsHitTestVisible = !value;
                    ClosePanelIcon.Opacity = value ? 0.3 : 1.0;
                }
            }
        }

        private UserControl _currentView;
        private HRExecutionerView _hrView;

        private DispatcherTimer _brainWashTimer;
        private readonly Random _brainWashRandom = new Random();
        private readonly string[] _brainWashImages = new string[19];
        private bool _brainWashEnabled = true;

        public bool IsBrainWashEnabled
        {
            get => _brainWashEnabled;
            set
            {
                _brainWashEnabled = value;
                if (!value && BrainWashImage != null)
                    BrainWashImage.Visibility = Visibility.Collapsed;
            }
        }

        private readonly BitmapImage _cursorDefault;
        private readonly BitmapImage _cursorHover;
        private readonly BitmapImage _cursorClick;
        private bool _isOverClickable;
        private bool _isMouseDown;

        public MainScreen(HRExecutionerView hrView = null)
        {
            InitializeComponent();
            MusicManager.Play("Assets/Depression_Nap.mp3", loop: true);

            ApplyUI(SettingsStorage.CurrentUI);
            _hrView = hrView;

            // Курсоры
            _cursorDefault = new BitmapImage(new Uri("pack://application:,,,/Assets/Cursor1.png", UriKind.Absolute));
            _cursorHover = new BitmapImage(new Uri("pack://application:,,,/Assets/Cursor2.png", UriKind.Absolute));
            _cursorClick = new BitmapImage(new Uri("pack://application:,,,/Assets/Cursor3.png", UriKind.Absolute));

            MouseMove += MainScreen_MouseMove;
            PreviewMouseMove += MainScreen_PreviewMouseMove;
            MouseDown += MainScreen_MouseDown;
            MouseUp += MainScreen_MouseUp;

            Activated += MainScreen_Activated;
            Deactivated += MainScreen_Deactivated;

            // Ярлыки
            Options.Click += (s, e) => OpenApp(new OptionsView());
            Calculator.Click += (s, e) => OpenApp(new CalculatorView());
            BioNote.Click += (s, e) => OpenApp(new BioNoteView());
            Divine.Click += (s, e) => OpenApp(new DivineView(this));
            ContactWithCEO.Click += (s, e) => OpenApp(new CEOView());
            CorporateInsight.Click += (s, e) => OpenApp(new InsightView());
            FatigueOptimiztionProtocol.Click += (s, e) => OpenApp(new RestView());

            HRExecutioner.Click += (s, e) =>
            {
                if (_hrView == null)
                    _hrView = new HRExecutionerView();
                OpenApp(_hrView);
            };

            Mental.Click += (s, e) =>
            {
                var mentalView = new MentalWearView();
                OpenApp(mentalView);
                mentalView.Start();
            };
            Contract.Click += (s, e) => OpenApp(new ContractView());

            DebugTool.Click += (s, e) =>
            {
                var debugView = new DebugView(this);
                OpenApp(debugView);
            };

            Exit.Click += (s, e) => Application.Current.Shutdown();

            KeyDown += MainScreen_KeyDown;

            for (int i = 0; i < 19; i++)
                _brainWashImages[i] = $"BrainWashIcon{i + 1}";

            StartBrainWash();
            Dispatcher.BeginInvoke(new Action(WarmUpSounds), DispatcherPriority.Background);

            if (SettingsStorage.SelfKilled)
            {
                SelfKillPanel.Visibility = Visibility.Visible;
                SelfKillPanel.MouseMove += MainScreen_MouseMove;
                SelfKillPanel.PreviewMouseMove += MainScreen_PreviewMouseMove;
                SettingsStorage.SelfKilled = false;
            }
        }

        private void MainScreen_Activated(object sender, EventArgs e)
        {
            ShowCursor(false);
            CustomCursor.Visibility = Visibility.Visible;
        }

        private void MainScreen_Deactivated(object sender, EventArgs e)
        {
            ShowCursor(true);
            CustomCursor.Visibility = Visibility.Hidden;
        }

        private void MainScreen_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released && _isMouseDown)
            {
                _isMouseDown = false;
                UpdateCursorImage();
            }

            var pos = e.GetPosition(this);
            CustomCursor.Margin = new Thickness(pos.X - 4, pos.Y - 4, 0, 0);
        }

        private void MainScreen_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            var element = e.OriginalSource as DependencyObject;
            bool overClickable = FindAncestor<Button>(element) != null;
            if (overClickable != _isOverClickable)
            {
                _isOverClickable = overClickable;
                UpdateCursorImage();
            }
        }

        private void MainScreen_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _isMouseDown = true;
            UpdateCursorImage();
        }

        private void MainScreen_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _isMouseDown = false;
            UpdateCursorImage();
        }

        private void UpdateCursorImage()
        {
            if (_isMouseDown) CustomCursor.Source = _cursorClick;
            else if (_isOverClickable) CustomCursor.Source = _cursorHover;
            else CustomCursor.Source = _cursorDefault;
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            while (current != null)
            {
                if (current is T t) return t;
                current = VisualTreeHelper.GetParent(current);
            }
            return null;
        }

        private void WarmUpSounds()
        {
            string[] sounds =
            {
                "ButtonOpenSound.mp3", "ButtonCloseSound.mp3",
                "HRKillasset.mp3", "HRSearchSound.mp3", "HRClearSound.mp3",
                "HRTypeSound1.mp3", "HRTypeSound2.mp3",
                "InsightSound.mp3", "RestSound.mp3",
                "MentalTestSound.mp3",
                "DivineTestStart.mp3", "DivineTestAgree.mp3",
                "CalculatorSound.mp3",
                "BionoteWriteSound1.mp3", "BionoteWriteSound2.mp3", "BionoteClearSound.mp3",
            };
            foreach (var s in sounds) { try { SoundManager.PlayWithVolume(s, 0); } catch { } }
        }

        private void MainScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.End)
            {
                DebugTool.Visibility = Visibility.Visible;
                DebugTool.IsHitTestVisible = true;
            }
        }

        public void ShowNotice(string message)
        {
            NoticeText.Text = message;
            NoticePanel.Visibility = Visibility.Visible;
            NoticePanel.MouseMove += MainScreen_MouseMove;
            NoticePanel.PreviewMouseMove += MainScreen_PreviewMouseMove;

            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += (s, e) => { timer.Stop(); NoticePanel.Visibility = Visibility.Collapsed; };
            timer.Start();
        }

        private void NoticeOkButton_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.Play("RestSound.mp3");
            NoticePanel.Visibility = Visibility.Collapsed;
        }

        private void UroborosButton_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.Play("RestSound.mp3");
            SelfKillPanel.Visibility = Visibility.Collapsed;
        }

        public void ApplyUI(int uiLevel)
        {
            if (uiLevel < 1) uiLevel = 1;
            if (uiLevel > 3) uiLevel = 3;

            if (UIBackground != null)
            {
                UIBackground.Source = new BitmapImage(
                    new Uri($"pack://application:,,,/Assets/UI{uiLevel}.png", UriKind.Absolute));
            }
            SettingsStorage.CurrentUI = uiLevel;
        }

        private void OpenApp(UserControl view)
        {
            if (ContentPanel.Visibility == Visibility.Visible) return;
            SoundManager.Play("ButtonOpenSound.mp3");
            _currentView = view;

            if (view.Parent is ContentControl oldParent) oldParent.Content = null;

            AppContainer.Content = view;
            ContentPanel.Visibility = Visibility.Visible;

            var scaleAnim = new DoubleAnimationUsingKeyFrames { Duration = TimeSpan.FromMilliseconds(1500) };
            double[] steps = { 0.10, 0.25, 0.45, 0.65, 0.85, 1.00 };
            int pauseMs = 120, moveMs = 60, time = 0;

            scaleAnim.KeyFrames.Add(new LinearDoubleKeyFrame(0.01, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))));
            foreach (double step in steps)
            {
                time += moveMs;
                scaleAnim.KeyFrames.Add(new LinearDoubleKeyFrame(step, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(time))));
                time += pauseMs;
                scaleAnim.KeyFrames.Add(new LinearDoubleKeyFrame(step, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(time))));
            }

            ContentPanelScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            ContentPanelScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);
            SetMainButtonsEnabled(false);
        }

        private void ClosePanelIcon_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.Play("ButtonCloseSound.mp3");
            var scaleAnim = new DoubleAnimationUsingKeyFrames { Duration = TimeSpan.FromMilliseconds(1000) };
            double[] steps = { 0.85, 0.65, 0.45, 0.25, 0.10, 0.01 };
            int pauseMs = 100, moveMs = 50, time = 0;

            scaleAnim.KeyFrames.Add(new LinearDoubleKeyFrame(1.00, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))));
            foreach (double step in steps)
            {
                time += moveMs;
                scaleAnim.KeyFrames.Add(new LinearDoubleKeyFrame(step, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(time))));
                time += pauseMs;
                scaleAnim.KeyFrames.Add(new LinearDoubleKeyFrame(step, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(time))));
            }

            scaleAnim.Completed += (s, args) => ClosePanel();
            ContentPanelScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            ContentPanelScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);
        }

        public void ClosePanel()
        {
            if (_currentView is RestView restView) restView.OnClosed();
            if (_currentView is DivineView divineView) divineView.OnClosed();
            if (_currentView is CEOView ceoView) ceoView.OnClosed();

            AppContainer.Content = null;
            _currentView = null;
            ContentPanel.Visibility = Visibility.Collapsed;
            SetMainButtonsEnabled(true);
            IsCloseLocked = false;
        }

        public void ShutdownViews()
        {
            try { _hrView?.OnClosed(); } catch { }
        }

        private void SetMainButtonsEnabled(bool enabled)
        {
            Options.IsHitTestVisible = enabled;
            Calculator.IsHitTestVisible = enabled;
            BioNote.IsHitTestVisible = enabled;
            Divine.IsHitTestVisible = enabled;
            ContactWithCEO.IsHitTestVisible = enabled;
            CorporateInsight.IsHitTestVisible = enabled;
            FatigueOptimiztionProtocol.IsHitTestVisible = enabled;
            HRExecutioner.IsHitTestVisible = enabled;
            Mental.IsHitTestVisible = enabled;
            Contract.IsHitTestVisible = enabled;
            DebugTool.IsHitTestVisible = enabled;
        }

        private void StartBrainWash()
        {
            _brainWashTimer = new DispatcherTimer();
            _brainWashTimer.Interval = TimeSpan.FromSeconds(30,120);
            _brainWashTimer.Tick += BrainWashTimer_Tick;
            _brainWashTimer.Start();
        }

        private void BrainWashTimer_Tick(object sender, EventArgs e)
        {
            if (!_brainWashEnabled) return;
            string file = _brainWashImages[_brainWashRandom.Next(_brainWashImages.Length)];
            BrainWashImage.Source = new BitmapImage(new Uri($"pack://application:,,,/Assets/{file}.png", UriKind.Absolute));
            BrainWashImage.Visibility = Visibility.Visible;
            int showMs = _brainWashRandom.Next(100);

            var hideTimer = new DispatcherTimer();
            hideTimer.Interval = TimeSpan.FromMilliseconds(showMs);
            hideTimer.Tick += (s, args) =>
            {
                hideTimer.Stop();
                BrainWashImage.Visibility = Visibility.Collapsed;
            };
            hideTimer.Start();
        }

        protected override void OnClosed(EventArgs e)
        {
            ShutdownViews();
            base.OnClosed(e);
        }
    }
}