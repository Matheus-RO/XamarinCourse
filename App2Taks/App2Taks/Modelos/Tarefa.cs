using System;
using System.Collections.Generic;
using System.Text;

namespace App2Taks.Modelos
{
    public class Tarefa
    {
        public string Nome { get; set; }
        public DateTime? DataHoraFinalizacao { get; set; }
        public byte Prioridade { get; set; }
    }
}
