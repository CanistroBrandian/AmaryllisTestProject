var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, Input } from '@angular/core';
import { OrderViewModel } from './order';
var OrderFormComponent = /** @class */ (function () {
    function OrderFormComponent() {
    }
    __decorate([
        Input(),
        __metadata("design:type", OrderViewModel)
    ], OrderFormComponent.prototype, "order", void 0);
    __decorate([
        Input(),
        __metadata("design:type", Array)
    ], OrderFormComponent.prototype, "cars", void 0);
    __decorate([
        Input(),
        __metadata("design:type", Array)
    ], OrderFormComponent.prototype, "users", void 0);
    OrderFormComponent = __decorate([
        Component({
            selector: "order-form",
            templateUrl: './order-form.component.html'
        })
    ], OrderFormComponent);
    return OrderFormComponent;
}());
export { OrderFormComponent };
//# sourceMappingURL=order-form.component.js.map