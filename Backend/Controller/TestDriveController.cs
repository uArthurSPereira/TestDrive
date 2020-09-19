using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Backend.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class TestDriveController : ControllerBase
    {
        Business.TestDriveBusiness busi = new Business.TestDriveBusiness();
        Utils.TestDriveConversor conv = new Utils.TestDriveConversor();

        [HttpPost]
        public ActionResult<Models.Response.ClienteResponse> Cadastrar(Models.Request.ClienteRequest req)
        {
            try 
            {
                Models.TbCliente tb = conv.ParaTabela(req);

                busi.Cadastrar(tb);

                Models.Response.ClienteResponse resp = conv.ParaResponse(tb);

                return resp; 
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, ex.Message)
                );
            }
        }


        [HttpPost("Agendar")]
        public ActionResult<Models.Response.AgendamentoResponse> Agendar(Models.Request.AgendamentoRequest req)
        {
             try 
            {
                Models.TbAgendamento tb = conv.AgendaTabela(req);

                busi.Agendar(tb);

                Models.Response.AgendamentoResponse resp = conv.AgendaResponse(tb);
                return resp;
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(404, ex.Message)
                );
            }
        }

    }
}