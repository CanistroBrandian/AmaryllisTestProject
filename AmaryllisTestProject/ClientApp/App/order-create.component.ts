import {Component} from '@angular/core';
import {Router} from '@angular/router';
import {DataService} from './data.service';
import {OrderViewModel} from './order';
import {CarViewModel} from './car';
import {UserViewModel} from "./user";

@Component({
    templateUrl: './order-create.component.html'
})
export class OrderCreateComponent {

    order: OrderViewModel = new OrderViewModel();
    cars: CarViewModel[];
    users: UserViewModel[]; // добавляемый объект

    constructor(private dataService: DataService, private router: Router) {
    }

    ngOnInit() {
        this.dataService.getCarList().subscribe((data: CarViewModel[]) => {
            this.cars = data;
        });
        this.dataService.getUserList().subscribe((data: UserViewModel[]) => {
            this.users = data;
        });
    }

    save() {
        console.log(this.order);
        this.dataService.createOrder(this.order).subscribe(data => this.router.navigateByUrl("/"));
    }
}