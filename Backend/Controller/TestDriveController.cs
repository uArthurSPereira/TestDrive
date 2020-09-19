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

        [HttpGet]
        public ActionResult<List<Models.Response.ClienteResponse>> Listar(int id)
        {
             try 
            {
                List<Models.TbCliente> lista = busi.Listar(id);

                if (lista.Count == 0)
                    return NotFound();

                return conv.ParaResponse(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, ex.Message)
                );
            }
        }

    }
}