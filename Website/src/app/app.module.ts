import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoansComponent } from './loans/loans.component';
import { LoanComponent } from './loan/loan.component';
import { LoanAddEditComponent } from './loan-add-edit/loan-add-edit.component';
import { LoanService } from './services/loan.service';
import { from } from 'rxjs';

@NgModule({
  declarations: [
    AppComponent,
    LoansComponent,
    LoanComponent,
    LoanAddEditComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [
    LoanService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
