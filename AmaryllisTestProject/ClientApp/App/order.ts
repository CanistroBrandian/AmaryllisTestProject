import { CarViewModel } from "./car";
import { UserViewModel } from "./user";

export class OrderViewModel {
    constructor(
        public id?: number,
        public carId?: number,
        public userId?: number,
        public startContractDateTime?:  Date,
        public finishedContractDateTime?: Date,
        public comment?: string,
        public car?: CarViewModel,
        public user?: UserViewModel,
        ) { }
}