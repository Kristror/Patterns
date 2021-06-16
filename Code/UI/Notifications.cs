using UnityEngine.UI;

namespace Asteroids.UI
{
    public class Notifications
    {
        private Text _notificationText;

        public Notifications(Text text)
        {
            _notificationText = text;
            _notificationText.text = "";
        }

        public void Print(string text)
        {
            _notificationText.text = text;
        }
    }
}