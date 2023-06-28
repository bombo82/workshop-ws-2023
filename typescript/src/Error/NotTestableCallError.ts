export class NotTestableCallError extends Error {
    constructor(message: string) {
        super(message);
        this.name = 'NotTestableCallError';
    }
}
