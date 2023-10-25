import { Component, EventEmitter, Input, OnChanges, OnDestroy, OnInit, Output, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subject, takeUntil } from 'rxjs';

import { BranchDto } from 'src/app/models/Branch/branch-dto';
import { BranchService } from './../../services/branch/branch.service';
import { CurrencyDto } from 'src/app/models/Currency/currency-dto';
import { CurrencyService } from 'src/app/services/currency/currency.service';
import { DateValidator } from 'src/app/common/validators/date-validator';
import { NewBranchPayload } from 'src/app/models/Branch/branch';

@Component({
  selector: 'app-form-branch',
  templateUrl: './form-branch.component.html',
  styleUrls: ['./form-branch.component.scss']
})
export class FormBranchComponent implements OnInit, OnChanges, OnDestroy {

  formulario: FormGroup;
  currencies: Array<CurrencyDto> = [];
  today: string;
  private _destroySubject: Subject<void> = new Subject();

  @Input() type: 'create' | 'edit' = 'create';
  @Input() id: string = '';

  @Output() onCreate: EventEmitter<boolean> = new EventEmitter<boolean>();
  constructor(
    private formBuilder: FormBuilder,
    private currencyService: CurrencyService,
    private branchService: BranchService
    ) {
      this.initForm();
      this.today = new Date().toISOString().split('T')[0];
  }

  ngOnInit() {
    this.currencyService.getCurrencies()
    .pipe(takeUntil(this._destroySubject))
    .subscribe(data => {
      this.currencies = data;
    });
  }

  ngOnChanges(changes: SimpleChanges): void {
    throw new Error('Method not implemented.');
  }

  public initForm(data: BranchDto = null): void {
    this.formulario = this.formBuilder.group({
      id: [this.id],
      code: [data ? data.code : '', Validators.required],
      description: [data ? data.description : '', [Validators.required, Validators.maxLength(250)]],
      address: [data ? data.address : '', [Validators.required, Validators.maxLength(250)]],
      identify: [data ? data.identify : '', [Validators.required, Validators.maxLength(50)]],
      createdDate: [data ? data.created : '', [Validators.required, DateValidator.NotPreviousDate]],
      currency: [data ? data.currency : '', [Validators.required]]
    });
  }

  submitForm() {
    console.log(this.formulario);
    if (this.formulario.valid) {
      const data = this.formulario.value
      let payload: NewBranchPayload = {
        ...data,
        createdDate: new Date(data.createdDate).toISOString()
      };
      console.log(payload);
      this.branchService.save(payload)
      .pipe(takeUntil(this._destroySubject))
      .subscribe(res => {
        this.initForm();
        this.onCreate.emit(true);
      });
    }
  }

  ngOnDestroy(): void {
    this._destroySubject.next();
  }
}
