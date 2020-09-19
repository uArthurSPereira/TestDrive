using System;
using System.Linq;
using System.Collections.Generic;


namespace Backend.Business
{
    public class TestDriveBusiness
    {
        Database.TestDriveDatabase db = new Database.TestDriveDatabase();
        public List<Models.TbCliente> Listar(int id)
        {
            List<Models.TbCliente> lista = new List<Models.TbCliente>();
            if(lista == null)
                throw new System.Exception("Nenhum Cliente Encontrado");
            
            return db.Listar(id);
        }
    }
}