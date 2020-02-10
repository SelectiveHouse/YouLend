import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { LoanService } from '../services/loan.service';
import { Loan } from '../models/loan';

@Component({
  selector: 'app-loan-add-edit',
  templateUrl: './loan-add-edit.component.html',
  styleUrls: ['./loan-add-edit.component.scss']
})
export class LoanAddEditComponent implements OnInit {
  form: FormGroup;
  actionType: string;
  loanId: number;
  formFirstName: string;
  formLastName: string;
  formRepayment: string;
  formFunding: string;
  errorMessage: any;
  existingLoan: any;
  constructor(private loanService: LoanService, private formBuilder: FormBuilder, private avRoute: ActivatedRoute, private router: Router) {
    const idParam = 'id';
    this.actionType = 'Add';
    this.formFirstName = 'borrowerFirstName';
    this.formLastName = 'borrowerLastName';
    this.formFunding = 'fundingAmount';
    this.formRepayment = 'repaymentAmount';
    if (this.avRoute.snapshot.params[idParam]) {
      this.loanId = this.avRoute.snapshot.params[idParam];
    }

    this.form = this.formBuilder.group(
      {
        idParam: 0,
        borrowerFirstName: null,
        borrowerLastName: null,
        fundingAmount: null,
        repaymentAmount: null
      }
    );
  }

  ngOnInit() {
    if (this.loanId > 0) {
      this.actionType = 'Edit';
      this.loanService.getLoan(this.loanId)
        .subscribe(data => (
          this.existingLoan = data,
          this.form.controls[this.formFirstName].setValue(data.borrowerFirstName),
          this.form.controls[this.formLastName].setValue(data.borrowerLastName),
          this.form.controls[this.formRepayment].setValue(data.repaymentAmount),
          this.form.controls[this.formFunding].setValue(data.fundingAmount)
        ));
    }
  }

  save() {
    if (!this.form.valid) {
      return;
    }

    if (this.actionType === 'Add') {
      const loan: Loan = {
        loanTakenOut: new Date(),
        borrowerFirstName: this.form.get(this.formFirstName).value,
        borrowerLastName: this.form.get(this.formLastName).value,
        borrowerFullName: this.form.get(this.formFirstName).value + this.form.get(this.formLastName).value,
        repaymentAmount: +(this.form.get(this.formRepayment).value),
        fundingAmount: +(this.form.get(this.formFunding).value),
        leftToPay: +((this.form.get(this.formRepayment).value) - (this.form.get(this.formFunding).value)),
      };

      this.loanService.saveLoan(loan)
        .subscribe((data) => {
          this.router.navigate(['/loan', data.loanId]);
        });
    }

    if (this.actionType === 'Edit') {
      const loan: Loan = {
        loanId: this.existingLoan.loanId,
        loanTakenOut: this.existingLoan.loanTakenOut,
        borrowerFirstName: this.existingLoan.borrowerFirstName,
        borrowerLastName: this.existingLoan.borrowerLastName,
        borrowerFullName: this.existingLoan.borrowerFullName,
        fundingAmount: +(this.form.get(this.formFunding).value),
        repaymentAmount: +(this.form.get(this.formRepayment).value),
        leftToPay: +(this.form.get(this.formRepayment).value - this.form.get(this.formFunding).value)
      };
      this.loanService.updateLoan(loan.loanId, loan)
        .subscribe((data) => {
          this.router.navigate([this.router.url]);
        });
    }
  }

  cancel() {
    this.router.navigate(['/']);
  }

  get borrowerFirstName() { return this.form.get(this.formFirstName); }
  get borrowerLastName() { return this.form.get(this.formLastName); }
  get fundingAmount() { return this.form.get(this.formFunding); }
  get repaymentAmount() { return this.form.get(this.formRepayment); }
}
