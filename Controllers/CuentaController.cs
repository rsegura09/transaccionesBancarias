using Microsoft.AspNetCore.Mvc;
using transaccionesBancarias.Models;
using transaccionesBancarias.Services;

namespace transaccionesBancarias.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class CuentaController : ControllerBase
    {
        ICuentaService cuentaService;
        public CuentaController(ICuentaService cuentaService)
        {
            this.cuentaService = cuentaService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(cuentaService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cuenta cuenta)
        {
            cuentaService.Save(cuenta);
            return Ok();
        }
        

    }


}
