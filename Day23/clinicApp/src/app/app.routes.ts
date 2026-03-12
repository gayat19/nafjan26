import { Routes } from '@angular/router';
import { Products } from './products/products';
import { Login } from './login/login';
import { SearchProduct } from './search-product/search-product';

export const routes: Routes = [
    {path:'products',component:Products},
    {path:'login',component:Login},
    {path:'',component:SearchProduct}
];
