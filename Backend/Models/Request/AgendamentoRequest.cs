using System;

namespace Backend.Models.Request
{
    public class AgendamentoRequest
    {
        public string NmCliente {get; set;}
        public string NmFuncionario {get; set;}
        public string DsMarca {get; set;}
        public string DsModelo {get; set;}
        public string Situacao {get; set;}
        public DateTime? Agendamento {get; set;}
    }
}