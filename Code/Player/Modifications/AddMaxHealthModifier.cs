namespace Asteroids.PlayerModifications
{
    internal sealed class AddMaxHealthModifier : PlayerModifier
    {
        private readonly int _health;

        public AddMaxHealthModifier(Player player, int health)
            : base(player)
        {
            _health = health;
        }

        public override void Handle()
        {
            _player.Health.Max += _health;
            base.Handle();
        }
    }
}