var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { DataService } from './data.service';
var OrderListComponent = /** @class */ (function () {
    function OrderListComponent(dataService) {
        this.dataService = dataService;
        this.orders = [];
        this.fullOrdersList = [];
        this.searchTerm = null;
        this.sortOn = false;
        this.cars = [];
        this.users = [];
    }
    OrderListComponent.prototype.filter = function (newValue) {
        var _this = this;
        if (newValue != "") {
            this.orders = this.fullOrdersList.filter(function (e) {
                var car = _this.getCarById(e.carId);
                console.log(car);
                var user = _this.getUserById(e.userId);
                return car.brand.startsWith(newValue)
                    || ((user.firstName && user.firstName.startsWith(newValue)))
                    || (user.lastName && user.lastName.startsWith(newValue));
            });
        }
        else
            this.orders = this.fullOrdersList;
    };
    OrderListComponent.prototype.sortAds = function (sort) {
        if (sort)
            this.orders.sort;
        else
            this.orders.reverse;
    };
    Object.defineProperty(OrderListComponent.prototype, "sortedArray", {
        get: function () {
            return this.orders.reverse();
        },
        enumerable: true,
        configurable: true
    });
    OrderListComponent.prototype.ngOnInit = function () {
        this.load();
    };
    OrderListComponent.prototype.load = function () {
        var _this = this;
        this.dataService.getOrderList().subscribe(function (data) { _this.orders = data; _this.fullOrdersList = data; });
        this.dataService.getCarList().subscribe(function (data) {
            _this.cars = data;
        });
        this.dataService.getUserList().subscribe(function (data) {
            _this.users = data;
        });
    };
    OrderListComponent.prototype.delete = function (id) {
        var _this = this;
        this.dataService.deleteOrder(id).subscribe(function (data) { return _this.load(); });
    };
    OrderListComponent.prototype.getCarById = function (carId) {
        return this.cars.find(function (f) { return f.id == carId; });
    };
    OrderListComponent.prototype.getUserById = function (userId) {
        return this.users.find(function (f) { return f.id == userId; });
    };
    OrderListComponent = __decorate([
        Component({
            templateUrl: './order-list.component.html',
        }),
        __metadata("design:paramtypes", [DataService])
    ], OrderListComponent);
    return OrderListComponent;
}());
export { OrderListComponent };
//# sourceMappingURL=order-list.component.js.map