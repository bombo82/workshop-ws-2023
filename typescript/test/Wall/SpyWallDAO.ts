import {WallDAOInterface} from '../../src/Wall/WallDAOInterface';
import {User} from '../../src/User/User';
import {Brick} from '../../src/Wall/Brick';

export class SpyWallDAO implements WallDAOInterface {
    private _userParameter?: User;
    private _brickParameter?: Brick;

    get brickParameter(): Brick | undefined {
        return this._brickParameter;
    }

    get userParameter(): User | undefined {
        return this._userParameter;
    }

    getBricks(user: User): ReadonlyArray<Brick> {
        return [new Brick("", new Date())];
    }

    addBrick(user: User, brick: Brick): void {
        this._userParameter = user;
        this._brickParameter = brick;
    }
}
