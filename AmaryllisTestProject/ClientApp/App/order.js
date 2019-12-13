var OrderViewModel = /** @class */ (function () {
    function OrderViewModel(id, carId, userId, startContractDateTime, finishedContractDateTime, comment, car, user) {
        this.id = id;
        this.carId = carId;
        this.userId = userId;
        this.startContractDateTime = startContractDateTime;
        this.finishedContractDateTime = finishedContractDateTime;
        this.comment = comment;
        this.car = car;
        this.user = user;
    }
    return OrderViewModel;
}());
export { OrderViewModel };
//# sourceMappingURL=order.js.map