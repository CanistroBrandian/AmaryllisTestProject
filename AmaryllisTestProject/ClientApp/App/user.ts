﻿export class UserViewModel {
    constructor(
        public id?: number,
        public firstName?: string,
        public lastName?: string,
        public dateOfBirth?: Date,
        public driveNumber?: string,
    ) { }
}