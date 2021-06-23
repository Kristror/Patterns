using UnityEngine;
using UnityEngine.UI;

namespace Asteroids.UI
{
    public class Points
    {
        private Text _pointsText;
        private int _points;
        public Points(Text text)
        {
            _pointsText = text;
        }

        public int Point
        {
            get => _points;
            set
            {
                _points = value;
                UpdatePoints();
            }
        }
        public void UpdatePoints()
        {
            switch (_points)
            {
                case int num when (num > 1000 && num <1000000):
                    _pointsText.text = $"{(num / 1000)}K";
                    break;
                case int num when (num > 1000000):
                    _pointsText.text = $"{(num / 1000000)}M";
                    break;
                default: 
                    _pointsText.text = $"{_points}";
                    break;
            }
        }
    }
}