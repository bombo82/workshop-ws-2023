export class User {
    private friends: User[] = [];

    public getFriends(): User[] {
        return this.friends;
    }

    public addFriend(user: User): void {
        this.friends.push(user);
    }
}
