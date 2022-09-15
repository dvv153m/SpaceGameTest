public interface IMovable
{
    void Move();    
}

public class Spaceship : IMovable
{
    public Vector Position {get;set;}
    public Vector Velocity {get;set;}

    public void Move()//в этом месте нарушение SRP потому что в другом объекте придется создать точно такой же метод. Но другой объект отнаследовать от Spaceship нельзя
    {
        Position = Position + Velocity;
    }

    public void ParableMove()//в этом месте нарушение SRP
    {
        Position = Position + 2*Velocity;
    }
}

IMovable objs = new IMovable[] {new Spaceship(), new Spaceship()};
foreach(var obj in objs)
{
    obj.Move();    
}

var spaceship = new Spaceship();
var move = new Move(spaceship);
foreach(var obj in objs)
{
    move.SetObject(obj);
    move.Excecute();
}

public class Vector
{
    public double X { get; set; }
    public double Y { get; set; }
}