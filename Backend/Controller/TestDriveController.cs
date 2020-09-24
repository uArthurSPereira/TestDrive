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


        [HttpPost("Agendar")]
        public ActionResult<Models.Response.AgendamentoResponse> AgendarTest(Models.Request.AgendamentoRequest req)
        {
            try 
            {
                int idCliente = busi.ConsultarClientePorLogin(req.IdLogin);

                Models.TbAgendamento tb = conv.AgendaTabela(req, idCliente);

                tb = busi.CadastrarClienteAgendamento(tb);

                string nomeCarroPlaca = busi.ConsultarPlacaCarroPorId(tb.IdCarro);

                Models.Response.AgendamentoResponse resp = conv.AgendaResponse(tb, nomeCarroPlaca);

                return resp;
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, ex.Message)
                );
            }
        }

        [HttpGet("{IdLogin}")]
        public ActionResult<List<Models.Response.ConsultaClienteResponse>> ConsultarAgendamento(int IdLogin)
        {
            try 
            {
                List<Models.TbAgendamento> tbs = busi.ConsultarClientePorAgendamento(IdLogin);

                List<Models.Response.ConsultaClienteResponse> resps = conv.ConsultarClienteAgendamentoResponse(tbs);

                return resps;
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(404, ex.Message)
                );
            }
        }

        [HttpPost("Login")]
        public ActionResult<Models.Response.LoginResponse> Login(Models.Request.LoginRequest req)
        {
            try
            {
                Models.TbLogin tb = conv.ParaLoginTabela(req);

                tb = busi.Login(tb);

                Models.Response.LoginResponse resp = conv.ParaLoginResponse(tb);

                return resp;
            }
            catch(Exception ex)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, ex.Message)
                );
            }
            
        }

    }
}