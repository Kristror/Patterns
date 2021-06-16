using System.Collections.Generic;
using UnityEngine;

namespace Memento
{
    public sealed class TimeBody 
    {
        [SerializeField] private float _recordTime = 5f;
        private List<PointInTime> _pointsInTime;
        private Rigidbody _rigidbody;
        private bool _isRewinding;
        private Transform _player;
        public bool isRewinding
        {
            get => _isRewinding;
        }
        public TimeBody(Transform player,Rigidbody rigidbody)
        {
            _pointsInTime = new List<PointInTime>();
            _rigidbody = rigidbody;
            _player = player;
        }

        public void Rewind()
        {
            if (_pointsInTime.Count > 1)
            {
                PointInTime pointInTime = _pointsInTime[0];
                _player.position = pointInTime.Position;
                _player.rotation = pointInTime.Rotation;
                _pointsInTime.RemoveAt(0);
            }
            else
            {
                PointInTime pointInTime = _pointsInTime[0];
                _player.position = pointInTime.Position;
                _player.rotation = pointInTime.Rotation;
                StopRewind();
            }
        }

        public void Record()
        {
            if (_pointsInTime.Count > Mathf.Round(_recordTime / Time.fixedDeltaTime))
            {
                _pointsInTime.RemoveAt(_pointsInTime.Count - 1);
            }

            _pointsInTime.Insert(0, new PointInTime(_player.position, _player.rotation, _rigidbody.velocity, _rigidbody.angularVelocity));
        }

        public void StartRewind()
        {
            _isRewinding = true;
            _rigidbody.isKinematic = true;
        }

        public void StopRewind()
        {
            _isRewinding = false;
            _rigidbody.isKinematic = false;
            _rigidbody.velocity = _pointsInTime[0].Velocity;
            _rigidbody.angularVelocity = _pointsInTime[0].AngularVelocity;
        }
    }
}