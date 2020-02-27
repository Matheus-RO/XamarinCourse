using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace App2Taks.Modelos
{
   public class GerenciadorTarefa
    {
        private List<Tarefa> Lista { get; set; }
        public void Finalizar(int index, Tarefa tarefa)
        {
            Lista = Listar();
            Lista.RemoveAt(index);

            tarefa.DataHoraFinalizacao = DateTime.Now;
            Lista.Add(tarefa);
            Save(Lista);
        }

        public void Salvar(Tarefa tarefa)
        {
            Lista = Listar();
            Lista.Add(tarefa);

            Save(Lista);
        }

        public void Deletar(int index)
        {
            Lista = Listar();
            Lista.RemoveAt(index);

            Save(Lista);
        }

        public List<Tarefa> Listar()
        {
            return ListProperties();
        }

        private void Save(List<Tarefa> Lista)
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
                App.Current.Properties.Remove("Tarefas");

            string jsonVal = JsonConvert.SerializeObject(Lista);
            
            App.Current.Properties.Add("Tarefas", jsonVal);
        }

        private List<Tarefa> ListProperties()
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                string lista = (string)App.Current.Properties["Tarefas"];

                return JsonConvert.DeserializeObject<List<Tarefa>>(lista);
            }

            return new List<Tarefa>();
        }
    }
}
