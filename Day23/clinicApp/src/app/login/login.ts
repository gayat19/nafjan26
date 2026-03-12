import { Component, inject, signal } from '@angular/core';
import { LoginModel } from '../models/login.model';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { APIService } from '../services/api.service';
import { myObservable, userLogin } from '../dynamicCommunication/userObservable';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [FormsModule,ReactiveFormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  loginModel:LoginModel;
  myObservableData = signal("Not Started");
  private apiService: APIService = inject(APIService);
  private router = inject(Router);

  loginForm:FormGroup;

  constructor() {
    this.loginModel = new LoginModel();
    this.loginForm = new FormGroup({
      username: new FormControl('',[Validators.required]),
      password: new FormControl('',[Validators.required,
        Validators.minLength(6)
      ])
    });
  }

  
  public get username() : any {
    return this.loginForm.get('username');
  }
  
    public get password() : any {
    return this.loginForm.get('password');
  }


  login(){
    console.log(this.username);
    console.log(this.loginModel);
    if(this.loginForm.invalid)
    {
      alert('Please fill in all required fields with valid data.');
      return;
    }
    this.loginModel.username = this.username.value;
    this.loginModel.password = this.password.value;
    this.apiService.apiLogin(this.loginModel).subscribe({
      next:(response:any)=>{
        if(response){
          sessionStorage.setItem('token', response?.token);
          userLogin(response?.username);
          alert('Login successful!');
          this.router.navigateByUrl('/doctors',{browserUrl:''});
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
