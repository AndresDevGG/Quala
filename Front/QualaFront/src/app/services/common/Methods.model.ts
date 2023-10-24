import { Observable } from "rxjs";

export type Methods = 'get' | 'post' | 'put' | 'patch' | 'delete';

export type HttpResponseType<T> = Observable<T>;
