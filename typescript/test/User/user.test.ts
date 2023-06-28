import {User} from '../../src/User/User';

const A_FRIEND = new User();
const NOT_A_FRIEND = new User();

describe('test user class', () => {
    it('should inform when user are not friend with', function () {
        let user = new User();
        user.addFriend(A_FRIEND);

        expect(user.isFriendWith(NOT_A_FRIEND)).toBeFalsy();
    });

    it('should inform when user are friend with', function () {
        let user = new User();
        user.addFriend(A_FRIEND);

        expect(user.isFriendWith(A_FRIEND)).toBeTruthy();
    });
});
