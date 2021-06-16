using UnityEngine;
using UnityEngine.UI;

namespace Asteroids.UI
{
    public class GameUI : BaseUI
    {
        private Points _points;
        private Notifications _notifications;
        public void Start()
        {
            _points = new Points(transform.GetChild(0).GetChild(1).GetComponent<Text>());
            _notifications = new Notifications(transform.GetChild(1).GetComponent<Text>());
        }

        public void EnemyDeath(string type, int points)
        {
            _points.Point += points;
            _notifications.Print($"{type} destroyed");
        }
    }
}