using System;

namespace Backend.Models.Request
{
    public class AgendamentoRequest
    {
        public DateTime? Data { get; set; }
        public string Hora { get; set; }
        public int IdLogin { get; set; }
        public int IdCarro { get; set; }
    }
}