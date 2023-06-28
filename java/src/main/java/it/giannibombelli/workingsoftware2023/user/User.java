package it.giannibombelli.workingsoftware2023.user;

import java.util.ArrayList;
import java.util.List;

public class User {
    private final List<User> friends = new ArrayList<>();

    public List<User> getFriends() {
        return friends;
    }

    public void addFriend(User user) {
        friends.add(user);
    }

    public boolean isFriendWith(User anotherUser) {
        return friends.contains(anotherUser);
    }
}
