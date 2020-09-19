using System;
using System.Linq;
using System.Collections.Generic;


namespace Backend.Database
{
    public class TestDriveDatabase
    {
        Models.mydbContext ctx = new Models.mydbContext();
        public List<Models.TbCliente> Listar(int id)
        {
            List<Models.TbCliente> lista = new List<Models.TbCliente>();
            lista = lista.Where(x => x.IdCliente == id).ToList();

            return lista;
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