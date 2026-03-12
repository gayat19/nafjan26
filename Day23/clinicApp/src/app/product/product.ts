import { Component, input, output } from '@angular/core';
import { ProductModel } from '../models/product.model';

@Component({
  selector: 'app-product',
  imports: [],
  templateUrl: './product.html',
  styleUrl: './product.css',
})
export class Product {
  productData = input<ProductModel>(new ProductModel());
  addToCartClick = output<number>();

  addToCart(){
    alert(`Added ${this.productData().title} to cart!`);
    this.addToCartClick.emit(this.productData().id);
  }
}
