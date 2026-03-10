import { HttpClient } from "@angular/common/http";
import { LoginModel } from "../models/login.model";
import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class APIService {
    constructor(private http: HttpClient) {
    }
    apiLogin(loginModel:LoginModel){
        return this.http.post('http://localhost:5000/api/Authentication/Login', loginModel);
    }

    apiGetProducts(){
        return this.http.get('https://dummyjson.com/products');
    }
    apiGetSearchedProducts(searchText:string){
        return this.http.get('https://dummyjson.com/products/search?q=' + searchText);
    }
    apiGetDoctors(){
        // var token = sessionStorage.getItem('token');
        // const headers ={
        //     'Authorization': `Bearer ${token}`,
        //     'Content-Type': 'application/json'
        // }
        return this.http.post
        ('http://localhost:5000/api/Doctor/GetDoctors', 
            {"pageNumber": 1,
            "pageSize": 3}
          
        );
    }
}