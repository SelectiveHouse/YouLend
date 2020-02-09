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
  formTitle: string;
  loanId: number;
  errorMsg: any;
  existingLoan: Loan;

  constructor(private loanService: LoanService, private formBuilder: FormBuilder, private avRoute: ActivatedRoute, private router: Router) {
      const idParam = 'id';
      this.actionType = 'Add';
      this.formTitle = 'borrowerFullName';
      if (this.avRoute.snapshot.params[idParam]) {
        this.loanId = this.avRoute.snapshot.params[idParam];
      }

      this.form = this.formBuilder.group(
        {
          loanId: 0,
          title: ['', [Validators.required]],
          body: ['', [Validators.required]]
        }
      );
  }

  ngOnInit() {
    if (this.loanId > 0) {
      this.actionType = 'Edit',
      this.loanService.getLoan(this.loanId)
        .subscribe(data => (
          this.existingLoan = data,
          this.form.controls[this.formTitle].setValue(data.borrowerFullName)
        ));
    }
  }

  save() {
    if (!this.form.valid) {
      return;
    }
  }
}
