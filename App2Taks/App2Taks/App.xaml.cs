using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2Taks
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new App2Taks.Telas.Inicio());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
