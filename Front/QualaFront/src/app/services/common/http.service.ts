import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, lastValueFrom } from 'rxjs';

import { Injectable } from '@angular/core';
import { Methods } from './Methods.model';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  private host = 'https://localhost:7176/api/';

  constructor(private http: HttpClient) {}

  sendRequest<T>(
    type: Methods,
    url: string,
    payload: any = {}
  ): Observable<T> {
    let headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    const [token, campus] = [localStorage.getItem('token'), localStorage.getItem('campus')]

    if (token)
      headers = headers.append('Authorization', `Bearer ${token}`);
    if (campus)
      headers = headers.append('Campus', campus);

    let observable$;

    if (type === 'get')
      observable$ = this.http.get<T>(this.host + url, { headers });

    if (type === 'post')
      observable$ = this.http.post<T>(this.host + url, payload, { headers });

    if (type === 'put')
      observable$ = this.http.put<T>(this.host + url, payload != null ? payload : {}, {headers,});

    if (type === 'delete')
      observable$ = this.http.delete<T>(this.host + url, { headers });

    // @ts-ignore: Object is possibly 'null'.
    return observable$;
  }
}
