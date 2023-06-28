import {WallService} from '../../src/Wall/WallService';
import {User} from '../../src/User/User';
import {UserNotLoggedInError} from '../../src/Error/UserNotLoggedInError';
import {UsersAreNotFriendsError} from '../../src/Error/UsersAreNotFriendsError';
import {Brick} from '../../src/Wall/Brick';

const GUEST = undefined;
const REGISTERED_USER = new User();

describe('Wall Service test', () => {
    let wallService: TestableWallService;

    let loggedInUser: User | undefined;
    let creationDate: Date;

    beforeEach(() => {
        wallService = new TestableWallService();
    });

    it('should throw an error when user is not logged in', () => {
        loggedInUser = GUEST;

        expect(() => wallService.anotherBrickInTheWall(new User(), '')).toThrow(UserNotLoggedInError);
    });

    it('should throw an error when user are not friend with', () => {
        loggedInUser = REGISTERED_USER;

        expect(() => wallService.anotherBrickInTheWall(new User(), '')).toThrow(UsersAreNotFriendsError);
    });

    it('should append a new brick to friend wall and return the updated wall', () => {
        loggedInUser = REGISTERED_USER;
        let user = new User();
        user.addFriend(REGISTERED_USER);

        let wall = wallService.anotherBrickInTheWall(user, '');

        expect(wall.length).toEqual(1);
    });

    it('appended brick should be the right one', () => {
        loggedInUser = REGISTERED_USER;
        creationDate = new Date();
        let user = new User();
        user.addFriend(REGISTERED_USER);

        let wall = wallService.anotherBrickInTheWall(user, '');

        expect(wall[0]).toEqual(new Brick('', creationDate));
    });

    class TestableWallService extends WallService {

        protected getLoggedUser(): User | undefined {
            return loggedInUser;
        }

        protected findBricksByUser(user: User): Brick[] {
            return [];
        }

        protected addBrickToUser(user: User, brick: Brick) {
        }

        protected getCreationDate(): Date {
            return creationDate;
        }
    }
});
