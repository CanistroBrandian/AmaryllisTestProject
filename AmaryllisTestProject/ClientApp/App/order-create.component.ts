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

    order: OrderViewModel = new OrderViewModel();    // добавляемый объект
    constructor(private dataService: DataService, private router: Router) {
        this.order.car = new CarViewModel();
        this.order.user = new UserViewModel();
    }

    save() {
        console.log(this.order);
        this.dataService.createOrder(this.order).subscribe(data => this.router.navigateByUrl("/"));
    }
}