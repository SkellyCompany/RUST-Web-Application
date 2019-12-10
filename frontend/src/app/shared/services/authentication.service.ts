import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class AuthenticationService {
  private apiUrl = 'https://localhost:44344/api/users';

  constructor(private http: HttpClient) {}

  login(username: string, password: string): Observable<boolean> {
    return this.http.post<any>(this.apiUrl,{ username, password })
      .pipe(map(response => {
        const token = response.token;
        const isAdmin = response.isAdmin;
        if (token) {
          localStorage.setItem('currentUser', JSON.stringify({ username: username, isAdmin: isAdmin,  token: token }));
          return true;
        } else {
          return false;
        }
      }));
  }

  getToken(): string {
    const currentUser = JSON.parse(localStorage.getItem('currentUser'));
    if (currentUser)
    {
      return currentUser.token;
    }
  }

  getUsername(): string {
    const currentUser = JSON.parse(localStorage.getItem('currentUser'));
    return currentUser.username;
  }

  logout(): void {
      localStorage.removeItem('currentUser');
  }
}