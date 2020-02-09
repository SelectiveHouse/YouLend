import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoanComponent } from './loan/loan.component';
import { LoansComponent } from './loans/loans.component';
import { LoanAddEditComponent } from './loan-add-edit/loan-add-edit.component';

const routes: Routes = [
  { path: '', component: LoansComponent, pathMatch: 'full' },
  { path: 'loan/:id', component: LoanComponent },
  { path: 'add', component: LoanAddEditComponent },
  { path: 'loan/edit/:id', component: LoanAddEditComponent },
  { path: '**', redirectTo: '/'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
