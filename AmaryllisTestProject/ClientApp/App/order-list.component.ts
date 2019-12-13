import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { OrderViewModel } from './order';
import { CarViewModel } from './car';
import { UserViewModel } from './user';

@Component({
    templateUrl: './order-list.component.html',
})
export class OrderListComponent implements OnInit {

    orders: OrderViewModel[] = [];
    fullOrdersList: OrderViewModel[] = [];
    searchTerm: string = null;
    sortOn: boolean = false;

    cars: CarViewModel[] = [];
    users: UserViewModel[] = [];

    constructor(private dataService: DataService) { }

    filter(newValue: any) {
        if (newValue != "") {
            this.orders = this.fullOrdersList.filter(e => {
                let car = this.getCarById(e.carId);
                console.log(car);
                let user = this.getUserById(e.userId);
                return car.brand.startsWith(newValue)
                    || ((user.firstName && user.firstName.startsWith(newValue)))
                    || (user.lastName && user.lastName.startsWith(newValue))
            });
        }
        else this.orders = this.fullOrdersList;
    }

    sortAds(sort: boolean) {
        if (sort)
            this.orders.sort;
        else this.orders.reverse;
    }

    public get sortedArray(): OrderViewModel[] {
        return this.orders.reverse();
    }

    ngOnInit() {
        this.load();
    }

    load() {
        this.dataService.getOrderList().subscribe((data: OrderViewModel[]) => { this.orders = data; this.fullOrdersList = data });
        this.dataService.getCarList().subscribe((data: CarViewModel[]) => {
            this.cars = data;
        });
        this.dataService.getUserList().subscribe((data: UserViewModel[]) => {
            this.users = data;
        });
    }

    delete(id: number) {
        this.dataService.deleteOrder(id).subscribe(data => this.load());
    }

    getCarById(carId: number) {
        return this.cars.find(f => f.id == carId);
    }

    getUserById(userId: number) {
        return this.users.find(f => f.id == userId);
    }
}