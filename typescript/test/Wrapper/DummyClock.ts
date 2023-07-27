import {ClockInterface} from '../../src/Wrapper/ClockInterface';

export class DummyClock implements ClockInterface {
    now(): Date {
        throw new Error("not implemented")
    }
}
