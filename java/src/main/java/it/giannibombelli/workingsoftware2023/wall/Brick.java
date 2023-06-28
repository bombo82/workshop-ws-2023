package it.giannibombelli.workingsoftware2023.wall;

import java.util.Date;
import java.util.StringJoiner;

public class Brick {
    String message;
    Date creationDate;

    public Brick(String message, Date creationDate) {
        this.message = message;
        this.creationDate = creationDate;
    }

    public String getMessage() {
        return message;
    }

    public Date getCreationDate() {
        return creationDate;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof Brick brick)) return false;

        if (!message.equals(brick.message)) return false;
        return creationDate.equals(brick.creationDate);
    }

    @Override
    public int hashCode() {
        int result = message.hashCode();
        result = 31 * result + creationDate.hashCode();
        return result;
    }

    @Override
    public String toString() {
        return new StringJoiner(", ", Brick.class.getSimpleName() + "[", "]")
                .add("message='" + message + "'")
                .add("creationDate=" + creationDate)
                .toString();
    }
}
