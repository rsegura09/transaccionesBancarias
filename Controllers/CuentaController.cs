using Microsoft.AspNetCore.Mvc;
using transaccionesBancarias.Models;
using transaccionesBancarias.Models.Request;
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

        [HttpPut("{account_number}/deposit")]
        public IActionResult Deposit(int account_number, [FromBody] CuentaAmount cuenta)
        {
            cuentaService.UpdateBalance(account_number, cuenta);
            return Ok();
        }
        

    }


}
