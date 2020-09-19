using System;

namespace Backend.Models.Response
{
    public class AgendamentoResponse
    {
        public int? IdAgendamento {get; set;}
        public int? IdCliente {get; set;}
        public int? IdFuncionario {get; set;}
        public int? IdCarro {get; set;}
        public string Situacao {get; set;}
        public DateTime? Agendamento {get; set;}
    }
}