using System;
using System.IO;

namespace A_corporate_bureaucratic_application_for_optimizing_managers_and_their_professional_activities
{
    public static class NoteStorage
    {
        private static readonly string FilePath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                         "CorporateBureaucraticApp", "bionote.txt");

        public static string Load()
        {
            try
            {
                if (!File.Exists(FilePath)) return "";
                return File.ReadAllText(FilePath);
            }
            catch
            {
                return "";
            }
        }

        public static void Save(string text)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
                File.WriteAllText(FilePath, text);
            }
            catch { }
        }
    }
}