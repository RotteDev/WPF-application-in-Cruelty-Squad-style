using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace A_corporate_bureaucratic_application_for_optimizing_managers_and_their_professional_activities.Views
{
    public partial class CEOView : UserControl
    {
        private static MediaPlayer _callPlayer = null;
        private static bool _isInPrivateRoom = false;
        private static bool _ceoJoined = false;
        private static bool _isChannelLocked = false;

        private readonly Random _random = new Random();
        private DispatcherTimer _voiceTimer;
        private DispatcherTimer _callTimer;
        private DispatcherTimer _chatTimer;

        public CEOView()
        {
            InitializeComponent();
            SetupStaticVoiceChannels();

            ChannelGeneral.Click += (s, e) => SwitchChannel("general");
            PrivateRoomButton.Click += ChannelPrivate_Click;

            SwitchChannel("general");
            RestoreChannelVisuals();

            _voiceTimer = new DispatcherTimer();
            _voiceTimer.Interval = TimeSpan.FromSeconds(15);
            _voiceTimer.Tick += (s, e) => UpdateRandomVoiceChannels();
            _voiceTimer.Start();
            UpdateRandomVoiceChannels();
        }

        private void RestoreChannelVisuals()
        {
            if (_isChannelLocked)
            {
                PrivateRoomButton.Opacity = 0.3;
            }

            if (_isInPrivateRoom || _ceoJoined)
            {
                PrivateRoomAvatars.Children.Clear();
                AddAvatarToPanel(PrivateRoomAvatars, "MyAvatar", Brushes.LimeGreen);

                if (_ceoJoined)
                {
                    AddAvatarToPanel(PrivateRoomAvatars, "RealCEO", Brushes.Red);
                }
            }
        }

        private void SetupStaticVoiceChannels()
        {
            AddAvatarToPanel(VoiceCEOAvatars, "AvatarCEO", Brushes.Red);
            AddAvatarToPanel(VoiceCEOAvatars, "Avatar5", Brushes.Red);
        }

        private void SwitchChannel(string channelId)
        {
            MessagesPanel.Children.Clear();
            InputText.Visibility = Visibility.Visible;
            CallCEOButton.Visibility = Visibility.Collapsed;

            if (channelId == "general")
            {
                CurrentChannelText.Text = "#general";

                var rulesBlock = new TextBlock
                {
                    Text = "OBEY THE CEO.\n\n" +
                           "1. It is forbidden to flood with emoticons.\n" +
                           "2. It is forbidden to discuss the actions of the administration.\n" +
                           "3. It is forbidden to discuss and publicly condemn the actions of representatives of admins and moderators.\n" +
                           "4. It is forbidden to use the Caps Lock key unnecessarily.\n" +
                           "5. It is forbidden to transfer the music bot to other channels.\n" +
                           "6. Unreadable nicknames are prohibited.\n" +
                           "7. It is forbidden to use advertising in nicknames.\n" +
                           "8. NO QUESTIONS.",
                    FontFamily = (FontFamily)FindResource("MingLiUFont"),
                    FontSize = 14,
                    Foreground = Brushes.White,
                    TextWrapping = TextWrapping.Wrap,
                    Margin = new Thickness(10)
                };
                MessagesPanel.Children.Add(rulesBlock);

                var signaturePanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Margin = new Thickness(0, 20, 10, 10)
                };
                signaturePanel.Children.Add(new TextBlock
                {
                    Text = "CEO\n",
                    FontFamily = (FontFamily)FindResource("MingLiUFont"),
                    FontSize = 12,
                    FontWeight = FontWeights.Bold,
                    Foreground = Brushes.Red,
                    TextAlignment = TextAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0, 0, 10, 0)
                });
                signaturePanel.Children.Add(new Border
                {
                    BorderBrush = Brushes.Red,
                    BorderThickness = new Thickness(1),
                    Child = new Image
                    {
                        Source = new BitmapImage(new Uri("pack://application:,,,/Assets/AvatarCEO.png")),
                        Width = 40,
                        Height = 40,
                        Stretch = Stretch.Fill
                    }
                });
                MessagesPanel.Children.Add(signaturePanel);

                InputText.Text = "[ INPUT DISABLED ] - READ ONLY";
            }
            else if (channelId == "private")
            {
                CurrentChannelText.Text = "[VOICE] n00b room";
                InputText.Text = "[ MICROPHONE MUTED ]";

                if (_ceoJoined)
                {
                    MessagesPanel.Children.Add(new TextBlock
                    {
                        Text = "RealCEO: Yep i'm real one keep grinding m8",
                        FontFamily = (FontFamily)FindResource("MingLiUFont"),
                        FontSize = 14,
                        Foreground = Brushes.Red,
                        Margin = new Thickness(10)
                    });
                }
                else if (!_isChannelLocked && _isInPrivateRoom)
                {
                    CallCEOButton.Visibility = Visibility.Visible;
                }
                else if (_isChannelLocked)
                {
                    InputText.Text = "[ CHANNEL LOCKED ]";
                }
            }
        }

        private void ChannelPrivate_Click(object sender, RoutedEventArgs e)
        {
            if (_isInPrivateRoom || _isChannelLocked)
            {
                SwitchChannel("private");
                return;
            }

            _isInPrivateRoom = true;

            PrivateRoomAvatars.Children.Clear();
            AddAvatarToPanel(PrivateRoomAvatars, "MyAvatar", Brushes.LimeGreen);

            SwitchChannel("private");
        }

        private void CallCEOButton_Click(object sender, RoutedEventArgs e)
        {
            CallCEOButton.Visibility = Visibility.Collapsed;
            InputText.Text = "[ CALLING CEO... ]";

            PlayCallSound();

            _callTimer = new DispatcherTimer();
            _callTimer.Interval = TimeSpan.FromSeconds(_random.Next(5, 11));
            _callTimer.Tick += (s, args) =>
            {
                _callTimer.Stop();
                StopCallSound();
                CEOJoinsAndSpeaks();
            };
            _callTimer.Start();
        }

        private void PlayCallSound()
        {
            try
            {
                StopCallSound();

                string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "CEOCallSound.mp3");
                if (!File.Exists(fullPath)) return;

                _callPlayer = new MediaPlayer();
                _callPlayer.Open(new Uri(fullPath, UriKind.Absolute));
                _callPlayer.Volume = 1.0;

                _callPlayer.MediaEnded += (s, e) =>
                {
                    if (_callPlayer != null)
                    {
                        _callPlayer.Position = TimeSpan.Zero;
                        _callPlayer.Play();
                    }
                };
                _callPlayer.Play();
            }
            catch { }
        }

        private void StopCallSound()
        {
            if (_callPlayer != null)
            {
                _callPlayer.Stop();
                _callPlayer.Close();
                _callPlayer = null;
            }
        }

        private void CEOJoinsAndSpeaks()
        {
            _ceoJoined = true;
            SoundManager.Play("ButtonOpenSound.mp3");

            PrivateRoomAvatars.Children.Clear();
            AddAvatarToPanel(PrivateRoomAvatars, "MyAvatar", Brushes.LimeGreen);
            AddAvatarToPanel(PrivateRoomAvatars, "RealCEO", Brushes.Red);

            InputText.Text = "[ MICROPHONE MUTED ]";

            var joinedMsg = new TextBlock
            {
                Text = "Joined RealCEO",
                FontFamily = (FontFamily)FindResource("MingLiUFont"),
                FontSize = 12,
                Foreground = Brushes.Gray,
                Margin = new Thickness(10, 10, 0, 5)
            };
            MessagesPanel.Children.Add(joinedMsg);

            _chatTimer = new DispatcherTimer();
            _chatTimer.Interval = TimeSpan.FromSeconds(10);
            _chatTimer.Tick += (s, e) =>
            {
                _chatTimer.Stop();

                var msgPanel = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(10, 0, 0, 10) };

                msgPanel.Children.Add(new Border
                {
                    BorderBrush = Brushes.Red,
                    BorderThickness = new Thickness(1),
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(0, 0, 10, 0),
                    Child = new Image
                    {
                        Source = new BitmapImage(new Uri("pack://application:,,,/Assets/RealCEO.png")),
                        Width = 32,
                        Height = 32,
                        Stretch = Stretch.Fill
                    }
                });

                var textPanel = new StackPanel();
                textPanel.Children.Add(new TextBlock
                {
                    Text = "RealCEO",
                    FontFamily = (FontFamily)FindResource("MingLiUFont"),
                    FontSize = 14,
                    FontWeight = FontWeights.Bold,
                    Foreground = Brushes.Red
                });
                textPanel.Children.Add(new TextBlock
                {
                    Text = "Yep i am real one keep grinding m8",
                    FontFamily = (FontFamily)FindResource("MingLiUFont"),
                    FontSize = 14,
                    Foreground = Brushes.White,
                    TextWrapping = TextWrapping.Wrap
                });

                msgPanel.Children.Add(textPanel);
                MessagesPanel.Children.Add(msgPanel);
                MessagesScroll.ScrollToEnd();

                _chatTimer = new DispatcherTimer();
                _chatTimer.Interval = TimeSpan.FromSeconds(10);
                _chatTimer.Tick += (ss, ee) =>
                {
                    _chatTimer.Stop();

                    if (PrivateRoomAvatars.Children.Count > 0)
                        PrivateRoomAvatars.Children.Clear();

                    MessagesPanel.Children.Add(new TextBlock
                    {
                        Text = "RealCEO left the channel.",
                        FontFamily = (FontFamily)FindResource("MingLiUFont"),
                        FontSize = 12,
                        Foreground = Brushes.Gray,
                        Margin = new Thickness(10, 0, 0, 10)
                    });

                    MessagesPanel.Children.Add(new TextBlock
                    {
                        Text = "You have been kicked from the channel.",
                        FontFamily = (FontFamily)FindResource("MingLiUFont"),
                        FontSize = 12,
                        Foreground = Brushes.Red,
                        Margin = new Thickness(10, 0, 0, 10)
                    });
                    MessagesScroll.ScrollToEnd();

                    _isInPrivateRoom = false;
                    _ceoJoined = false;
                    _isChannelLocked = true;

                    InputText.Text = "[ CHANNEL LOCKED ]";
                    PrivateRoomButton.Opacity = 0.3;
                };
                _chatTimer.Start();
            };
            _chatTimer.Start();
            MessagesScroll.ScrollToEnd();
        }

        private void AddAvatarToPanel(StackPanel panel, string imageName, Brush borderBrush)
        {
            panel.Children.Add(new Border
            {
                BorderBrush = borderBrush,
                BorderThickness = new Thickness(1),
                Margin = new Thickness(0, 0, 4, 0),
                Child = new Image
                {
                    Source = new BitmapImage(new Uri($"pack://application:,,,/Assets/{imageName}.png")),
                    Width = 24,
                    Height = 24,
                    Stretch = Stretch.Fill
                }
            });
        }

        private void UpdateRandomVoiceChannels()
        {
            VoiceHRAvatars.Children.Clear();
            VoiceDivineAvatars.Children.Clear();

            List<int> availableAvatars = new List<int> { 1, 2, 3, 4, 6, 7, 8, 9, 10 };

            GenerateRandomAvatars(VoiceHRAvatars, availableAvatars);
            GenerateRandomAvatars(VoiceDivineAvatars, availableAvatars);
        }

        private void GenerateRandomAvatars(StackPanel panel, List<int> pool)
        {
            int count = _random.Next(1, 4);
            List<int> localPool = new List<int>(pool);

            for (int i = 0; i < count && localPool.Count > 0; i++)
            {
                int idIndex = _random.Next(localPool.Count);
                int avatarId = localPool[idIndex];

                localPool.RemoveAt(idIndex);

                AddAvatarToPanel(panel, $"Avatar{avatarId}", Brushes.Red);
            }
        }

        public void OnClosed()
        {
            _voiceTimer?.Stop();
            _callTimer?.Stop();
            _chatTimer?.Stop();
            StopCallSound();
        }
    }
}   