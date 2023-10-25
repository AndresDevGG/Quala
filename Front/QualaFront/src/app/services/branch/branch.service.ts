import { BranchDto } from 'src/app/models/Branch/branch-dto';
import { HttpResponseType } from '../common/Methods.model';
import { HttpService } from '../common/http.service';
import { Injectable } from '@angular/core';
import { NewBranchPayload } from 'src/app/models/Branch/branch';

@Injectable({
  providedIn: 'root'
})
export class BranchService {

  private base: string = 'branch';

  constructor(
    private http: HttpService
  ) { }

  public getBranches(): HttpResponseType<Array<BranchDto>> {
    return this.http.sendRequest<Array<BranchDto>>('get',this.base);
  }

  public save(payload: NewBranchPayload): HttpResponseType<void> {
    return this.http.sendRequest<void>('post',this.base,payload);
  }

  public delete(id: string): HttpResponseType<void> {
    return this.http.sendRequest<void>('delete',`${this.base}/${id}`);
  }
}
