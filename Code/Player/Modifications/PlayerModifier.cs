namespace Asteroids.PlayerModifications
{
    internal class PlayerModifier
    {
        protected Player _player;
        protected PlayerModifier Next;

        public PlayerModifier(Player player)
        {
            _player = player;
        }

        public void Add(PlayerModifier nextModifier)
        {
            if (Next != null)
            {
                Next.Add(nextModifier);
            }
            else
            {
                Next = nextModifier;
            }
        }

        public virtual void Handle() => Next?.Handle();
    }
}