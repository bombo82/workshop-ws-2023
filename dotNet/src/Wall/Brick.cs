namespace src.Wall;

public class Brick
{
    public string Message { get; }
    public DateTime CreationDate { get; }

    public Brick(string message, DateTime creationDate)
    {
        Message = message;
        CreationDate = creationDate;
    }

    public override bool Equals(object obj)
    {
        if (this == obj)
            return true;

        if (!(obj is Brick brick))
            return false;

        return Message.Equals(brick.Message) && CreationDate.Equals(brick.CreationDate);
    }

    public override int GetHashCode()
    {
        int result = Message.GetHashCode();
        result = 31 * result + CreationDate.GetHashCode();
        return result;
    }

    public override string ToString()
    {
        return $"{nameof(Brick)}[message='{Message}', creationDate={CreationDate}]";
    }
}
