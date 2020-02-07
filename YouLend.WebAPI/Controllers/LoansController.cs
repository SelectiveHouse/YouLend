using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YouLend.WebAPI.Data;
using YouLend.WebAPI.Data.Repositories;
using YouLend.WebAPI.Entities;

namespace YouLend.WebAPI.Controllers
{
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
            return await _context.Loan.ToListAsync();
        }

        // GET: api/Loans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Loan>> GetLoan(Guid id)
        {
            var loan = await _context.Loan.FindAsync(id);

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
                return BadRequest();
            }

            _context.Entry(loan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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
            _context.Loan.Add(loan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoan", new { id = loan.LoanId }, loan);
        }

        // DELETE: api/Loans/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Loan>> DeleteLoan(Guid id)
        {
            var loan = await _context.Loan.FindAsync(id);
            if (loan == null)
            {
                return NotFound();
            }

            _context.Loan.Remove(loan);
            await _context.SaveChangesAsync();

            return loan;
        }

        private bool LoanExists(Guid id)
        {
            return _context.Loan.Any(e => e.LoanId == id);
        }
    }
}
