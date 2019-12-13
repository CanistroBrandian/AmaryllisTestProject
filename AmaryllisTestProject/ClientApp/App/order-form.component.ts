import { Component, Input } from '@angular/core';
import { OrderViewModel } from './order';
import { CarViewModel } from './car';
import { UserViewModel } from './user';
@Component({
    selector: "order-form",
    templateUrl: './order-form.component.html'
})
export class OrderFormComponent {
    @Input() order: OrderViewModel;
    @Input() cars: CarViewModel[];
    @Input() users: UserViewModel[];
}