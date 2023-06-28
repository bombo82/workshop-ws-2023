import {Brick} from './Brick';
import {WallDAO} from './WallDAO';
import {UsersAreNotFriendsError} from '../Error/UsersAreNotFriendsError';
import {UserNotLoggedInError} from '../Error/UserNotLoggedInError';
import {User} from '../User/User';
import {UserSession} from '../User/UserSession';

export class WallService {
    anotherBrickInTheWall(user: User, message: string): Brick[] {
        let wall: Brick[] = [];
        const loggedUser = this.getLoggedUser();
        let isFriend: boolean = false;

        if (loggedUser !== undefined) {
            for (const friend of user.getFriends()) {
                if (friend === loggedUser) {
                    isFriend = true;
                    break;
                }
            }

            if (isFriend) {
                wall = WallDAO.findBricksByUser(user);
                const brick: Brick = new Brick(message, new Date());
                WallDAO.addBrickToUser(user, brick);

                wall.push(brick);
                return wall;
            }

            throw new UsersAreNotFriendsError();
        } else {
            throw new UserNotLoggedInError();
        }
    }

    protected getLoggedUser(): User | undefined {
        return UserSession.getInstance().getLoggedUser();
    }
}
