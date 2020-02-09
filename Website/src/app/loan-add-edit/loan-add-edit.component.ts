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
  constructor(private loanService: LoanService, private formBuilder: FormBuilder, private avRoute: ActivatedRoute, private router: Router) {
    
  }

  ngOnInit() {
  }

  cancel() {
    this.router.navigate(['/']);
  }

}
