import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormBranchComponent } from './form-branch.component';

describe('FormBranchComponent', () => {
  let component: FormBranchComponent;
  let fixture: ComponentFixture<FormBranchComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FormBranchComponent]
    });
    fixture = TestBed.createComponent(FormBranchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
