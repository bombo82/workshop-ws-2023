export class Brick {
    message: string;
    creationDate: Date;

    constructor(message: string, creationDate: Date) {
        this.message = message;
        this.creationDate = creationDate;
    }

    getMessage(): string {
        return this.message;
    }

    getCreationDate(): Date {
        return this.creationDate;
    }
}
