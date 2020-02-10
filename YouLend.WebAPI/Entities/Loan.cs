using System;
using System.ComponentModel.DataAnnotations;

namespace YouLend.WebAPI.Entities
{
    public class Loan
    {
        [Key]
        public int LoanId { get; set; }
        public string BorrowerFirstName { get; set; }
        public string BorrowerLastName { get; set; }
        //Not required, will return full name from LoanId
        public string BorrowerFullName => BorrowerFirstName + " " + BorrowerLastName;

        public double RepaymentAmount { get; set; }
        public double FundingAmount { get; set; }
        //Testing a bit of loan maths :)
        public double LeftToPay => RepaymentAmount - FundingAmount;
        public DateTime LoanTakenOut => DateTime.UtcNow;
    }
}
