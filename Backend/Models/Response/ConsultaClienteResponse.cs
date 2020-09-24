using System;

namespace Backend.Models.Response
{
    public class ConsultaClienteResponse
    {
        public string Status { get; set; }
        public DateTime? DataHora { get; set; }
        public string Funcionario { get; set; }
        public string Carro { get; set; }
    }
}