import { Component, OnInit } from '@angular/core';
import { AuthService } from './auth.service';
import { Login } from './login';
import { Register } from './register';

@Component({
    selector: 'app',
    templateUrl: './auth.component.html',
    providers: [AuthService]
})
export class MealComponent implements OnInit {


    constructor(private dataService: AuthService) { }

    ngOnInit() {
        
    }

    
}