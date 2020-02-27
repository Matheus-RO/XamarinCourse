using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_Xamarin.Master
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : MasterDetailPage
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void IrPaginaPerfilButton_Clicked(object sender, EventArgs e)
        {
            Detail = new Pages.Perfil1();
        }

        private void IrPaginaSobreButton_Clicked(object sender, EventArgs e)
        {
            Detail = new Pages.Sobre();
        }
    }
}