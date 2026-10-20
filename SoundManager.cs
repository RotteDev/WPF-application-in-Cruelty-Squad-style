using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace A_corporate_bureaucratic_application_for_optimizing_managers_and_their_professional_activities
{
    public static class SoundManager
    {
        private class SoundInstance
        {
            public MediaPlayer Player;
            public bool IsFree = true;
        }

        private static readonly Dictionary<string, List<SoundInstance>> _pool
            = new Dictionary<string, List<SoundInstance>>();

        private const int MaxPlayersPerSound = 4;

        public static void PlayWithVolume(string file, double volume)
        {
            try
            {
                string path = $"Assets/{file}";

                if (!_pool.ContainsKey(path))
                    _pool[path] = new List<SoundInstance>();

                var instances = _pool[path];

                SoundInstance freeInstance = null;

                foreach (var inst in instances)
                {
                    if (inst.IsFree)
                    {
                        freeInstance = inst;
                        break;
                    }
                }

                if (freeInstance == null)
                {
                    if (instances.Count < MaxPlayersPerSound)
                    {
                        freeInstance = new SoundInstance
                        {
                            Player = new MediaPlayer()
                        };
                        freeInstance.Player.Open(new Uri(path, UriKind.Relative));
                        instances.Add(freeInstance);
                    }
                    else
                    {
                        freeInstance = instances[0];
                        instances.RemoveAt(0);
                        instances.Add(freeInstance);
                    }
                }

                freeInstance.IsFree = false;

                var player = freeInstance.Player;
                var capturedInstance = freeInstance;

                EventHandler onEnded = null;
                onEnded = (s, e) =>
                {
                    player.MediaEnded -= onEnded;
                    capturedInstance.IsFree = true;
                };

                player.MediaEnded += onEnded;

                player.Volume = SettingsStorage.SoundVolume * volume;
                player.Position = TimeSpan.Zero;

                if (player.NaturalDuration.HasTimeSpan)
                {
                    player.Play();
                }
                else
                {
                    EventHandler onOpened = null;
                    onOpened = (s, e) =>
                    {
                        player.MediaOpened -= onOpened;
                        player.Volume = SettingsStorage.SoundVolume * volume;
                        player.Play();
                    };
                    player.MediaOpened += onOpened;
                }
            }
            catch { }
        }

        public static void Play(string file)
        {
            try
            {
                string path = $"Assets/{file}";

                if (!_pool.ContainsKey(path))
                    _pool[path] = new List<SoundInstance>();

                var instances = _pool[path];

                SoundInstance freeInstance = null;

                foreach (var inst in instances)
                {
                    if (inst.IsFree)
                    {
                        freeInstance = inst;
                        break;
                    }
                }

                if (freeInstance == null)
                {
                    if (instances.Count < MaxPlayersPerSound)
                    {
                        freeInstance = new SoundInstance
                        {
                            Player = new MediaPlayer()
                        };
                        freeInstance.Player.Open(new Uri(path, UriKind.Relative));
                        instances.Add(freeInstance);
                    }
                    else
                    {
                        freeInstance = instances[0];
                        instances.RemoveAt(0);
                        instances.Add(freeInstance);
                    }
                }

                freeInstance.IsFree = false;

                var player = freeInstance.Player;
                var capturedInstance = freeInstance;

                EventHandler onEnded = null;
                onEnded = (s, e) =>
                {
                    player.MediaEnded -= onEnded;
                    capturedInstance.IsFree = true;
                };

                player.MediaEnded += onEnded;
                player.Volume = SettingsStorage.SoundVolume;
                player.Position = TimeSpan.Zero;

                if (player.NaturalDuration.HasTimeSpan)
                {
                    player.Play();
                }
                else
                {
                    EventHandler onOpened = null;
                    onOpened = (s, e) =>
                    {
                        player.MediaOpened -= onOpened;
                        player.Volume = SettingsStorage.SoundVolume;
                        player.Play();
                    };
                    player.MediaOpened += onOpened;
                }
            }
            catch { }
        }
    }
}