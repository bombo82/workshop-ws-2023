package it.giannibombelli.workingsoftware2023.wrapper;

import java.util.Date;

public class StubClock implements Clock {
    @Override
    public Date now() {
        return new Date(0);
    }
}
