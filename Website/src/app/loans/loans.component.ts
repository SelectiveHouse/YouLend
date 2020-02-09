import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { LoanService } from '../services/loan.service';
import { Loan } from '../models/loan';

@Component({
  selector: 'app-loans',
  templateUrl: './loans.component.html',
  styleUrls: ['./loans.component.scss']
})
export class LoansComponent implements OnInit {
  loans$: Observable<Loan[]>;

  constructor(private loanService: LoanService) {
   }

  ngOnInit() {
    this.loadLoans();
  }

  loadLoans() {
    this.loans$ = this.loanService.getLoans();
  }

  delete(loanId) {
    const answer = confirm('Do you want to delete loan: ' + loanId);
    if (answer) {
      this.loanService.deleteLoan(loanId).subscribe((data) => {
        this.loadLoans();
      });
    }
  }
}
