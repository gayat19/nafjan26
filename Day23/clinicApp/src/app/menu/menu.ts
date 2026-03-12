import { Component, signal } from '@angular/core';
import { $userStatus, userLogout } from '../dynamicCommunication/userObservable';
import {  RouterLink } from "@angular/router";


@Component({
  selector: 'app-menu',
  imports: [RouterLink],
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
