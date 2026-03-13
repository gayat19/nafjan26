import { Component } from '@angular/core';
import { Carddirective } from '../carddirective';

@Component({
  selector: 'app-payment',
  imports: [Carddirective],
  templateUrl: './payment.html',
  styleUrl: './payment.css',
})
export class Payment {}
