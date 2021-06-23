namespace Asteroids.Visitor
{
    public interface IActiveEnemy
    {
        void Visit(Enemy enemy);
    }
}