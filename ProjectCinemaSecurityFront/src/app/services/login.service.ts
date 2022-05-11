import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AuthResponse } from '../models/auth-response.model';
import { Login } from '../models/login.model';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient) { }

  getUserById(id: number) : Observable<Login> {
    return this.http.get<Login>(`${environment.apiUrl}/Login/${id}`)
  }

  getAllUsers(): Observable<Login[]> {
    return this.http.get<Login[]>(`${environment.apiUrl}/Login`)
  }

  addUser(login: Login): Observable<Login> {
    return this.http.post<Login>(`${environment.apiUrl}/Login`, login)
  }

  login(login: Login): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(`${environment.apiUrl}/Login/login`, login);
  }

  updateUser(login: Login): Observable<Login> {
    return this.http.put<Login>(`${environment.apiUrl}/Login`, login)
  }

  delete(id: number) {
    return this.http.delete(`${environment.apiUrl}/Login/${id}`);
  }
}
