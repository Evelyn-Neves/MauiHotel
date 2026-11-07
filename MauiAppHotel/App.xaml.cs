using MauiAppHotel.Views;
using Microsoft.Maui.Controls;

namespace MauiAppHotel
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new NavigationPage(new Views.ContratacaoHospedagem()))
            {
                Width = 400,
                Height = 600
            };

            return window;
        }
    }
}