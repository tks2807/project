import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Meal } from './meal';

@Component({
    selector: 'app',
    templateUrl: './meal.component.html',
    providers: [DataService]
})
export class MealComponent implements OnInit {

    meal: Meal = new Meal();
    meals: Meal[];
    tableMode: boolean = true;

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.loadMeals();
    }

    loadMeals() {
        this.dataService.getAll()
            .subscribe((data: Meal[]) => this.meals = data);
    }

    save() {
        if (this.meal.mealId == null) {
            this.dataService.createMeal(this.meal)
                .subscribe((data: Meal) => this.meals.push(data));
        } else {
            this.dataService.updateMeal(this.meal, this.meal.mealId)
                .subscribe(data => this.loadMeals());
        }
        this.cancel();
    }
    editMeals(m: Meal, id: number) {
        this.meal = m;
        this.meal.mealId = id;
    }
    cancel() {
        this.meal = new Meal();
        this.tableMode = true;
    }
    delete(m: Meal) {
        this.dataService.deleteMeal(m.mealId)
            .subscribe(data => this.loadMeals());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
}