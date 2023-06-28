import {Brick} from './Brick';
import {UsersAreNotFriendsError} from '../Error/UsersAreNotFriendsError';
import {UserNotLoggedInError} from '../Error/UserNotLoggedInError';
import {User} from '../User/User';
import {WallDAOInterface} from './WallDAOInterface';

export class WallService {
    private _wallDAO: WallDAOInterface;

    constructor(wallDAO: WallDAOInterface) {
        this._wallDAO = wallDAO;
    }

    anotherBrickInTheWall(user: User, message: string, loggedInUser: User | undefined): Brick[] {
        let wall: Brick[] = [];
        let isFriend: boolean = false;

        if (loggedInUser !== undefined) {
            for (const friend of user.getFriends()) {
                if (friend === loggedInUser) {
                    isFriend = true;
                    break;
                }
            }

            if (isFriend) {
                wall = this._wallDAO.getBricks(user);
                const brick: Brick = new Brick(message, this.getCreationDate());
                this._wallDAO.addBrick(user, brick);

                wall.push(brick);
                return wall;
            }

            throw new UsersAreNotFriendsError();
        } else {
            throw new UserNotLoggedInError();
        }
    }

    protected getCreationDate() {
        return new Date();
    }
}
