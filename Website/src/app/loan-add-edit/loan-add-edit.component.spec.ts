import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LoanAddEditComponent } from './loan-add-edit.component';

describe('LoanAddEditComponent', () => {
  let component: LoanAddEditComponent;
  let fixture: ComponentFixture<LoanAddEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LoanAddEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoanAddEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
