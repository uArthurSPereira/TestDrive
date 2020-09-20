using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace Backend.Utils
{
    public class TestDriveConversor
    {
        Models.mydbContext ctx = new Models.mydbContext();
        public Models.TbCliente ParaTabela(Models.Request.ClienteRequest req)
        {
            Models.TbCliente tb = new Models.TbCliente();

            tb.NmCliente = req.Nome;
            tb.DsCnh = req.CNH;
            tb.DsCpf = req.CPF;

            return tb;
        }

        public Models.Response.ClienteResponse ParaResponse(Models.TbCliente tbs)
        {
            Models.Response.ClienteResponse resp = new Models.Response.ClienteResponse();

            resp.Id = tbs.IdCliente;
            resp.Nome = tbs.NmCliente;
            resp.CNH = tbs.DsCnh;
            resp.CPF = tbs.DsCpf;
            resp.IdLogin = tbs.IdLogin;

            return resp;
        }

        public List<Models.Response.ClienteResponse> ListaResponse (List<Models.TbCliente> tbs)
        {
            List<Models.Response.ClienteResponse> resp = new List<Models.Response.ClienteResponse>();

            tbs.ForEach(x => 
                resp.Add(this.ParaResponse(x))
            );

            return resp;
        }

        public Models.TbAgendamento AgendaTabela(Models.Request.AgendamentoRequest req)
        {
            Models.TbAgendamento tb = new Models.TbAgendamento();
            Models.TbCliente cliente = ctx.TbCliente.FirstOrDefault(x => x.NmCliente == req.NmCliente);
            Models.TbCarro carro = ctx.TbCarro.FirstOrDefault(x => x.DsMarca == req.DsMarca || x.DsModelo == req.DsModelo);
            Models.TbFuncionario funcionario = ctx.TbFuncionario.FirstOrDefault(x => x.NmFuncionario == req.NmFuncionario);

            tb.IdFuncionario = funcionario.IdFuncionario;
            tb.IdCliente = cliente.IdCliente;
            tb.IdCarro = carro.IdCarro;
            tb.DsSituacao = req.Situacao;
            tb.DtAgendamento = req.Agendamento;

            return tb;
        }

        public Models.Response.AgendamentoResponse AgendaResponse(Models.TbAgendamento tbs)
        {
            Models.Response.AgendamentoResponse resp = new Models.Response.AgendamentoResponse();

            resp.IdAgendamento = tbs.IdAgendamento;
            resp.IdCliente = tbs.IdCliente;
            resp.IdCarro = tbs.IdCarro;
            resp.IdFuncionario = tbs.IdFuncionario;
            resp.Agendamento = tbs.DtAgendamento;
            resp.Situacao = tbs.DsSituacao;

            return resp;
        }

        public List<Models.Response.AgendamentoResponse> AgendasResponse (List<Models.TbAgendamento> tbs)
        {
            List<Models.Response.AgendamentoResponse> resp = new List<Models.Response.AgendamentoResponse>();

            tbs.ForEach(x => 
                resp.Add(this.AgendaResponse(x))
            );

            return resp;
        }        
    }
}