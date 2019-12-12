import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { map } from 'rxjs/operators';


@Injectable()
export class AuthenticationService {

  constructor(private http: HttpClient) {}

  login(username: string, password: string): Observable<boolean> {
    return this.http.post<any>(environment.apiUrl + '/api/users',{ username, password })
      .pipe(map(response => {
        const token = response.token;
        if (token) {
          localStorage.setItem('currentUser', JSON.stringify({ username: username,  token: token }));
          return true;
        }
        return false;
      }));
  }

  getToken(): string {
    const currentUser = JSON.parse(localStorage.getItem('currentUser'));
    if (currentUser)
    {
      return currentUser.token;
    }
  }

  isTokenExpired(): boolean {
    return;
  }

  logout(): void {
    localStorage.removeItem('currentUser');
  }
}