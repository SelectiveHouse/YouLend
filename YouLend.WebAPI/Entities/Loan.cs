using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YouLend.WebAPI.Entities
{
    public class Loan
    {
        [Key]
        public Guid LoanId { get; set; }
        [Required]
        public string BorrowerFirstName { get; set; }
        [Required]
        public string BorrowerLastName { get; set; }
        //Not required, will return full name from LoanId
        public string BorrowerFullName => BorrowerFirstName + " " + BorrowerLastName;

        public decimal RepaymentAmount { get; set; }
        public decimal FundingAmount { get; set; }
    }
}
