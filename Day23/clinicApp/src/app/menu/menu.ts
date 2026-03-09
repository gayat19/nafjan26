import { Component, signal } from '@angular/core';
import { $userStatus, userLogout } from '../dynamicCommunication/userObservable';

@Component({
  selector: 'app-menu',
  imports: [],
  templateUrl: './menu.html',
  styleUrl: './menu.css',
})
export class Menu {
  uname = signal('');
  constructor(){
    $userStatus.subscribe({
      next:(username)=>{
        this.uname.set(username);
      }
    });
  }
  logout(){
    sessionStorage.removeItem('token');
    userLogout();
  }
}
