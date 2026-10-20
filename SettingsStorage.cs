using System;
using System.IO;
using System.Windows;

namespace A_corporate_bureaucratic_application_for_optimizing_managers_and_their_professional_activities
{
    public static class SettingsStorage
    {
        private static readonly string FilePath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                         "CorporateBureaucraticApp", "rest.dat");
        public static double SoundVolume
        {
            get
            {
                try
                {
                    string path = System.IO.Path.Combine(
                        System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
                        "CorporateBureaucraticApp", "sound_volume.dat");
                    if (!System.IO.File.Exists(path)) return 0.6;
                    string text = System.IO.File.ReadAllText(path);
                    if (double.TryParse(text, System.Globalization.NumberStyles.Float,
                        System.Globalization.CultureInfo.InvariantCulture, out double v))
                        return v;
                }
                catch { }
                return 0.6;
            }
            set
            {
                try
                {
                    string dir = System.IO.Path.Combine(
                        System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
                        "CorporateBureaucraticApp");
                    System.IO.Directory.CreateDirectory(dir);
                    System.IO.File.WriteAllText(System.IO.Path.Combine(dir, "sound_volume.dat"),
                        value.ToString(System.Globalization.CultureInfo.InvariantCulture));
                }
                catch { }
            }
        }

        public static bool SelfKilled
        {
            get
            {
                try
                {
                    string path = System.IO.Path.Combine(
                        System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
                        "CorporateBureaucraticApp", "self_killed.dat");
                    if (!System.IO.File.Exists(path)) return false;
                    string text = System.IO.File.ReadAllText(path);
                    if (bool.TryParse(text, out bool v)) return v;
                }
                catch { }
                return false;
            }
            set
            {
                try
                {
                    string dir = System.IO.Path.Combine(
                        System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
                        "CorporateBureaucraticApp");
                    System.IO.Directory.CreateDirectory(dir);
                    System.IO.File.WriteAllText(System.IO.Path.Combine(dir, "self_killed.dat"), value.ToString());
                }
                catch { }
            }
        }

        public static string PlayerID
        {
            get
            {
                try
                {
                    string path = System.IO.Path.Combine(
                        System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
                        "CorporateBureaucraticApp", "player_id.dat");
                    if (!System.IO.File.Exists(path)) return "SUBJECT-J-487258125-56731754-STABLE";
                    return System.IO.File.ReadAllText(path);
                }
                catch { }
                return "SUBJECT-J-487258125-56731754-STABLE";
            }
            set
            {
                try
                {
                    string dir = System.IO.Path.Combine(
                        System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
                        "CorporateBureaucraticApp");
                    System.IO.Directory.CreateDirectory(dir);
                    System.IO.File.WriteAllText(System.IO.Path.Combine(dir, "player_id.dat"), value);
                }
                catch { }
            }
        }

        public static int CurrentUI
        {
            get
            {
                try
                {
                    string path = System.IO.Path.Combine(
                        System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
                        "CorporateBureaucraticApp", "ui.dat");
                    if (!System.IO.File.Exists(path)) return 2;
                    string text = System.IO.File.ReadAllText(path);
                    if (int.TryParse(text, out int v)) return System.Math.Max(1, System.Math.Min(3, v));
                }
                catch { }
                return 2;
            }
            set
            {
                try
                {
                    string dir = System.IO.Path.Combine(
                        System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
                        "CorporateBureaucraticApp");
                    System.IO.Directory.CreateDirectory(dir);
                    System.IO.File.WriteAllText(System.IO.Path.Combine(dir, "ui.dat"), value.ToString());
                }
                catch { }
            }
        }

        public static int MentalTestLastCorrect
        {
            get
            {
                try
                {
                    string path = System.IO.Path.Combine(
                        System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
                        "CorporateBureaucraticApp", "mental_test_correct.dat");
                    if (!System.IO.File.Exists(path)) return -1;
                    string text = System.IO.File.ReadAllText(path);
                    if (int.TryParse(text, out int v)) return v;
                }
                catch { }
                return -1;
            }
            set
            {
                try
                {
                    string dir = System.IO.Path.Combine(
                        System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
                        "CorporateBureaucraticApp");
                    System.IO.Directory.CreateDirectory(dir);
                    System.IO.File.WriteAllText(System.IO.Path.Combine(dir, "mental_test_correct.dat"), value.ToString());
                }
                catch { }
            }
        }

        public static int MentalTestLastTotal
        {
            get
            {
                try
                {
                    string path = System.IO.Path.Combine(
                        System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
                        "CorporateBureaucraticApp", "mental_test_total.dat");
                    if (!System.IO.File.Exists(path)) return -1;
                    string text = System.IO.File.ReadAllText(path);
                    if (int.TryParse(text, out int v)) return v;
                }
                catch { }
                return -1;
            }
            set
            {
                try
                {
                    string dir = System.IO.Path.Combine(
                        System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
                        "CorporateBureaucraticApp");
                    System.IO.Directory.CreateDirectory(dir);
                    System.IO.File.WriteAllText(System.IO.Path.Combine(dir, "mental_test_total.dat"), value.ToString());
                }
                catch { }
            }
        }

        public static bool MentalTestLastPassed
        {
            get
            {
                try
                {
                    string path = System.IO.Path.Combine(
                        System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
                        "CorporateBureaucraticApp", "mental_test_passed.dat");
                    if (!System.IO.File.Exists(path)) return false;
                    string text = System.IO.File.ReadAllText(path);
                    if (bool.TryParse(text, out bool v)) return v;
                }
                catch { }
                return false;
            }
            set
            {
                try
                {
                    string dir = System.IO.Path.Combine(
                        System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
                        "CorporateBureaucraticApp");
                    System.IO.Directory.CreateDirectory(dir);
                    System.IO.File.WriteAllText(System.IO.Path.Combine(dir, "mental_test_passed.dat"), value.ToString());
                }
                catch { }
            }
        }

        public static double MusicVolume
        {
            get
            {
                try
                {
                    string path = System.IO.Path.Combine(
                        System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
                        "CorporateBureaucraticApp", "volume.dat");
                    if (!System.IO.File.Exists(path)) return 0.5;
                    string text = System.IO.File.ReadAllText(path);
                    if (double.TryParse(text, System.Globalization.NumberStyles.Float,
                        System.Globalization.CultureInfo.InvariantCulture, out double v))
                        return v;
                }
                catch { }
                return 0.5;
            }
            set
            {
                try
                {
                    string dir = System.IO.Path.Combine(
                        System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
                        "CorporateBureaucraticApp");
                    System.IO.Directory.CreateDirectory(dir);
                    System.IO.File.WriteAllText(System.IO.Path.Combine(dir, "volume.dat"),
                        value.ToString(System.Globalization.CultureInfo.InvariantCulture));
                }
                catch { }
            }
        }


        public static DateTime LastRestTime
        {
            get
            {
                try
                {
                    if (!File.Exists(FilePath)) return DateTime.MinValue;
                    string text = File.ReadAllText(FilePath);
                    if (DateTime.TryParse(text, out DateTime dt)) return dt;
                }
                catch { }
                return DateTime.MinValue;
            }
            set
            {
                try
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
                    File.WriteAllText(FilePath, value.ToString("o"));
                }
                catch (Exception ex)
                {
                
                }
            }
        }

        public static void Reset()
        {
            try
            {
                if (File.Exists(FilePath))
                    File.Delete(FilePath);
            }
            catch { }
        }
    }
}