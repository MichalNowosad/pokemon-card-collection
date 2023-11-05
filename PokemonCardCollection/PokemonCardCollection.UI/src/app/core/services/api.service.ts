import { HttpClient } from '@angular/common/http';
import { LocalizedString } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { Params } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private readonly apiUrl: string = environment.baseApiUrl;
  
  constructor(private readonly httpClient: HttpClient) { }

  get<T>(url: string, params: any): Observable<T> {
    return this.httpClient.get<T>(`${this.apiUrl}${url}`, { params: params});
  }

  post<T>(url: string, data: any): Observable<T> {
    return this.httpClient.post<T>(`${this.apiUrl}${url}`, data);
  }

  put<T>(url: string, data: any): Observable<T> {
    return this.httpClient.put<T>(`${this.apiUrl}${url}`, data);
  }

  delete(url: string, data: any): Observable<any> {
    return this.httpClient.delete(`${this.apiUrl}${url}`, data);
  }
}
