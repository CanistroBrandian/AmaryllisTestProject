import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from './data.service';
import { OrderViewModel } from './order';

@Component({
    templateUrl: './order-create.component.html'
})
export class OrderCreateComponent {

    order: OrderViewModel = new OrderViewModel();    // добавляемый объект
    constructor(private dataService: DataService, private router: Router) { }
    save() {
        this.dataService.createOrder(this.order).subscribe(data => this.router.navigateByUrl("/"));
    }
}