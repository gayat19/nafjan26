import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Login } from './login';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { Apiservice } from '../apiservice';

describe('Login', () => {
  let component: Login;
  let fixture: ComponentFixture<Login>;
  let httpMock: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule,Login],
    }).compileComponents();

  
     TestBed.inject(Apiservice);
     fixture = TestBed.createComponent(Login);
    component = fixture.componentInstance;
      httpMock = TestBed.inject(HttpTestingController);
    await fixture.whenStable();
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

//   it('should show initial data', () => {
//     const compiled = fixture.nativeElement as HTMLElement;
//     expect(compiled.querySelector('p')?.textContent).toContain('Login works!');
//   });
// it('should update data on login', () => {
//     const compiled = fixture.nativeElement as HTMLElement;
//     const button = compiled.querySelector('button');
//     button?.click();
//     fixture.detectChanges();
//     expect(compiled.querySelector('p')?.textContent).toContain('Login button clicked!');
//   });
  
  // it('check the input binding', () => {
  //   fixture.componentRef.setInput('username', 'testuser');
  //   fixture.detectChanges();
  //   const compiled = fixture.nativeElement as HTMLElement;
  //   expect(compiled.querySelector('div')?.textContent).toContain('testuser');
  // });
  it('should call login API on button click', () => {
    const compiled = fixture.nativeElement as HTMLElement;
    const button = compiled.querySelector('button');
    button?.click();
    fixture.detectChanges();
    const req = httpMock.expectOne('http://localhost:5000/api/Authentication/Login');
    expect(req.request.method).toBe('POST');
    expect(req.request.body).toEqual({ username: 'ramu', password: 'ramu123' });
    req.flush({ success: true });
    fixture.detectChanges();
    expect(compiled.querySelector('p')?.textContent).toContain('Login successful!');
  });
});
