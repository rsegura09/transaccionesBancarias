using transaccionesBancarias.Models;

namespace transaccionesBancarias.Services
{
    public interface ICuentaService
    {
        IEnumerable<Cuenta> Get();
        Task Save(Cuenta cuenta);
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
    }

    
}
