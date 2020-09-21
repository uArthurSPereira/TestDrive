using System;

namespace Backend.Models.Response
{
    public class AgendamentoResponse
    {
        public int? IdAgendamento {get; set;}
        public string NmCliente {get; set;}
        public string NmFuncionario {get; set;}
        public string Marca {get; set;}
        public string  Modelo { get; set; }
        public DateTime? Agendamento {get; set;}
    }
}