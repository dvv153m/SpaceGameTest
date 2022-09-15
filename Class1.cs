public interface IMovable
{
    public Vector Position{get;set};
    public Vector Velocity{get;set};

    public void SetPosition(Vector newPos);
}

public class Move//ответственность за движение выделяем в отдельную сущность
{
    private IMovable _obj;

    public void SetObject(IMovable obj)
    {
        _obj = obj;
    }

    public void Execute()
    {
        SetPosition(_obj.Position + _obj.Velocity);
    }

    public void ParaMove()//любое не прямолинейное движение   (это в отдельную сущность определить)
    {
        SetPosition(_obj.Position + 2*_obj.Velocity);
    }
}

public class Spaceship : IMovable
{
    public Vector Position{get;set};
    public Vector Velocity{get;set};

    private Move _move;
    public Spaceship(Move move)
    {
        _move = move;
        _move.SetObject(this);
    }

    public void Move()
    {
        _move.Execute();
    }

    public void SetPosition(Vector newPos)
    {
        Position = newPos;
    }
}