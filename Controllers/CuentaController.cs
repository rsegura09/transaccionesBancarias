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
        private readonly ICuentaService cuentaService;
        public CuentaController(ICuentaService cuentaService)
        {
            this.cuentaService = cuentaService;
        }

        [HttpGet] //Obtiene todas las cuentas registradas
        public IActionResult Get()
        {
            if (cuentaService.Get().Any())
            {
                return Ok(cuentaService.Get());
            }
            else{ return NotFound(); }
        }

        [HttpPost] //Crea una nueva cuenta
        public IActionResult Post([FromBody] Cuenta cuenta)
        {
            cuenta.OwnerName = cuenta.OwnerName.Trim();
            if (cuenta.OwnerName == "")
            {
                return BadRequest();
            } else
            {
                cuentaService.Save(cuenta);
                return Ok($"Account Number: {cuentaService.ultimaCuentaCreada()}");
            }
        }


        [HttpPost("{account_number}/deposit")] //Deposita una cantidad en una cuenta
        public IActionResult Deposit(int account_number, [FromBody] CuentaAmountDTO dto)
        {
            var cuentaExiste = cuentaService.verificarCuenta(account_number);
            if (cuentaExiste == true)
            {
                cuentaService.UpdateBalance(account_number, dto);
                return Ok();
            }else { return NotFound(); }
        }

        [HttpPost("transfer")] //Realiza una transferencia entre cuentas
        public IActionResult Transfer([FromBody] CuentaTransferDTO transferencia)
        {
            var cuentaOrigenExiste = cuentaService.verificarCuenta(transferencia.source_account_number);
            var cuentaDestinoExiste = cuentaService.verificarCuenta(transferencia.destination_account_number);
            
            if (cuentaOrigenExiste == false)
            {
                return NotFound("\"source_account_number\" does not exist!");
            }
            if (cuentaDestinoExiste == false)
            {
                return NotFound("\"destination_account_number\" does not exist!");
            }
            
            cuentaService.ToTransfer(transferencia);
            return Ok();

        }


    }


}
