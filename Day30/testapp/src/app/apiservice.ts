import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class Apiservice {

 httpClient = inject(HttpClient);
  getProducts(){
    return this.httpClient.get<any[]>('https://fakestoreapi.com/products');
  }

  loginApiCall(username: string, password: string) {
    const loginData = { username, password };
    return this.httpClient.post('http://localhost:5000/api/Authentication/Login', loginData);
  }
}
