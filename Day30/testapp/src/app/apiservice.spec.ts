import { TestBed } from '@angular/core/testing';

import { Apiservice } from './apiservice';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

describe('Apiservice', () => {
  let service: Apiservice;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
       imports: [HttpClientTestingModule],
    });
    service = TestBed.inject(Apiservice);
     httpMock = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should call the fake store API and return products', (done) => {
    service.getProducts().subscribe((products) => {
      expect(products).toBeTruthy();
      expect(Array.isArray(products)).toBe(true);
      expect(products.length).toBeGreaterThan(0);
    });
  });

  it('should return mocked products', (done) => {

    service.getProducts().subscribe((products) => {
      expect(products).toEqual([
        { id: 1, title: 'Product 1', price: 10 },
        { id: 2, title: 'Product 2', price: 20 },
      ]);
      const req = httpMock.expectOne('https://fakestoreapi.com/products');
    expect(req.request.method).toBe('GET');
    req.flush([
      { id: 1, title: 'Product 1', price: 10 },
      { id: 2, title: 'Product 2', price: 20 },
    ]);
    httpMock.verify();
    });
  });
});
