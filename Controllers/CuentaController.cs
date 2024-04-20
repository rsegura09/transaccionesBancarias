using Microsoft.AspNetCore.Mvc;
using transaccionesBancarias.Models.DTO;
using transaccionesBancarias.Models.Entities;
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

        [HttpGet] //Obtiene todas las cuentas registradas
        public IActionResult Get()
        {
            return Ok(cuentaService.Get());
        }

        [HttpPost] //Crea una nueva cuenta
        public IActionResult Post([FromBody] Cuenta cuenta)
        {
            cuentaService.Save(cuenta);
            return Ok(cuenta);
        }

 

        [HttpPost("{account_number}/deposit")] //Deposita una cantidad en una cuenta
        public IActionResult Deposit(int account_number, [FromBody] CuentaAmountDTO dto)
        {
            cuentaService.UpdateBalance(account_number, dto);
            return Ok();
        }

        [HttpPost("transfer")] //Realiza una transferencia entre cuentas
        public IActionResult Transfer([FromBody] CuentaTransferDTO transferencia)
        {
            cuentaService.ToTransfer(transferencia);
            return Ok();
        }


    }


}
