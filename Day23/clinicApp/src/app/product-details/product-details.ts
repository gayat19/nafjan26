import { Component, inject, signal } from '@angular/core';
import { ProductModel } from '../models/product.model';
import { ActivatedRoute } from '@angular/router';
import { APIService } from '../services/api.service';

@Component({
  selector: 'app-product-details',
  imports: [],
  templateUrl: './product-details.html',
  styleUrl: './product-details.css',
})
export class ProductDetails {
  productId:number;
  product = signal<ProductModel>(new ProductModel())  ;
  router = inject(ActivatedRoute);
  productApi = inject(APIService);
  constructor() {
    this.productId = this.router.snapshot.params['id'] as number;
    this.productApi.apiGetProductById(this.productId).subscribe({
      next:(response:any)=>{
        console.log(response);
        this.product.set(response);
      },
      error:(error)=>{
        alert('Error fetching product details');
      }
    }); 
    
  }
}
