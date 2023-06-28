import {WallService} from '../../src/Wall/WallService';
import {User} from '../../src/User/User';
import {UserNotLoggedInError} from '../../src/Error/UserNotLoggedInError';
import {UsersAreNotFriendsError} from '../../src/Error/UsersAreNotFriendsError';
import {Brick} from '../../src/Wall/Brick';
import {StubWallDAO} from './stubWallDAO';
import {WallDAOInterface} from '../../src/Wall/WallDAOInterface';
import {StubClock} from '../Wrapper/stubClock';
import {ClockInterface} from '../../src/Wrapper/ClockInterface';

const GUEST = undefined;
const REGISTERED_USER = new User();

describe('Wall Service test', () => {
    let wallService: WallService;
    let clock: ClockInterface;

    beforeEach(() => {
        let wallDAO: WallDAOInterface = new StubWallDAO();
        clock = new StubClock();
        wallService = new WallService(wallDAO, clock);
    });

    it('should throw an error when user is not logged in', () => {
        expect(() => wallService.anotherBrickInTheWall(new User(), '', GUEST)).toThrow(UserNotLoggedInError);
    });

    it('should throw an error when user are not friend with', () => {
        expect(() => wallService.anotherBrickInTheWall(new User(), '', REGISTERED_USER)).toThrow(UsersAreNotFriendsError);
    });

    it('should append a new brick to friend wall and return the updated wall', () => {
        let user = new User();
        user.addFriend(REGISTERED_USER);

        let wall = wallService.anotherBrickInTheWall(user, '', REGISTERED_USER);

        expect(wall.length).toEqual(1);
    });

    it('appended brick should be the right one', () => {
        let user = new User();
        user.addFriend(REGISTERED_USER);

        let wall = wallService.anotherBrickInTheWall(user, '', REGISTERED_USER);

        expect(wall[0]).toEqual(new Brick('', clock.now()));
    });
});
