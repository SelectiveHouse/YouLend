using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;
using YouLend.WebAPI.Data;
using YouLend.WebAPI.Data.Repositories;
using YouLend.WebAPI.Entities;

namespace YouLend.Tests.Services
{
    public class LoanServiceTests
    {
        [Fact]
        public void Add_Loan()
        {
            //ARRANGE: Create a new in memory DB for testing Add_Loans
            var options = new DbContextOptionsBuilder<WebAPIContext>()
                    .UseInMemoryDatabase(databaseName: "TestDb")
                    .Options;

            //ACT: Using one instance of the context
            using (var context = new WebAPIContext(options))
            {
                var service = new LoanRepository<Loan>(context);
                service.Add(new Loan
                {
                    BorrowerFirstName = "Hello",
                    BorrowerLastName = "Test",
                    RepaymentAmount = 500.7,
                    FundingAmount = 250.55
                });
                context.SaveChanges();
            }

            //ASSERT: Using a seperate instance of the context, verify
            using (var context = new WebAPIContext(options))
            {
                Assert.Equal("Hello",
                    context.Loans.Single().BorrowerFirstName);
            }
        }
    }
}
