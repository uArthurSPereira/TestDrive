using System;
using System.Linq;
using System.Collections.Generic;


namespace Backend.Business
{
    public class TestDriveBusiness
    {
        Database.DatabaseTestDrive db = new Database.DatabaseTestDrive();

        public int ConsultarClientePorLogin(int IdLogin)
        {
            if(IdLogin <= 0)
                throw new Exception("Usuario não existe.");

            int IdCliente = db.ConsultarIdClientePorLogin(IdLogin);

            if(IdCliente <= 0)
                throw new Exception("Usuario não existe.");

            return IdCliente;
        }
        public Models.TbLogin Login(Models.TbLogin tb)
        {
            if(tb.DsEmail == string.Empty || !tb.DsEmail.Contains('@'))
                    throw new Exception ("Email Invalido.");
            if(tb.DsSenha == string.Empty)
                    throw new Exception("Senha Invalida.");

            db.Login(tb);

            if(tb.IdLogin <= 0 || tb.DsPerfil == string.Empty)
                    throw new Exception("Usuario não existe.");
            if(tb.TbCliente.Any() ? tb.TbCliente.FirstOrDefault().NmCliente == string.Empty
                                  : tb.TbFuncionario.FirstOrDefault().NmFuncionario == string.Empty)
                    throw new Exception("Usuario não existe.");

            return tb;

        }

        public Models.TbAgendamento CadastrarClienteAgendamento(Models.TbAgendamento tb)
        {
            if(tb.DtAgendamento <= DateTime.Now ||
               tb.DtAgendamento == null ||
               tb.DtAgendamento >= DateTime.Now.AddMonths(2))
                throw new Exception("Data Invalida.");

            if(tb.IdCarro <= 0)
                throw new Exception("Carro invalido.");
            
            if(tb.IdCliente <= 0)
                throw new Exception("Usuario invalido.");

            tb = db.CadastrarClienteAgendamento(tb);

            return tb;
        }

        public List<Models.TbAgendamento> ConsultarClientePorAgendamento(int IdLogin)
        {
            if(IdLogin <= 0)
                throw new Exception("Usuario não existe.");

            List<Models.TbAgendamento> tbs = db.ConsultarClientePorAgendamento(IdLogin);

            if(tbs.Count == 0 || tbs == null)
                throw new Exception("Não há test-drive agendado.");

            return tbs;
        }

        public string ConsultarPlacaCarroPorId(int? IdCarro)
        {
            if(IdCarro <= 0)
                throw new Exception("Carro Invalido.");
            
            string nomePlacaCarro = db.ConsultarPlacaCarroPorId(IdCarro);

            if(nomePlacaCarro == string.Empty)
                throw new Exception("Carro e Placa não identificados.");

            return nomePlacaCarro;
        }
    }
}