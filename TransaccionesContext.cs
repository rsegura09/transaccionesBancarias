using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using transaccionesBancarias.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace transaccionesBancarias
{
    public class TransaccionesContext : DbContext
    {
        public DbSet<Cuenta> Cuentas {  get; set; }
        public TransaccionesContext(DbContextOptions options) :base(options) { }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Cuenta> cuentaInit = new List<Cuenta>();

            cuentaInit.Add(new Cuenta { AccountNumber=1, OwnerName = "Richard", InitialBalance = 1000 });
            modelBuilder.Entity<Cuenta>(cuenta =>
            {
                cuenta.ToTable("Cuenta");
                cuenta.HasKey(p => p.AccountNumber);
                cuenta.Property(p => p.AccountNumber).HasColumnName("account_number");
                cuenta.Property(p => p.OwnerName).IsRequired().HasMaxLength(150).HasColumnName("owner_name").IsRequired();
                cuenta.Property(p => p.InitialBalance).IsRequired().HasColumnName("initial_balance").IsRequired();
                cuenta.HasData(cuentaInit);
            });
        }
    }
}
