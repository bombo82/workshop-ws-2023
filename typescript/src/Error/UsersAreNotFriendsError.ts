export class UsersAreNotFriendsError extends Error {
    constructor(message?: string) {
        super(message);
        this.name = 'UsersAreNotFriendsError';
    }
}
