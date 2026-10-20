using System.Windows;
using System.Windows.Input;

namespace A_corporate_bureaucratic_application_for_optimizing_managers_and_their_professional_activities.Views
{
    public partial class CrueltyMessageBox : Window
    {
        public CrueltyMessageBox(string message, string title = "FATAL ERROR")
        {
            InitializeComponent();
            MessageText.Text = message;

            MouseMove += (s, e) =>
            {
                var pos = e.GetPosition(this);
                double x = Math.Max(0, Math.Min(ActualWidth - CustomCursor.Width, pos.X - 4));
                double y = Math.Max(0, Math.Min(ActualHeight - CustomCursor.Height, pos.Y - 4));
                CustomCursor.Margin = new Thickness(x, y, 0, 0);
            };
        }

        public static void Show(string message, string title = "FATAL ERROR")
        {
            var box = new CrueltyMessageBox(message, title);
            box.ShowDialog();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}