var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from '@angular/core';
var AppComponent = /** @class */ (function () {
    function AppComponent() {
    }
    AppComponent = __decorate([
        Component({
            selector: 'app',
            templateUrl: './app.component.html'
        })
    ], AppComponent);
    return AppComponent;
}());
export { AppComponent };
//    order: OrderViewModel = new OrderViewModel();   // изменяемый товар
//    orders: OrderViewModel[];                // массив товаров
//    tableMode: boolean = true;          // табличный режим
//    constructor(private dataService: DataService) { }
//    ngOnInit() {
//        this.loadOrderViewModel();    // загрузка данных при старте компонента  
//    }
//    // получаем данные через сервис
//    loadOrderViewModel() {
//        this.dataService.getOrderList()
//            .subscribe((data: OrderViewModel[]) => this.orders = data);
//    }
//    // сохранение данных
//    save() {
//        if (this.order.id == null) {
//            this.dataService.createOrder(this.order)
//                .subscribe((data: HttpResponse<OrderViewModel>) => {
//                    console.log(data); this.orders.push(data.body);
//                })       
//        } else {
//            this.dataService.updateOrder(this.order)
//                .subscribe(data => this.loadOrderViewModel());
//        }
//        this.cancel();
//    }
//    editOrderViewModel(p: OrderViewModel) {
//        this.order = p;
//    }
//    cancel() {
//        this.order = new OrderViewModel();
//        this.tableMode = true;
//    }
//    delete(p: OrderViewModel) {
//        this.dataService.deleteOrder(p.id)
//            .subscribe(data => this.loadOrderViewModel());
//    }
//    add() {
//        this.cancel();
//        this.tableMode = false;
//    }
//}
//# sourceMappingURL=app.component.js.map