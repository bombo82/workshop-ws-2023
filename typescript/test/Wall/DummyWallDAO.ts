import {WallDAOInterface} from '../../src/Wall/WallDAOInterface';
import {User} from '../../src/User/User';
import {Brick} from '../../src/Wall/Brick';

export class DummyWallDAO implements WallDAOInterface {

    getBricks(user: User): ReadonlyArray<Brick> {
        throw new Error("not implemented")
    }

    addBrick(user: User, brick: Brick): void {
        throw new Error("not implemented")
    }
}
