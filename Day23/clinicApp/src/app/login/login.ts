import { Component } from '@angular/core';
import { LoginModel } from '../models/login.model';
import { FormsModule } from '@angular/forms';
import { APIService } from '../services/api.service';

@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  loginModel:LoginModel;
  constructor(private apiService: APIService) {
    this.loginModel = new LoginModel();
  }
  
  login(){
    console.log(this.loginModel);
    this.apiService.apiLogin(this.loginModel).subscribe({
      next:(response)=>{
        console.log(response);
      },
      error:(error)=>{
        console.error(error);
      },
      complete:()=>{
        console.log('Login request completed');
      }
    });
  }
  reset(){
    this.loginModel = new LoginModel();
  }
}
