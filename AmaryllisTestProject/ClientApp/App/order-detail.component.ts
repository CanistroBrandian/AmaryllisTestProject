import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DataService } from './data.service';
import { OrderViewModel } from './order';

@Component({
    templateUrl: './order-detail.component.html',
    providers: [DataService]
})
export class OrderDetailComponent implements OnInit {

    id: number;
    order: OrderViewModel;
    loaded: boolean = false;

    constructor(private dataService: DataService, activeRoute: ActivatedRoute) {
        this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
    }

    ngOnInit() {
        if (this.id)
            this.dataService.getOrder(this.id)
                .subscribe((data: OrderViewModel) => { this.order = data; this.loaded = true; });
    }
}