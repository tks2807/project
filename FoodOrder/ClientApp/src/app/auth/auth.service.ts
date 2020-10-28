import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Login } from './login';
import { Register } from './register';

@Injectable()
export class AuthService {
    private url = "/api/auth";

    constructor(private http: HttpClient) {
    }

    login(user: Login) {
        return this.http.post(this.url + '/login', user);
    }

    register(user: Register) {
        return this.http.post(this.url + '/register', user);
    }
}