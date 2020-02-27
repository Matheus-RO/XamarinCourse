using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App_Layouts
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void IrPaginaAbsolute(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Layouts.Absolute.AbsolutePage());
        }

        private void IrPaginaStack(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Layouts.Stack.StackPage());
        }

        private void IrPaginaGrid(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Layouts.Grid.GridPage());
        }

        private void IrPaginaRelative(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Layouts.Relative.RelativePage());
        }

        private void IrPaginaScroll(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Layouts.Scroll.ScrollPage());
        }

    }
}
