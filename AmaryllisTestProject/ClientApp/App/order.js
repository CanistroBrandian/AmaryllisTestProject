var OrderViewModel = /** @class */ (function () {
    function OrderViewModel(id, carId, userId, startContractDateTime, finishedContractDateTime, comment, Car, User) {
        this.id = id;
        this.carId = carId;
        this.userId = userId;
        this.startContractDateTime = startContractDateTime;
        this.finishedContractDateTime = finishedContractDateTime;
        this.comment = comment;
        this.Car = Car;
        this.User = User;
    }
    return OrderViewModel;
}());
export { OrderViewModel };
//# sourceMappingURL=order.js.map