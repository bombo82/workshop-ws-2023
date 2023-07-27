package it.giannibombelli.workingsoftware2023.wrapper;

import java.util.Date;

public class DummyClock implements Clock {

    @Override
    public Date now() {
        throw new UnsupportedOperationException();
    }
}
