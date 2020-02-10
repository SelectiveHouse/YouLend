using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using YouLend.WebAPI.Entities;

namespace YouLend.WebAPI.Data
{
    public class LoanSeeder
    {
        /// <summary>
        /// This method creates and populates an in-memory database with seed data,
        /// when injected as a service provider.
        /// From the brilliant <a href="https://exceptionnotfound.net/ef-core-inmemory-asp-net-core-store-database/">Matthew Jones</a>.
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebAPIContext(
                serviceProvider.GetRequiredService<DbContextOptions<WebAPIContext>>()))
            {
                //Look for any existing loans
                if (context.Loans.Any())
                {
                    //Data is already seeded.
                    return;
                }

                context.Loans.AddRange(
                new Loan
                {
                    LoanId = 1,
                    BorrowerFirstName = "Joe",
                    BorrowerLastName = "Jordan",
                    RepaymentAmount = 6560.60,
                    FundingAmount = 2120.75
                },
                new Loan
                {
                    LoanId = 2,
                    BorrowerFirstName = "Mark",
                    BorrowerLastName = "Ufland",
                    RepaymentAmount = 600560.60,
                    FundingAmount = 342120.75
                },
                new Loan
                {
                    LoanId = 3,
                    BorrowerFirstName = "Barry",
                    BorrowerLastName = "Gibbs",
                    RepaymentAmount = 1203450.60,
                    FundingAmount = 3457180.75
                });

                context.SaveChanges();
            }
        }
    }
}
