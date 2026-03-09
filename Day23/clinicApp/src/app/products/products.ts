import { Component, inject, signal } from '@angular/core';
import { APIService } from '../services/api.service';
import { ProductModel } from '../models/product.model';
import { Product } from '../product/product';


@Component({
  selector: 'app-products',
  imports: [Product],
  templateUrl: './products.html',
  styleUrl: './products.css',
})
export class Products {
  products = signal<ProductModel[]>([]);
  productService = inject(APIService);
  count = signal(0);
  constructor(){
    
  }
  updateCount(value: number){
    this.count.update(count => count + value);
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
