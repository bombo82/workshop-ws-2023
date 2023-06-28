export class User {
    private friends: User[] = [];

    public getFriends(): User[] {
        return this.friends;
    }

    public addFriend(user: User): void {
        this.friends.push(user);
    }

    isFriendWith(anotherUser: User): boolean {
        return !!this.friends.find(friend => friend === anotherUser);
    }
}
