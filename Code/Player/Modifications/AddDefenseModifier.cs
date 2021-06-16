namespace Asteroids.PlayerModifications
{
    internal sealed class AddDefenseModifier : PlayerModifier
    {
        private readonly int _maxDefense;

        public AddDefenseModifier(Player player, int maxDefense)
            : base(player)
        {
            _maxDefense = maxDefense;
        }

        public override void Handle()
        {
            if (_player.Defense <= _maxDefense)
            {
                _player.Defense++;
            }

            base.Handle();
        }
    }
}