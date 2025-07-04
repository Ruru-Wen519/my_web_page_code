import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = 'https://my-web-page-code.onrender.com';

  constructor(private http: HttpClient) { }

  getData(): Observable<any> {
    return this.http.get(`${this.apiUrl}/data`, { withCredentials: true });
  }

  postData(data: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/data`, data, { withCredentials: true });
  }
}
