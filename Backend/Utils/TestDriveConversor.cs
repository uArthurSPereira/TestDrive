using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace Backend.Utils
{
    public class TestDriveConversor
    {
        public Models.TbAgendamento AgendaTabela(Models.Request.AgendamentoRequest req, int idCliente)
        {
            Models.TbAgendamento tb = new Models.TbAgendamento();
            
            tb.IdCliente = idCliente;
            tb.IdFuncionario = null;
            tb.IdCarro = req.IdCarro;
            int hora = Convert.ToInt32(req.Hora.Substring(0, 2));
            int minuto = Convert.ToInt32(req.Hora.Substring(3, 2));
            tb.DtAgendamento = req.Data;
            tb.DsSituacao = "Aguarde";

            return tb;
        }

        public Models.Response.AgendamentoResponse AgendaResponse(Models.TbAgendamento tbs, string Carro)
        {
            Models.Response.AgendamentoResponse resp = new Models.Response.AgendamentoResponse();

            resp.Data = tbs.DtAgendamento;
            resp.Carro = Carro;
            return resp;
        }

        public Models.TbLogin ParaLoginTabela(Models.Request.LoginRequest req)
        {
            Models.TbLogin tb = new Models.TbLogin();
            tb.DsEmail = req.Email;
            tb.DsSenha = req.Senha;

            return tb;
        }  

        public Models.Response.LoginResponse ParaLoginResponse(Models.TbLogin tb)
        {
            Models.Response.LoginResponse resp = new Models.Response.LoginResponse();

            resp.Login = tb.IdLogin;
            resp.Perfil = tb.DsPerfil;
            resp.Nome = tb.TbCliente.Any() ? tb.TbCliente.FirstOrDefault() ?.NmCliente 
                                           : tb.TbFuncionario.FirstOrDefault() ?.NmFuncionario;

            return resp;
        }

        public List<Models.Response.ConsultaClienteResponse> ConsultarClienteAgendamentoResponse(List<Models.TbAgendamento> tbs)
        {
            List<Models.Response.ConsultaClienteResponse> resps = new List<Models.Response.ConsultaClienteResponse>();

            foreach(Models.TbAgendamento tb in tbs)
            {
                Models.Response.ConsultaClienteResponse resp = new Models.Response.ConsultaClienteResponse();

                resp.Carro = string.Concat(tb.IdCarroNavigation.DsMarca, '/', tb.IdCarroNavigation.DsPlaca);
                resp.DataHora = tb.DtAgendamento;
                resp.Funcionario = tb.IdFuncionarioNavigation == null ? "Sem Funcionario" : tb.IdFuncionarioNavigation.NmFuncionario;
                resp.Status = tb.DsSituacao;

                resps.Add(resp);
            }

            return resps;
        }    
    }
}