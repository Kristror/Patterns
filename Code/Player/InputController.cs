using UnityEngine;

namespace Asteroids
{
    public class InputController : IExecute
    {
        Ship _ship;
        Shooting _shooting;
        Transform _player;
        public InputController(Ship ship, Transform player, Shooting shooting)
        {
            _ship = ship;
            _player = player;
            _shooting = shooting;
        }

        public void Execute()
        {
            _ship.Move(_player.transform.forward, Input.GetAxis("Vertical"), Time.deltaTime);

            _ship.Rotate(Input.GetAxis("Horizontal"));

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                _shooting.Shoot();
            }
        }
    }
}