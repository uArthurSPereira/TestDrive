namespace Backend.Models.Response
{
    public class ClienteResponse
    {
        public int Id {get; set;}
        public string Nome {get; set;}
        public string CNH {get; set;}
        public string CPF {get; set;}
        public int? IdLogin {get; set;}
    }
}