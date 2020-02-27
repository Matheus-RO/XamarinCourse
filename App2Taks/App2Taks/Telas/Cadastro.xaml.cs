using App2Taks.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2Taks.Telas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastro : ContentPage
    {
        private byte Prioridade { get; set; }
        public Cadastro()
        {
            InitializeComponent();
        }

        private void PrioridadeSelect_Tapped(object sender, EventArgs e)
        {
            var stacks = PrioridadesSL.Children;

            foreach(var stack in stacks)
            {
                Label prioridade = ((StackLayout)stack).Children[1] as Label;
                prioridade.TextColor = Color.Gray;
            }

            ((Label)((StackLayout)sender).Children[1]).TextColor = Color.Black;

            FileImageSource source = ((Image)((StackLayout)sender).Children[0]).Source as FileImageSource;
            
            string prioridadeImg = source.File.ToString().Replace("Resources/p", "").Replace(".png", "");

            Prioridade = byte.Parse(prioridadeImg);
        }

        private void SalvarButton_Clicked(object sender, EventArgs e)
        {
            bool hasError = false;

            if (string.IsNullOrEmpty(txtNome.Text))
            {
                DisplayAlert("Erro", "Nome não preenchido", "OK");
                hasError = true;

            }

            if (Prioridade <= 0)
            {
                DisplayAlert("Erro", "Prioridade não foi informada", "OK");
                hasError = true;
            }


            if (!hasError)
            {
                Tarefa tarefa = new Tarefa();

                tarefa.Nome = txtNome.Text;
                tarefa.Prioridade = Prioridade;

                new GerenciadorTarefa().Salvar(tarefa);

                App.Current.MainPage = new NavigationPage(new Inicio());
            }

        }
    }
}