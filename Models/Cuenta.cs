namespace transaccionesBancarias.Models
{
    public class Cuenta
    {
        public int AccountNumber { get; set; }
        public string? OwnerName { get; set;}
        public int InitialBalance { get; set; }
        public int Balance { get; set; }
    }
}
