import { inject } from "@angular/core";
import {  CanActivateFn } from "@angular/router";
import { TokenService } from "../services/token.service";

export const authGuard :CanActivateFn = (route, state) => {
    const token = sessionStorage.getItem('token');  
    const tokenService = inject(TokenService);
     const role = tokenService.getRoleFromToken();
     console.log('User role from token:', role);
    if(token && role === 'Doctor'){
        return true;
    }
    alert('You must be logged in to access this page.');
    return false;
}