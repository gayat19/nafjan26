import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Doctor } from './doctor/doctor';
import { Login } from './login/login';
import { Products } from './products/products';
import { Doctors } from './doctors/doctors';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,Login,Doctors],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('clinicApp');
}
