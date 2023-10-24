import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListBranchComponent } from './list-branch.component';

describe('ListBranchComponent', () => {
  let component: ListBranchComponent;
  let fixture: ComponentFixture<ListBranchComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListBranchComponent]
    });
    fixture = TestBed.createComponent(ListBranchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
