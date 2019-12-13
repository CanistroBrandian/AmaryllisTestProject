import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { OrderListComponent } from './order-list.component';
import { OrderFormComponent } from './order-form.component';
import { OrderCreateComponent } from './order-create.component';
import { OrderEditComponent } from './order-edit.component';
import { NotFoundComponent } from './not-found.component';

import { DataService } from './data.service';

// определение маршрутов
const appRoutes: Routes = [
    { path: '', component: OrderListComponent },
    { path: 'create', component: OrderCreateComponent },
    { path: 'edit/:id', component: OrderEditComponent },
    { path: '**', component: NotFoundComponent }
];

@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule, RouterModule.forRoot(appRoutes)],
    declarations: [AppComponent, OrderListComponent, OrderCreateComponent, OrderEditComponent,
        OrderFormComponent, NotFoundComponent],
    providers: [DataService], // регистрация сервисов
    bootstrap: [AppComponent]
})
export class AppModule { }