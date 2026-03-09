import { Component, inject, signal } from '@angular/core';
import { LoginModel } from '../models/login.model';
import { FormsModule } from '@angular/forms';
import { APIService } from '../services/api.service';
import { myObservable, userLogin } from '../dynamicCommunication/userObservable';

@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  loginModel:LoginModel;
  myObservableData = signal("Not Started");
  private apiService: APIService = inject(APIService);
  constructor() {
    this.loginModel = new LoginModel();
  }
  
  login(){
    console.log(this.loginModel);
    
    this.apiService.apiLogin(this.loginModel).subscribe({
      next:(response:any)=>{
        if(response){
          sessionStorage.setItem('token', response?.token);
          userLogin(response?.username);
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
