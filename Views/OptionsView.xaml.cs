using System.Windows.Controls;

namespace A_corporate_bureaucratic_application_for_optimizing_managers_and_their_professional_activities.Views
{
    public partial class OptionsView : UserControl
    {
        public OptionsView()
        {
            InitializeComponent();

            VolumeSlider.ValueChanged -= VolumeSlider_ValueChanged;
            VolumeSlider.Value = MusicManager.GetVolume();
            VolumeSlider.ValueChanged += VolumeSlider_ValueChanged;

            SoundSlider.ValueChanged -= SoundSlider_ValueChanged;
            SoundSlider.Value = SettingsStorage.SoundVolume;
            SoundSlider.ValueChanged += SoundSlider_ValueChanged;

            UpdateMoneyText();
        }

        private void UpdateMoneyText()
        {
            MoneyText.Text = "$ BLOCKED";
        }

        private void VolumeSlider_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            MusicManager.SetVolume(e.NewValue);
        }

        private void SoundSlider_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            SettingsStorage.SoundVolume = e.NewValue;
        }
    }
}