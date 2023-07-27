import {ClockInterface} from '../../src/Wrapper/ClockInterface';

export class StubClock implements ClockInterface {
    now(): Date {
        return new Date(0);
    }
}
