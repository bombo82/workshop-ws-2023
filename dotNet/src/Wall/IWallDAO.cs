namespace src.Wall;

public interface IWallDAO
{
    List<Brick> GetBricks(User.User user);
    void AddBrick(User.User user, Brick brick);
}
