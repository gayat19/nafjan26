import { Component, inject, signal } from '@angular/core';
import { APIService } from '../services/api.service';
import { ProductModel } from '../models/product.model';


@Component({
  selector: 'app-products',
  imports: [],
  templateUrl: './products.html',
  styleUrl: './products.css',
})
export class Products {
  products = signal<ProductModel[]>([]);
  productService = inject(APIService);
  constructor(){
    
  }
  getProducts(){
    console.log("Hello")
    this.productService.apiGetProducts().subscribe({
      next:(data:any)=>{
        this.products.set(data?.products || []);
        console.log(this.products)
      },
      error:(err)=>{
        console.error(err.message);
      },
      complete:()=>{
        console.log("I am complete")
      }
    })
  }
}
