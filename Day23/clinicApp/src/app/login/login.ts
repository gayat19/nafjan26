import { Component, inject } from '@angular/core';
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
  private apiService: APIService = inject(APIService);
  constructor() {
    this.loginModel = new LoginModel();
  }
  
  login(){
    console.log(this.loginModel);
    this.apiService.apiLogin(this.loginModel).subscribe({
      next:(response)=>{
        if(response){
          alert('Login successful!');
        }
      },
      error:(error)=>{
        alert('Login failed: ' + error.message);
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
