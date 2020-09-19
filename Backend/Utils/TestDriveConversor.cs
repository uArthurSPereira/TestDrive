using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace Backend.Utils
{
    public class TestDriveConversor
    {
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

        public List<Models.Response.ClienteResponse> ParaResponse (List<Models.TbCliente> tbs)
        {
            List<Models.Response.ClienteResponse> resp = new List<Models.Response.ClienteResponse>();

            tbs.ForEach(x => 
                resp.Add(this.ParaResponse(x))
            );

            return resp;
        }
    }
}