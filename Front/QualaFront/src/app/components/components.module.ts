import { CommonModule } from '@angular/common';
import { FormBranchComponent } from './form-branch/form-branch.component';
import { ListBranchComponent } from './list-branch/list-branch.component';
import { MaterialModule } from './material.module';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    FormBranchComponent,
    ListBranchComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MaterialModule
  ],
  exports: [
    FormBranchComponent,
    ListBranchComponent
  ]
})
export class ComponentsModule { }
