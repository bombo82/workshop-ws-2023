import {Brick} from './Brick';
import {NotTestableCallError} from '../Error/NotTestableCallError';
import {User} from '../User/User';

export class WallDAO {
    static findBricksByUser(user: User): Brick[] {
        throw new NotTestableCallError('WallDAO should not be invoked on an unit test.');
    }

    static addBrickToUser(user: User, brick: Brick): void {
        throw new NotTestableCallError('WallDAO should not be invoked on an unit test.');
    }
}
