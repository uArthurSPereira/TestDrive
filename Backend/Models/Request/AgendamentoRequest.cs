using System;

namespace Backend.Models.Request
{
    public class AgendamentoRequest
    {
        public int IdCliente {get; set;}
        public int IdFuncionario {get; set;}
        public int IdCarro {get; set;}
        public string Situacao {get; set;}
        public DateTime? Agendamento {get; set;}
    }
}