using System;
using System.Linq;
using System.Collections.Generic;


namespace Backend.Business
{
    public class TestDriveBusiness
    {
        Database.TestDriveDatabase db = new Database.TestDriveDatabase();
        public List<Models.TbAgendamento> Listar(int id)
        {
            List<Models.TbAgendamento> lista = new List<Models.TbAgendamento>();
            if(lista == null)
                throw new System.Exception("Nenhum Cliente Encontrado");
            
            return db.Listar(id);
        }

        public Models.TbCliente Cadastrar (Models.TbCliente tb)
        {
            if (string.IsNullOrEmpty(tb.NmCliente))
                throw new Exception("Nome é obrigatório.");
            if (string.IsNullOrEmpty(tb.DsCnh))
                throw new Exception("CNH é obrigatório.");
            if (string.IsNullOrEmpty(tb.DsCpf))
                throw new Exception("CPF é obrigatório.");
            
            return db.Cadastrar(tb);
        }

        public Models.TbAgendamento Agendar (Models.TbAgendamento tb)
        {
            if (tb.IdCarro <= 0)
                throw new Exception("Carro é obrigatório.");
            if (tb.IdCliente <= 0)
                throw new Exception("Cliente é obrigatório.");
            if (tb.IdFuncionario <= 0)
                throw new Exception("Funcionario é obrigatório.");
            if(tb.DtAgendamento < DateTime.Now)
                throw new Exception("Data Invalida");
            
            return db.Agendar(tb);
        }
    }
}