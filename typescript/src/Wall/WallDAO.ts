import {Brick} from './Brick';
import {NotTestableCallError} from '../Error/NotTestableCallError';
import {User} from '../User/User';
import {WallDAOInterface} from './WallDAOInterface';

export class WallDAO implements WallDAOInterface {
    /**
     * @deprecated
     */
    static addBrickToUser(user: User, brick: Brick): void {
        throw new NotTestableCallError('WallDAO should not be invoked on an unit test.');
    }

    /**
     * @deprecated
     */
    static findBricksByUser(user: User): Brick[] {
        throw new NotTestableCallError('WallDAO should not be invoked on an unit test.');
    }

    getBricks(user: User): Brick[] {
        return WallDAO.findBricksByUser(user);
    }

    addBrick(user: User, brick: Brick): void {
        WallDAO.addBrickToUser(user, brick);
    }
}
