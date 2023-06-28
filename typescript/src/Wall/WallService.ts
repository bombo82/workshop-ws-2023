import {Brick} from './Brick';
import {WallDAO} from './WallDAO';
import {UsersAreNotFriendsError} from '../Error/UsersAreNotFriendsError';
import {UserNotLoggedInError} from '../Error/UserNotLoggedInError';
import {User} from '../User/User';

export class WallService {
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
                wall = this.findBricksByUser(user);
                const brick: Brick = new Brick(message, this.getCreationDate());
                this.addBrickToUser(user, brick);

                wall.push(brick);
                return wall;
            }

            throw new UsersAreNotFriendsError();
        } else {
            throw new UserNotLoggedInError();
        }
    }
    protected findBricksByUser(user: User) {
        return WallDAO.findBricksByUser(user);
    }

    protected addBrickToUser(user: User, brick: Brick) {
        WallDAO.addBrickToUser(user, brick);
    }

    protected getCreationDate() {
        return new Date();
    }
}
