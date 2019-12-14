import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { ProductModel } from '../models/product/productModel.model';
import { FilteredList } from '../models/filteredList.model';
import { AuthenticationService } from './authentication.service';


const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    'Authorization': 'my-auth-token'
  })
};

@Injectable({ providedIn: 'root' })
export class ProductModelService {

  constructor(private http: HttpClient, private authenticationService: AuthenticationService) { }

  /* GET all productModels */
  getProductModels(currentPage: number, itemsPerPage: number, categoryType: string): Observable<FilteredList<ProductModel>> {
    const params = new HttpParams()
    .set('currentPage', currentPage.toString())
    .set('itemsPerPage', itemsPerPage.toString())
    .set('categoryType', categoryType.toString())
    return this.http.get<FilteredList<ProductModel>>(environment.apiUrl + '/api/productmodels', {params: params});
  }

  /* GET productModel */
  getProductModel(id: number): Observable<ProductModel> {
    return this.http.get<ProductModel>(environment.apiUrl + '/api/productmodels' + '/' + id, httpOptions);
  }

}