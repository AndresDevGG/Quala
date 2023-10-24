import { CurrencyDto } from 'src/app/models/Currency/currency-dto';
import { HttpResponseType } from '../common/Methods.model';
import { HttpService } from '../common/http.service';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CurrencyService {

  private base: string = 'currency';

  constructor(
    private http: HttpService
  ) { }

  public getCurrencies(): HttpResponseType<Array<CurrencyDto>> {
    return this.http.sendRequest<Array<CurrencyDto>>('get',this.base);
  }
}
