package it.giannibombelli.workingsoftware2023.user;

import java.util.ArrayList;
import java.util.List;

public class User {
    private List<User> friends = new ArrayList<User>();

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
