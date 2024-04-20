namespace transaccionesBancarias.Models.DTO
{
    public class CuentaTransferDTO
    {
        public int source_account_number { get; set; }
        public int destination_account_number { get; set; }
        public int amount { get; set; }
    }
}
