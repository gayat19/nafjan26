import { Component, EventEmitter, input, output } from '@angular/core';

@Component({
  selector: 'app-childsample',
  imports: [],
  templateUrl: './childsample.html',
  styleUrl: './childsample.css',
})
export class Childsample {
  username = input<string>("Hello");
  nameChange = output<string>();
  isDisplay = true;

  updateUsername(){
    this.isDisplay = !this.isDisplay;
   alert("Username updated to: Ramu");
    this.nameChange.emit("Ramu");
  }
}
