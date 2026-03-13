import { Routes } from '@angular/router';
import { Products } from './products/products';
import { Login } from './login/login';
import { SearchProduct } from './search-product/search-product';
import { Doctors } from './doctors/doctors';
import { authGuard } from './guards/authguard';
import { ProductDetails } from './product-details/product-details';
import { Childsample } from './childsample/childsample';
import { Payment } from './payment/payment';

export const routes: Routes = [
    {path:'products',component:Products},
    {path:'products/:id',component:ProductDetails},
    {path:'login',component:Login},
    {path:'',component:Payment},
    {path:'search',component:SearchProduct,children:[
        {path:':id',component:ProductDetails},
        {path:'child',component:Childsample}
    ]},
    {path:'doctors',
        component:Doctors,
        canActivate:[authGuard]
    }
];
