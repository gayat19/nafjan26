import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[appCarddirective]',
})
export class Carddirective {
@HostListener('input', ['$event'])
onBlur(event: Event) {
  console.log('Input event detected on card input field:', event);
}

  constructor(private elementRef: ElementRef<HTMLInputElement>) {
    console.log('Card directive initialized for element:');
    elementRef.nativeElement.style.border = '4px solid blue';
    }
}
