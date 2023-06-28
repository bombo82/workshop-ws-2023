export class UserNotLoggedInError extends Error {
    constructor(message?: string) {
        super(message);
        this.name = 'UserNotLoggedInError';
    }
}
