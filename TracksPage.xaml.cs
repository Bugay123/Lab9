using Lab9.ViewModels;
using Windows.UI.Xaml.Controls;

namespace Lab9
{

    public sealed partial class TracksPage : Page
    {
        public TracksPage()
        {
            this.InitializeComponent();
            ViewModel = App.ViewModel;
        }

        public MainViewModel ViewModel { get; }
    }
}
