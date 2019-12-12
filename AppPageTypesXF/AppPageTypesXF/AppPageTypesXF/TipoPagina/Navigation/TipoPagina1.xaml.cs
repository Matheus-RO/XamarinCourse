using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPageTypesXF.TipoPagina.Navigation
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TipoPagina1 : ContentPage
	{
		public TipoPagina1 ()
		{
			InitializeComponent ();
		}

        private void MudarPagina2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TipoPagina2());
        }

        private void AbrirModal(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Modal());
        }

        private void AbrirMaster(object sender, EventArgs e)
        {
            App.Current.MainPage = new Master.Master();
        }
    }
}