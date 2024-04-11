using Lab9.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Lab9
{
    public sealed partial class AddTrackPage : Page
    {
        public AddTrackPage()
        {
            this.InitializeComponent();
            ViewModel = App.ViewModel;
        }
        public MainViewModel ViewModel { get; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SaveNewTrack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ViewModel.ClearNewTrack();
        }

    }
}
