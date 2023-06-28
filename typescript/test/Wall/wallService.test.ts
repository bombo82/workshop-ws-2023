import {WallService} from '../../src/Wall/WallService';
import {User} from '../../src/User/User';
import {UserNotLoggedInError} from '../../src/Error/UserNotLoggedInError';

describe('Wall Service test', () => {
    it('should throw an error when user is not logged in', () => {
        expect(() => {
            let wallService = new TestableWallService();
            wallService.anotherBrickInTheWall(new User(), '');
        }).toThrow(UserNotLoggedInError);
    });

    class TestableWallService extends WallService {

        protected getLoggedUser(): User | undefined {
            return undefined;
        }
    }
});
