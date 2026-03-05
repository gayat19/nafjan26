import { Component, signal, Signal } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-doctor',
  imports: [FormsModule],
  templateUrl: './doctor.html',
  styleUrls: ['./doctor.css'],
})
export class Doctor {
  clinicName= signal('City Clinic');
  numberOfClicks = signal(0);
  name: string = 'Dr. Smith';

  constructor() {

  }
  changeName(){
    this.numberOfClicks.update(n => n + 1);
   this.clinicName.set('Downtown Clinic');
  }
  updateName(newName: string){
    this.name = newName;
  }
}
