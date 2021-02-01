using System.Collections;
using System.Collections.Generic;

namespace Fab.Api.Domain
{
    public class Loan
    {
        public Loan()
        {
            Installments = new List<Installment>();
        }
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public int TotalAmount { get; set; }
        public ICollection<Installment> Installments { get; set; }
    }
}
//loanId