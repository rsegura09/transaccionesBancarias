namespace transaccionesBancarias.Models.Request
{
    public class TransferCuenta
    {
        public int source_account_number {  get; set; }
        public int destination_account_number { get; set; }
        public int amount {  get; set; }
    }
}
