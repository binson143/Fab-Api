namespace Fab.Api.Domain
{
    public class Installment
    {
        public int Id { get; set; }
        public int PaidAmount { get; set; }
        public int LoanId { get; set; }
        public virtual Loan Loan { get; set; }
    }
}