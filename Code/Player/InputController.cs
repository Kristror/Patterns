using UnityEngine;
using Asteroids.UI;
using Memento;

namespace Asteroids
{
    public class InputController : IExecute
    {
        Ship _ship;
        Shooting _shooting;
        Transform _player;
        UISystem _UISystem;
        TimeBody _timeBody;
        public InputController(Ship ship, Transform player, Shooting shooting)
        {
            _ship = ship;
            _player = player;
            _shooting = shooting;
            _timeBody = new TimeBody(player, player.GetComponent<Rigidbody>());
        }

        public void SetUISystem(UISystem uISystem)
        {
            _UISystem = uISystem;
        }

        public void Execute()
        {
            if (Time.timeScale != 0) 
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
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    _UISystem.Pause();
                }

                if (Input.GetButtonDown("Fire1"))
                {
                    _shooting.Shoot();
                }

                if (Input.GetKeyDown(KeyCode.Q))
                {
                    _timeBody.StartRewind();
                }

                if (Input.GetKeyUp(KeyCode.Q))
                {
                    _timeBody.StopRewind();
                }

                if (_timeBody.isRewinding)
                {
                    _timeBody.Rewind();
                }
                else
                {
                    _timeBody.Record();
                }
            }
        }
    }
}