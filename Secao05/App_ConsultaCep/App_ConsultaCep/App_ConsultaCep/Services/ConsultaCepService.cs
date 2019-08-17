using App_ConsultaCep.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace App_ConsultaCep.Services
{
    public class ConsultaCepService
    {
        private static string url = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEndereco(string cep)
        {
            string urlConsulta = string.Format(url, cep);

            WebClient wc = new WebClient();

            string content = wc.DownloadString(urlConsulta);

            Endereco endereco = JsonConvert.DeserializeObject<Endereco>(content);

            if (endereco.Cep == null)
                return null;

            return endereco;
        }
    }
}
