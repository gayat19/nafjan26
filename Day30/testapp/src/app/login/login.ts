import { Component, inject, input, signal } from '@angular/core';
import { Apiservice } from '../apiservice';

@Component({
  selector: 'app-login',
  imports: [],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  data = signal( 'Login works!');
  username = input('');
  loginApi = inject(Apiservice);
  login() {
    console.log('Login button clicked');

    this.loginApi.loginApiCall('ramu', 'ramu123')
    .subscribe({
      next:(response) => {
        console.log('Login successful:', response);
        this.data.set('Login successful!');
      },
      error:(error) => {
        console.error('Login failed:', error);
        this.data.set('Login failed!');
      }
  });
  }
}
