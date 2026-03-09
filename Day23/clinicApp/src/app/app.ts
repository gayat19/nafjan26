import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Doctor } from './doctor/doctor';
import { Login } from './login/login';
import { Products } from './products/products';
import { Doctors } from './doctors/doctors';
import { Childsample } from './childsample/childsample';
import { Menu } from './menu/menu';

@Component({
  selector: 'app-root',
  imports: [Products,Childsample,Menu,Login],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('clinicApp');
  data = signal("Hello World");
  
  handleNameChange(newName: string) {
    this.data.set(newName);
  }
}
