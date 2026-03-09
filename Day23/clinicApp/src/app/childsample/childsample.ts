import { Component, input } from '@angular/core';

@Component({
  selector: 'app-childsample',
  imports: [],
  templateUrl: './childsample.html',
  styleUrl: './childsample.css',
})
export class Childsample {
  username = input<string>("Hello");
}
