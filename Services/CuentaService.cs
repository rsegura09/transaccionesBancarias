using transaccionesBancarias.Models;
using transaccionesBancarias.Models.Request;

namespace transaccionesBancarias.Services
{
    public interface ICuentaService
    {
        IEnumerable<Cuenta> Get();
        Task Save(Cuenta cuenta);
        Task UpdateBalance(int account_number, CuentaAmount cuenta);
    }
    public class CuentaService : ICuentaService
    {
        private TransaccionesContext context;
        public CuentaService(TransaccionesContext context)
        {
            this.context = context;
        }

        public IEnumerable<Cuenta> Get()
        {
            return context.Cuentas;
        }

        public async Task Save(Cuenta cuenta)
        {
            context.Cuentas.Add(cuenta);
            await context.SaveChangesAsync();
        }

        public async Task UpdateBalance (int account_number, CuentaAmount cuenta)
        {
            var cuentaActual = context.Cuentas.Find(account_number);
            if (cuentaActual != null)
            {
                cuentaActual.Balance = cuentaActual.InitialBalance + cuenta.amount;
                await context.SaveChangesAsync();
            }

        }
    }

    
}
