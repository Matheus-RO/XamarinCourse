using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPageTypesXF.TipoPagina.Carrousel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TipoPagina3 : ContentPage
	{
		public TipoPagina3 ()
		{
			InitializeComponent ();
		}

        private void MudarPagina(object sender, EventArgs e)
        {
            App.Current.MainPage = new Tabed.Abas();
            //App.Current.MainPage = new NavigationPage(new Navigation.TipoPagina1()) { BarBackgroundColor = Color.Blue};
        }

    }
}