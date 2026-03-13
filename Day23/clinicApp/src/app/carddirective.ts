import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[appCarddirective]',
})
export class Carddirective {
@HostListener('input', ['$event'])
onBlur(event: Event) {
  var inputElement = event.target as HTMLInputElement;
  
  if(inputElement.value.length === 16) {
    inputElement.style.border = '4px solid green';
    let formattedValue = '';
    for(let i = 0; i < inputElement.value.length; i=i+4) {
      formattedValue += inputElement.value.substring(i, i+4) + ' ';
    }
    inputElement.value = formattedValue.trim();
  } else {
    inputElement.style.border = '4px solid red';
  }
}

  constructor() {
    // console.log('Card directive initialized for element:');
    // elementRef.nativeElement.style.border = '4px solid blue';
    }
}
