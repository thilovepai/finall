import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../model/product';


@Injectable({
  providedIn: 'root'
})
export class ProductService {
  url: string = "https://localhost:44335/api/TableCustomers";
 
 
  constructor(private http: HttpClient) { }

 
  getProduct() {
    return this.http.get<Product[]>(this.url);
  }

  
  
  createProduct(data) {
    let promise = new Promise((resolve, reject) => {
      let apiURL = this.url;
      this.http.post(apiURL, data)
        .toPromise()
        .then(
          res => {
            console.log(res);
            resolve(data);
          }
        );
    });
    return promise;
  }

  deleteProduct(custId: any) {
    let promise = new Promise((resolve, reject) => {
      let apiURL = this.url;
      this.http.post(apiURL, custId)
        .toPromise()
        .then(
          res => {
            console.log(res);
            resolve(custId);
          }
        );
    });
    console.log(custId);
    return promise
  }

  getOnePerson(custId) {
    return this.http.get<Product[]>(this.url + custId);
  }

  updateProduct(data) {
    let promise = new Promise((resolve, reject) => {
      let apiURL = this.url;
      this.http.post(apiURL, data).toPromise().then(
        res => {
          console.log(res);
          resolve(data);
        }
      );
    });
    return promise;
  }

}