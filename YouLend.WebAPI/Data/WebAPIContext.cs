using Microsoft.EntityFrameworkCore;
using System;
using YouLend.WebAPI.Entities;

namespace YouLend.WebAPI.Data
{
    public class WebAPIContext : DbContext
    {
        public WebAPIContext(DbContextOptions<WebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Loan> Loans { get; set; }
    }
}
