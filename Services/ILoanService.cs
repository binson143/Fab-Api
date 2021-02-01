using System.Collections.Generic;
using System.Dynamic;
using Fab.Api.Domain;
using Fab.Api.Dto;

namespace Fab.Api.Services
{
    public interface ILoanService
    {
        List<PaymentDto> GetLoans(int limit, int offset);
        List<PaymentDto> GetInstallments(int loanId);

    }
}