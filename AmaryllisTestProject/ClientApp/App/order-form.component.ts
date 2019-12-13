import { Component, Input } from '@angular/core';
import { OrderViewModel } from './order';
@Component({
    selector: "order-form",
    templateUrl: './order-form.component.html'
})
export class OrderFormComponent {
    @Input() order: OrderViewModel;
}