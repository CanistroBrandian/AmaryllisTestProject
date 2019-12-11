import { CarViewModel } from "./car";

export class OrderViewModel {
    constructor(
        public id?: number,
        public carId?: number,
        public userId?: number,
        public startContractDateTime?:  Date,
        public finishedContractDateTime?: Date,
        public comment?: string,
        public Car?: CarViewModel,
        ) { }
}