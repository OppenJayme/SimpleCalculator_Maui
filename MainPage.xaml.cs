using Microsoft.Maui.Controls;

namespace Calculator1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel(); // Ensures ViewModel is properly set
        }
    }
}
