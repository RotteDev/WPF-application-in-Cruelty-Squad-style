using System.Windows.Controls;

namespace A_corporate_bureaucratic_application_for_optimizing_managers_and_their_professional_activities.Views
{
    public partial class EmptyView : UserControl
    {
        public EmptyView(string title)
        {
            InitializeComponent();
            TitleText.Text = title;
        }
    }
}