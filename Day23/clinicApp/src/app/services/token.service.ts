import { Injectable } from "@angular/core";
import { jwtDecode } from "jwt-decode";

@Injectable({
    providedIn:'root'
})
export class TokenService {
    constructor() {}
    public getRoleFromToken = (): string | null => {
        try {
            const token = sessionStorage.getItem('token');
            if (!token) return null;
            const payload = jwtDecode(token) as { role?: string };
        return payload.role || null;
    } catch (error) {
        return null;
    }
}
}