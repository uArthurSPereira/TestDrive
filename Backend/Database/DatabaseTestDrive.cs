using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace Backend.Database
{
    public class DatabaseTestDrive
    {
        Models.mydbContext ctx = new Models.mydbContext();

        public int ConsultarIdClientePorLogin(int idLogin)
        {
            return ctx.TbCliente.FirstOrDefault(x => x.IdLogin == idLogin).IdCliente;
        }
        public Models.TbLogin Login(Models.TbLogin tb)
        {
            return ctx.TbLogin
                        .Include(x => x.TbCliente)
                        .Include(x => x.TbFuncionario)
                        .FirstOrDefault(x => x.DsEmail == tb.DsEmail && x.DsSenha == tb.DsSenha);
        }
        
        public List<Models.TbAgendamento> ConsultarClientePorAgendamento(int IdLogin)
        {
            return ctx.TbAgendamento.Include(x => x.IdCarroNavigation)
                                    .Include(x => x.IdClienteNavigation)
                                    .Include(x => x.IdFuncionarioNavigation)
                                    .Where(x => x.IdClienteNavigation.IdCliente == IdLogin &&
                                                x.IdCarroNavigation.IdCarro == x.IdCarroNavigation.IdCarro).ToList();
        }

        public Models.TbAgendamento CadastrarClienteAgendamento(Models.TbAgendamento tb)
        {
            ctx.TbAgendamento.Add(tb);
            ctx.SaveChanges();

            return tb;
        }

        public string ConsultarPlacaCarroPorId(int? IdCarro)
        {
            Models.TbCarro carro = new Models.TbCarro();
            carro = ctx.TbCarro.FirstOrDefault(x => x.IdCarro == IdCarro);

            return string.Concat(carro.DsMarca, '/', carro.DsPlaca);
        }

        public List<Models.TbCarro> ConsultarCarro()
        {
            List<Models.TbCarro> carros = new List<Models.TbCarro>();
            return carros;
        }
    }
}