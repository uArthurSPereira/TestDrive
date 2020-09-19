using System;
using System.Linq;
using System.Collections.Generic;


namespace Backend.Database
{
    public class TestDriveDatabase
    {
        public List<Models.TbCliente> Listar(int id)
        {
            List<Models.TbCliente> lista = new List<Models.TbCliente>();
            lista = lista.Where(x => x.IdCliente == id).ToList();

            return lista;
        }
    }
}