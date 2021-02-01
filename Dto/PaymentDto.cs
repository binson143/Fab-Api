namespace Fab.Api.Dto
{
    public class PaymentDto
    {
        

        public int Id { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public int TotalAmount { get; set; }
        public int PaidAmount { get; set; }
    }

    
}