import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Doctor } from './doctor/doctor';
import { Login } from './login/login';
import { Products } from './products/products';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,Products],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('clinicApp');
}
