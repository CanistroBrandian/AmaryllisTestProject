﻿import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { OrderViewModel } from './order';

@Component({
    templateUrl: './order-list.component.html',
})
export class OrderListComponent implements OnInit {

    orders: OrderViewModel[];
    fullOrdersList: OrderViewModel[];
    nameUser: string = null;
    sortOn: boolean = false;
    constructor(private dataService: DataService) { }

    filter(newValue: any) {
        if (newValue != "") {
            this.orders = this.fullOrdersList.filter(e => e.userId == newValue);
            console.log(newValue);
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
    }
    delete(id: number) {
        this.dataService.deleteOrder(id).subscribe(data => this.load());
    }
}