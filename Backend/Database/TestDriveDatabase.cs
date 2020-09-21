using System;
using System.Linq;
using System.Collections.Generic;


namespace Backend.Database
{
    public class TestDriveDatabase
    {
        Models.TbCarro carro = new Models.TbCarro();
        Models.TbFuncionario funcionario = new Models.TbFuncionario();
        Models.TbCliente cliente = new Models.TbCliente();
        Models.mydbContext ctx = new Models.mydbContext();
        public List<Models.TbAgendamento> Listar(int id)
        {
            return ctx.TbAgendamento.Where(x => x.IdCliente == id).ToList();
            
        }

        public Models.TbCliente Cadastrar(Models.TbCliente tb)
        {
            ctx.Add(tb);
            ctx.SaveChanges();

            return tb;
        }

        public Models.TbAgendamento Agendar(Models.TbAgendamento tb)
        {
            ctx.Add(tb);
            ctx.SaveChanges();

            return tb;
        }
    }
}