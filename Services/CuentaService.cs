﻿using transaccionesBancarias.Models.DTO;
using transaccionesBancarias.Models.Entities;

namespace transaccionesBancarias.Services
{
    public interface ICuentaService
    {
        IEnumerable<Cuenta> Get();
        Task Save(Cuenta cuenta);
        Task UpdateBalance(int account_number, CuentaAmountDTO cuenta);
        Task ToTransfer(CuentaTransferDTO transferencia);
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
            cuenta.Balance = cuenta.InitialBalance;
            context.Cuentas.Add(cuenta);
            await context.SaveChangesAsync();
        }

        public async Task UpdateBalance (int account_number, CuentaAmountDTO dto)
        {
            var cuentaActual = context.Cuentas.Find(account_number.ToString());
            if (cuentaActual != null)
            {
                cuentaActual.Balance = cuentaActual.InitialBalance + dto.amount;
                await context.SaveChangesAsync();
            }
        }

        public async Task ToTransfer(CuentaTransferDTO transferencia)
        {
            var source_account = context.Cuentas.Find(transferencia.source_account_number);
            var destination_account = context.Cuentas.Find(transferencia.destination_account_number);

            if (source_account != null && destination_account != null)
            {
                if (source_account.Balance >= transferencia.amount)
                {
                    source_account.Balance -= transferencia.amount;
                    destination_account.Balance += transferencia.amount;
                    await context.SaveChangesAsync();
                }
            }

        }
    }

    
}
