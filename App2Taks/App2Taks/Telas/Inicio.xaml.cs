using App2Taks.Modelos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2Taks.Telas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inicio : ContentPage
    {
        public Inicio()
        {
            InitializeComponent();

            CultureInfo culture = new CultureInfo("pt-BR");
            string data = DateTime.Now.ToString("dddd, dd {0} MMMM {0} yyyy", culture);

            DataHoje.Text = string.Format(data, "de");
            CarregarTarefas();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Cadastro());
        }

        private void CarregarTarefas()
        {
            SLTarefas.Children.Clear();

            List<Tarefa> lista = new GerenciadorTarefa().Listar();

            int i = 0;
            foreach(Tarefa tarefa in lista)
            {
                LinhaStackLayout(tarefa, i);
                i++;
            }
        }

        public void LinhaStackLayout(Tarefa tarefa, int index)
        {
            Image deleteImg = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile("Delete.png") };
            if (Device.RuntimePlatform.Equals(Device.UWP))
                deleteImg.Source = ImageSource.FromFile("Resources/Delete.png");

            TapGestureRecognizer deleteTap = new TapGestureRecognizer();
            deleteTap.Tapped += delegate
            {
                new GerenciadorTarefa().Deletar(index);
                CarregarTarefas();
            };

            deleteImg.GestureRecognizers.Add(deleteTap);

            Image prioridadeImg = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile($"p{tarefa.Prioridade}.png") };
            if (Device.RuntimePlatform.Equals(Device.UWP))
                prioridadeImg.Source = ImageSource.FromFile($"Resources/p{tarefa.Prioridade}.png");

            View stackCentral = null;
            if(tarefa.DataHoraFinalizacao == null)
                stackCentral = new Label() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.FillAndExpand, Text = tarefa.Nome };
            else
            {
                stackCentral = new StackLayout() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.FillAndExpand, Spacing = 0 };
                ((StackLayout)stackCentral).Children.Add(new Label() { Text = tarefa.Nome, TextColor = Color.Gray });
                
                ((StackLayout)stackCentral).Children.Add(new Label() { Text = $"Finalizado em {tarefa.DataHoraFinalizacao.Value.ToString("dd/MM/yyyy - HH:mm")}", TextColor = Color.Gray, FontSize = 10 });
            }

            Image check = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile("CheckOff.png") };
            if (Device.RuntimePlatform.Equals(Device.UWP))
                check.Source = ImageSource.FromFile("Resources/CheckOff.png");

            if(tarefa.DataHoraFinalizacao != null)
            {
                check.Source = ImageSource.FromFile("CheckOn.png");
                if (Device.RuntimePlatform.Equals(Device.UWP))
                    check.Source = ImageSource.FromFile("Resources/CheckOn.png");
            }


            TapGestureRecognizer checkTap = new TapGestureRecognizer();
            checkTap.Tapped += delegate
            {
                new GerenciadorTarefa().Finalizar(index, tarefa);
                CarregarTarefas();
            };

            check.GestureRecognizers.Add(checkTap);

            StackLayout linha = new StackLayout() { Orientation = StackOrientation.Horizontal, Spacing = 15 };

            linha.Children.Add(check);
            linha.Children.Add(stackCentral);
            linha.Children.Add(prioridadeImg);
            linha.Children.Add(deleteImg);

            SLTarefas.Children.Add(linha);
        }
    }
}