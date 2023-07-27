import {WallDAOInterface} from '../../src/Wall/WallDAOInterface';
import {User} from '../../src/User/User';
import {Brick} from '../../src/Wall/Brick';

export class FakeWallDAO implements WallDAOInterface {
    private bricks: Brick[] = [];

    getBricks(user: User): ReadonlyArray<Brick> {
        return [...this.bricks];
    }

    addBrick(user: User, brick: Brick): void {
        this.bricks.push(brick);
    }
}
