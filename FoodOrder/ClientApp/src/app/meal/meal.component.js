var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from '@angular/core';
import { DataService } from './data.service';
import { Meal } from './meal';
let MealComponent = class MealComponent {
    constructor(dataService) {
        this.dataService = dataService;
        this.meal = new Meal();
        this.tableMode = true;
    }
    ngOnInit() {
        this.loadMeals();
    }
    loadMeals() {
        this.dataService.getAll()
            .subscribe((data) => this.meals = data);
    }
    save() {
        if (this.meal.mealId == null) {
            this.dataService.createMeal(this.meal)
                .subscribe((data) => this.meals.push(data));
        }
        else {
            this.dataService.updateMeal(this.meal, this.meal.mealId)
                .subscribe(data => this.loadMeals());
        }
        this.cancel();
    }
    editMeals(m, id) {
        this.meal = m;
        this.meal.mealId = id;
    }
    cancel() {
        this.meal = new Meal();
        this.tableMode = true;
    }
    delete(m) {
        this.dataService.deleteMeal(m.mealId)
            .subscribe(data => this.loadMeals());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
};
MealComponent = __decorate([
    Component({
        selector: 'app',
        templateUrl: './meal.component.html',
        providers: [DataService]
    })
], MealComponent);
export { MealComponent };
//# sourceMappingURL=meal.component.js.map