import {WallDAOInterface} from '../../src/Wall/WallDAOInterface';
import {User} from '../../src/User/User';
import {Brick} from '../../src/Wall/Brick';

export class StubWallDAO implements WallDAOInterface {
    getBricks(user: User): Brick[] {
        return [];
    }

    addBrick(user: User, brick: Brick): void {
    }
}
