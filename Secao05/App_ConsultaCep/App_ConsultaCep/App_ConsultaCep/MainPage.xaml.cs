using App_ConsultaCep.Model;
using App_ConsultaCep.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App_ConsultaCep
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            buscarButton.Clicked += BuscarCep;
            cepText.Completed += BuscarCep;
            cepText.Unfocused += BuscarCep;
        }

        private void BuscarCep(object sender, EventArgs eventArgs)
        {
            
            string cep = cepText.Text.Trim();

            if (IsValid(cep))
            {
                try
                {
                    Endereco end = ConsultaCepService.BuscarEndereco(cep);

                    if (end != null)
                    {
                        ruaText.Text = end.Logradouro;
                        bairroText.Text = end.Bairro;
                        complementoText.Text = end.Complemento;
                        cidadeText.Text = end.Localidade;
                        ufText.Text = end.Uf;

                        exibirLabel.Text = $"Endereço: {end.Logradouro}, {end.Bairro}, {end.Localidade}, {end.Uf}";
                    }
                    else
                        DisplayAlert("Falha ao consultar", "O endereço não foi encontrado para o CEP informado. Verifique se é um CEP válido!", "Ok");

                } catch(Exception ex)
                {
                    DisplayAlert("Erro", ex.Message, "Ok");    
                }

            }
        }

        private bool IsValid(string cep)
        {
            if (cep.Length < 8 || (cep.Length < 9 && cep.Contains("-")))
            {
                DisplayAlert("Falha", "CEP inválido!", "Ok");
                return false;
            }

            if(cep.Length == 9 && !cep.Contains("-"))
            {
                DisplayAlert("Falha", "CEP inválido! O CEP deve conter apenas 8 números!", "");
                return false;
            }




            return true;
        }
    }
}
