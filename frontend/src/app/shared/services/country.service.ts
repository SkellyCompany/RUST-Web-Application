import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Country } from '../models/order/country.model';


@Injectable({ providedIn: 'root' })
export class CountryService {

  constructor(private http: HttpClient) { }

  /* GET all countries */
  getCountries(): Observable<Country[]> {
    return this.http.get<Country[]>(environment.apiUrl + '/api/countries');
  }


}
