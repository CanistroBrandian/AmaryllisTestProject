﻿import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataService } from './data.service';
import { OrderViewModel } from './order';

@Component({
    templateUrl: './order-edit.component.html'
})
export class OrderEditComponent implements OnInit {

    id: number;
    order: OrderViewModel;    // изменяемый объект
    loaded: boolean = false;

    constructor(private dataService: DataService, private router: Router, activeRoute: ActivatedRoute) {
        this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
    }

    ngOnInit() {
        if (this.id)
            this.dataService.getOrder(this.id)
                .subscribe((data: OrderViewModel) => {
                    this.order = data;
                    if (this.order != null) this.loaded = true;
                });
    }

    save() {
        this.dataService.updateOrder(this.order).subscribe(data => this.router.navigateByUrl("/"));
    }
}