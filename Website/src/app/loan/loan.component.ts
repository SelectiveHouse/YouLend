import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { LoanService } from '../services/loan.service';
import { Loan } from '../models/loan';

@Component({
  selector: 'app-loan',
  templateUrl: './loan.component.html',
  styleUrls: ['./loan.component.scss']
})
export class LoanComponent implements OnInit {
  loan$: Observable<Loan>;
  loanId: number;

  constructor(private loanService: LoanService, private avRoute: ActivatedRoute) {
      const idParam = 'id';
      if (this.avRoute.snapshot.params[idParam]) {
        this.loanId = this.avRoute.snapshot.params[idParam];
      }
   }

  ngOnInit() {
    this.loadLoan();
  }

  loadLoan() {
    this.loan$ = this.loanService.getLoan(this.loanId);
  }
}
