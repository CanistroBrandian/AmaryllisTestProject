import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataService } from './data.service';
import { OrderViewModel } from './order';
import { CarViewModel } from './car';
import { UserViewModel } from './user';

@Component({
    templateUrl: './order-edit.component.html'
})
export class OrderEditComponent implements OnInit {

    id: number;
    order: OrderViewModel;
    cars: CarViewModel[];
    users: UserViewModel[]
    loaded: boolean = false; // изменяемый объект

    constructor(private dataService: DataService, private router: Router, activeRoute: ActivatedRoute) {
        this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
    }

    ngOnInit() {
        if (this.id) {
            this.dataService.getOrder(this.id)
                .subscribe((data: OrderViewModel) => {
                    this.order = data;
                    if (this.order != null) this.loaded = true;
                });
        }
        this.dataService.getCarList().subscribe((data: CarViewModel[]) => {
            this.cars = data;
        });
        this.dataService.getUserList().subscribe((data: UserViewModel[]) => {
            this.users = data;
        });
    }

    save() {
        this.dataService.updateOrder(this.order).subscribe(data => this.router.navigateByUrl("/"));
    }
}