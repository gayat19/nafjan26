import { HttpClient } from "@angular/common/http";
import { LoginModel } from "../models/login.model";

export class APIService {
    constructor(private http: HttpClient) {
    }
    apiLogin(loginModel:LoginModel){
        return this.http.post('http://localhost:5000/api/Authentication/Login', loginModel);
    }
}