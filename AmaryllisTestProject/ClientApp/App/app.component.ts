import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { OrderViewModel } from './order';
import { UserViewModel } from './user';
import { CarViewModel } from './car';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [DataService]
})
export class AppComponent implements OnInit {

    order: OrderViewModel = new OrderViewModel();   // изменяемый товар
    orders: OrderViewModel[];                // массив товаров
    tableMode: boolean = true;          // табличный режим

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.loadOrderViewModel();    // загрузка данных при старте компонента  
    }
    // получаем данные через сервис
    loadOrderViewModel() {
        this.dataService.getOrderList()
            .subscribe((data: OrderViewModel[]) => this.orders = data);
    }
    // сохранение данных
    save() {
        if (this.order.id == null) {
            this.dataService.createOrder(this.order)
                .subscribe((data: OrderViewModel) => this.orders.push(data));
        } else {
            this.dataService.updateOrder(this.order)
                .subscribe(data => this.loadOrderViewModel());
        }
        this.cancel();
    }
    editOrderViewModel(p: OrderViewModel) {
        this.order = p;
    }
    cancel() {
        this.order = new OrderViewModel();
        this.tableMode = true;
    }
    delete(p: OrderViewModel) {
        this.dataService.deleteOrder(p.id)
            .subscribe(data => this.loadOrderViewModel());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
}