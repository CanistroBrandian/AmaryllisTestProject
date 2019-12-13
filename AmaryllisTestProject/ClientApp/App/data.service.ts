import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { OrderViewModel } from './order';
import { CarViewModel } from './car';
import { UserViewModel } from './user';

@Injectable()
export class DataService {

    private orderUrl = "/api/orders";
    private userUrl = "/api/users";
    private carUrl = "/api/cars";

    constructor(private http: HttpClient) {
    }
    //Order
    getOrderList() {
        return this.http.get(this.orderUrl);
    }

    getOrder(id: number) {
        return this.http.get(this.orderUrl + '/' + id);
    }

    createOrder(order: OrderViewModel) {
        return this.http.post(this.orderUrl, order, { observe: 'response' });
    }
    updateOrder(order: OrderViewModel) {

        return this.http.put(this.orderUrl + '/' + order.id, order,
            { observe: 'response', responseType: 'text' });
    }
    deleteOrder(id: number) {
        return this.http.delete(this.orderUrl + '/' + id);
    }

    //User
    getUserList() {
        return this.http.get(this.userUrl);
    }

    createUser(user: UserViewModel) {
        return this.http.post(this.userUrl, user);
    }
    updateUser(user: UserViewModel) {

        return this.http.put(this.userUrl + '/' + user.id, user);
    }
    deleteUser(id: number) {
        return this.http.delete(this.userUrl + '/' + id);
    }

    //Car
    getCarList() {
        return this.http.get(this.carUrl);
    }

    createCar(car: CarViewModel) {
        return this.http.post(this.carUrl, car);
    }
    updateCar(car: CarViewModel) {

        return this.http.put(this.carUrl + '/' + car.id, car);
    }
    deleteCar(id: number) {
        return this.http.delete(this.carUrl + '/' + id);
    }
}