import { Component, inject, signal } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import {  debounceTime, switchMap } from 'rxjs';
import { APIService } from '../services/api.service';
import { ProductModel } from '../models/product.model';

@Component({
  selector: 'app-search-product',
  imports: [ReactiveFormsModule],
  templateUrl: './search-product.html',
  styleUrl: './search-product.css',
})
export class SearchProduct {
  searchForm:FormGroup;
  apiService = inject(APIService);
  products = signal<ProductModel[]>([]);

  constructor() {
    this.searchForm = new FormGroup({
      productName: new FormControl('')
    });
  }

public get productName() : any {
  return this.searchForm.get('productName');
}

  ngOnInit() {
    this.productName.valueChanges.pipe(
      debounceTime(500),
      switchMap((value:any) => this.apiService.apiGetSearchedProducts(value as string))
    ).subscribe({
      next: (response:any) => {
        this.products.set(response?.products);
      },
      error: (error:any) => {
        console.error('Error fetching products:', error);
      }
  });
  }

 
  searchProducts(){}
}
