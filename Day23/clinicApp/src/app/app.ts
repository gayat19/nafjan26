import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Doctor } from './doctor/doctor';
import { Login } from './login/login';
import { Products } from './products/products';
import { Doctors } from './doctors/doctors';
import { Childsample } from './childsample/childsample';
import { Menu } from './menu/menu';
import { SearchProduct } from './search-product/search-product';

@Component({
  selector: 'app-root',
  imports: [Products,Childsample,Menu,Login,SearchProduct],
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
