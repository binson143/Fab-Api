using System.Collections.Generic;
using System.Linq;
using Fab.Api.Domain;
using Fab.Api.Dto;
using Fab.Api.Infra;
using Microsoft.EntityFrameworkCore;

namespace Fab.Api.Services
{
    public class LoanService : ILoanService
    {
        private readonly FabContext _context;

        public LoanService(FabContext context)
        {
            _context = context;
        }
        public List<PaymentDto> GetLoans(int limit, int offset)
        {
            return _context
                .Loans
                .Include(y => y.Installments)
                .Skip(offset)
                .Take(limit)
                .OrderBy(x => x.Id)
                .Select(y => new PaymentDto
                {
                    Id = y.Id,
                    Receiver = y.Receiver,
                    Sender = y.Sender,
                    TotalAmount = y.TotalAmount,
                    PaidAmount = y.Installments.Sum(s => s.PaidAmount)
                }).ToList();
            

        }

        public List<PaymentDto> GetInstallments(int loanId)
        {

            var result= _context.Installments
                .Where(y => y.LoanId == loanId)
                .Include(x => x.Loan)
                .Select(d => new PaymentDto
                {
                    Id = d.Id,
                    Receiver = d.Loan.Receiver,
                    Sender = d.Loan.Sender,
                    TotalAmount = d.Loan.TotalAmount,
                    PaidAmount = d.PaidAmount
                }).ToList();
            return result;
        }
    }
}