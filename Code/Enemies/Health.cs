namespace Asteroids
{
    public sealed class Health
    {
        public float Max { get; set; }
        public float Current { get; private set; }
        public Health(float max)
        {
            Max = max;
            Current = max;
        }
        public Health(float max, float current)
        {
            Max = max;
            Current = current;
        }

        public void ChangeCurrentHealth(float hp)
        {
            Current = hp;
        }
    }
}