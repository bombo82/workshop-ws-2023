import {User} from './User';
import {NotTestableCallError} from '../Error/NotTestableCallError';

export class UserSession {
    private static readonly userSession: UserSession = new UserSession();

    private constructor() {
    }

    public static getInstance(): UserSession {
        return UserSession.userSession;
    }

    public getLoggedUser(): User | undefined {
        throw new NotTestableCallError('UserSession.getLoggedUser() should not be called in an unit test');
    }
}
