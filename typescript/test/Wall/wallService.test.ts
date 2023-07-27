import {WallService} from '../../src/Wall/WallService';
import {User} from '../../src/User/User';
import {UserNotLoggedInError} from '../../src/Error/UserNotLoggedInError';
import {UsersAreNotFriendsError} from '../../src/Error/UsersAreNotFriendsError';
import {Brick} from '../../src/Wall/Brick';
import {StubClock} from '../Wrapper/StubClock';
import {FakeWallDAO} from './FakeWallDAO';
import {DummyWallDAO} from "./DummyWallDAO";
import {DummyClock} from "../Wrapper/DummyClock";
import {SpyWallDAO} from "./SpyWallDAO";

const GUEST = undefined;
const REGISTERED_USER = new User();

describe('Wall Service test', () => {

    it('should throw an error when user is not logged in', () => {
        const wallService = new WallService(new DummyWallDAO(), new DummyClock());

        expect(() =>
            wallService.anotherBrickInTheWall(new User(), '', GUEST)
        ).toThrow(UserNotLoggedInError);
    });

    it('should throw an error when user are not friend with', () => {
        const wallService = new WallService(new DummyWallDAO(), new DummyClock());

        expect(() =>
            wallService.anotherBrickInTheWall(new User(), '', REGISTERED_USER)
        ).toThrow(UsersAreNotFriendsError);
    });

    it('should append a new brick to friend wall', () => {
        const stubClock = new StubClock();
        let spyWallDAO = new SpyWallDAO();
        const wallService = new WallService(spyWallDAO, stubClock);
        let user = new User();
        user.addFriend(REGISTERED_USER);

        wallService.anotherBrickInTheWall(user, '', REGISTERED_USER);

        expect(spyWallDAO.userParameter).toEqual(user);
        expect(spyWallDAO.brickParameter).toEqual(new Brick("", stubClock.now()))
    });

    it('appended brick should return the updated wall', () => {
        const stubClock = new StubClock();
        const wallService = new WallService(new FakeWallDAO(), stubClock);

        let user = new User();
        user.addFriend(REGISTERED_USER);

        let wall = wallService.anotherBrickInTheWall(user, '', REGISTERED_USER);

        expect(wall.length).toEqual(1);
        expect(wall[0]).toEqual(new Brick('', stubClock.now()));
    });
});
