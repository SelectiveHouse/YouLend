using System;
using System.ComponentModel.DataAnnotations;

namespace YouLend.WebAPI.Entities
{
    public class Loan
    {
        [Key]
        public int LoanId { get; set; }
        [Required]
        public string BorrowerFirstName { get; set; }
        [Required]
        public string BorrowerLastName { get; set; }
        //Not required, will return full name from LoanId
        public string BorrowerFullName => BorrowerFirstName + " " + BorrowerLastName;

        public decimal RepaymentAmount { get; set; }
        public decimal FundingAmount { get; set; }
        //Testing a bit of loan maths :)
        public decimal LeftToPay => RepaymentAmount - FundingAmount;
        public DateTime LoanTakenOut => DateTime.UtcNow;
    }
}
