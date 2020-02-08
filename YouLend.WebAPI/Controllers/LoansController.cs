using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouLend.WebAPI.Data;
using YouLend.WebAPI.Data.Repositories;
using YouLend.WebAPI.Entities;

namespace YouLend.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly WebAPIContext _context;
        private readonly ILoanRepository<Loan> _loanRepository;

        public LoansController(WebAPIContext context,
            ILoanRepository<Loan> loanRepository)
        {
            _context = context;
            _loanRepository = loanRepository;
        }

        // GET: api/Loans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loan>>> GetLoan()
        {
            return await _context.Loans.ToListAsync();
        }

        // GET: api/Loans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Loan>> GetLoan(Guid id)
        {
            var loan = await _context.Loans.FindAsync(id);

            if (loan == null)
            {
                return NotFound();
            }

            return loan;
        }

        // PUT: api/Loans/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoan(Guid id, Loan loan)
        {
            if (id != loan.LoanId)
            {
                return NotFound();
            }

            _context.Entry(loan).State = EntityState.Modified;

            try
            {
                _loanRepository.Update(loan);
                var save = await _loanRepository.SaveAsync(loan);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Loans
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Loan>> PostLoan(Loan loan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _loanRepository.Add(loan);
            var save = await _loanRepository.SaveAsync(loan);

            return CreatedAtAction("GetLoan", new { id = loan.LoanId }, loan);
        }

        // DELETE: api/Loans/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Loan>> DeleteLoan(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var loan = await _context.Loans.FindAsync(id);
            if (loan == null)
            {
                return NotFound();
            }

            _loanRepository.Delete(loan);
            var save = await _loanRepository.SaveAsync(loan);

            return Ok(loan);
        }

        private bool LoanExists(Guid id)
        {
            return _context.Loans.Any(e => e.LoanId == id);
        }
    }
}
