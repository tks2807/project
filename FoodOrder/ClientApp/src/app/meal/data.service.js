var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Injectable } from '@angular/core';
let DataService = class DataService {
    constructor(http) {
        this.http = http;
        this.url = "/api/meal";
    }
    getAll() {
        return this.http.get(this.url + '/getmeals');
    }
    getMealById(id) {
        return this.http.get(this.url + '/mid/' + id);
    }
    createMeal(meal) {
        return this.http.post(this.url + '/createmeal', meal);
    }
    updateMeal(meal, id) {
        return this.http.put(this.url + '/updatemeal/' + id, meal);
    }
    deleteMeal(id) {
        return this.http.delete(this.url + '/deletemeal/' + id);
    }
};
DataService = __decorate([
    Injectable()
], DataService);
export { DataService };
//# sourceMappingURL=data.service.js.map