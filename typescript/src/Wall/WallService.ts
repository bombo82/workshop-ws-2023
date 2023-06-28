import {Brick} from './Brick';
import {UsersAreNotFriendsError} from '../Error/UsersAreNotFriendsError';
import {UserNotLoggedInError} from '../Error/UserNotLoggedInError';
import {User} from '../User/User';
import {WallDAOInterface} from './WallDAOInterface';
import {ClockInterface} from '../Wrapper/ClockInterface';

export class WallService {
    private _wallDAO: WallDAOInterface;
    private _clock: ClockInterface;

    constructor(wallDAO: WallDAOInterface, clock: ClockInterface) {
        this._wallDAO = wallDAO;
        this._clock = clock;
    }

    anotherBrickInTheWall(user: User, message: string, loggedInUser: User | undefined): Brick[] {
        if (loggedInUser === undefined) {
            throw new UserNotLoggedInError();
        }
        if (!user.isFriendWith(loggedInUser)) {
            throw new UsersAreNotFriendsError();
        }

        let wall: Brick[] = this._wallDAO.getBricks(user);
        const brick: Brick = new Brick(message, this._clock.now());
        this._wallDAO.addBrick(user, brick);

        wall.push(brick);
        return wall;
    }
}
