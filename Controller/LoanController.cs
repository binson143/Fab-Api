using Fab.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fab.Api.Controller
{
    
    [Route("api/v1/loans")]
    public class LoanController:Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILoanService _loanService;
    
        
        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var result = _loanService.GetLoans(1000, 0);
            return Ok(result);
        }
        [HttpGet("{limit}/{offset}")]
        public IActionResult Get([FromRoute] int limit,[FromRoute] int offset)
        {
            var result = _loanService.GetLoans(limit, offset);
            return Ok(result);
        }

        [HttpGet("{loanId}/installments")]
        public IActionResult GetPayments([FromRoute] int loanId)
        {
            var result = _loanService.GetInstallments(loanId);
            return Ok(result);
        }
    }
}