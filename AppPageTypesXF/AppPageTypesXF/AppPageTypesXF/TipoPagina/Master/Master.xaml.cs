using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPageTypesXF.TipoPagina.Master
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : MasterDetailPage
    {
        public Master()
        {
            InitializeComponent();
        }

        private void MudarPagina1(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Navigation.TipoPagina1());
            IsPresented = false;
        }

        private void MudarPagina2(object sender, EventArgs e)
        {
            Detail = new Navigation.TipoPagina2();
            IsPresented = false;
        }

        private void MudarPagina3(object sender, EventArgs e)
        {
            Detail = new Conteudo();
            IsPresented = false;
        }
    }
}