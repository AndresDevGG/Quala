import { Component, EventEmitter, Input, OnChanges, OnDestroy, OnInit, Output, SimpleChanges } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';

import { BranchDto } from 'src/app/models/Branch/branch-dto';
import { BranchService } from './../../services/branch/branch.service';

@Component({
  selector: 'app-list-branch',
  templateUrl: './list-branch.component.html',
  styleUrls: ['./list-branch.component.scss']
})
export class ListBranchComponent implements OnInit, OnChanges, OnDestroy {
  data: Array<BranchDto> = [];
  resultsLength = 0;
  displayedColumns: string[] = ['code', 'description', 'address', 'identify', 'created', 'currency', 'actions'];
  private _destroySubject: Subject<void> = new Subject();
  @Input() reload: boolean = false;
  constructor(
    private branchService: BranchService
  ) {}

  ngOnInit() {
    this.getBranchs();
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (this.reload) {
      this.getBranchs();
    }
  }

  public delete(branch: BranchDto ): void {
    this.branchService.delete(branch.id)
    .pipe(takeUntil(this._destroySubject))
    .subscribe(res => this.getBranchs());

  }

  public getBranchs(): void {
    this.branchService.getBranches()
    .pipe(takeUntil(this._destroySubject))
    .subscribe( res => {
      this.data = res;
      this.resultsLength = res.length;
    });
  }

  ngOnDestroy(): void {
    this._destroySubject.next();
  }
}
