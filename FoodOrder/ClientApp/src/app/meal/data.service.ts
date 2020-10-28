import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Meal } from './meal';

@Injectable()
export class DataService {
    private url = "/api/meal";

    constructor(private http: HttpClient) {
    }

    getAll() {
        return this.http.get(this.url + '/getmeals');
    }

    getMealById(id: number) {
        return this.http.get(this.url + '/mid/' + id);
    }

    createMeal(meal: Meal) {
        return this.http.post(this.url + '/createmeal', meal);
    }

    updateMeal(meal: Meal, id: number) {
        return this.http.put(this.url + '/updatemeal/' + id, meal);
    }

    deleteMeal(id: number) {
        return this.http.delete(this.url + '/deletemeal/' + id);
    }
}