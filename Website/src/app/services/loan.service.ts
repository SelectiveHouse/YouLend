import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Loan } from '../models/loan';

@Injectable({
  providedIn: 'root'
})
export class LoanService {

  appUrl: string;
  apiUrl: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(private http: HttpClient) {
    this.appUrl = environment.appUrl;
    this.apiUrl = 'api/Loans/';
   }

   getLoans(): Observable<Loan[]> {
    return this.http.get<Loan[]>(this.appUrl + this.apiUrl)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
      );
   }

   getLoan(loanId: number): Observable<Loan> {
     return this.http.get<Loan>(this.appUrl + this.apiUrl + loanId)
     .pipe(
       retry(1),
       catchError(this.errorHandler)
     );
   }

   saveLoan(loan): Observable<Loan> {
    return this.http.post<Loan>(this.appUrl + this.apiUrl,
      JSON.stringify(loan),
      this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
   }

   updateLoan(loanId: number, loan): Observable<Loan> {
    return this.http.put<Loan>(this.appUrl + this.apiUrl + loanId,
       JSON.stringify(loan),
       this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
   }

   deleteLoan(loanId: number): Observable<Loan> {
    return this.http.delete<Loan>(this.appUrl + this.apiUrl + loanId)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
   }

   // Generic client/server error handler implementation
   errorHandler(error) {
     let errorMessage = '';
     if (error.error instanceof ErrorEvent) {
       // Get clientside error
       errorMessage = error.error.message;
     } else {
       // Get server-side error
       errorMessage = 'Error Code: ${error.status}\nMessage: ${error.message}';
     }
     console.log(errorMessage);
     return throwError(errorMessage);
   }
}
