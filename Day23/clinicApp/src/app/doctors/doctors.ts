import { Component, inject } from '@angular/core';
import { APIService } from '../services/api.service';

@Component({
  selector: 'app-doctors',
  imports: [],
  templateUrl: './doctors.html',
  styleUrl: './doctors.css',
})
export class Doctors {
  apiService = inject(APIService);
  getDoctors(){
    this.apiService.apiGetDoctors().subscribe({
      next:(response)=>{
        console.log(response);
      },
      error:(error)=>{
        alert('Failed to fetch doctors: ' + error.message);
      },
      complete:()=>{
        console.log('Get doctors request completed');
      }
    });
  }
}
