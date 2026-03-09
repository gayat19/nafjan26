import { Component, input } from '@angular/core';
import { ProductModel } from '../models/product.model';

@Component({
  selector: 'app-product',
  imports: [],
  templateUrl: './product.html',
  styleUrl: './product.css',
})
export class Product {
  productData = input<ProductModel>(new ProductModel());
}
