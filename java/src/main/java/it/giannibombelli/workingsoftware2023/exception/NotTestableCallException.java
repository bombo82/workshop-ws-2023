package it.giannibombelli.workingsoftware2023.exception;

import java.io.Serial;

public class NotTestableCallException extends RuntimeException {

    @Serial
    private static final long serialVersionUID = 2490168334070927102L;

    public NotTestableCallException() {
        super();
    }

    public NotTestableCallException(String message, Throwable cause) {
        super(message, cause);
    }

    public NotTestableCallException(String message) {
        super(message);
    }

    public NotTestableCallException(Throwable cause) {
        super(cause);
    }
}
