import {Brick} from './Brick';
import {User} from '../User/User';

export interface WallDAOInterface {
    getBricks(user: User): ReadonlyArray<Brick>;

    addBrick(user: User, brick: Brick): void;
}
