using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : IMove
{
    public float Speed { get; protected set; }
    private readonly Rigidbody _rigidbody;
    public Movement(Rigidbody rigidbody, float speed)
    {
        _rigidbody = rigidbody;
        this.Speed = speed;
    }

    public void Move(Vector3 forward, float Vertical, float deltaTime)
    {
        var speedOnTime = deltaTime * Speed;
        forward.z += Vertical * speedOnTime;
        _rigidbody.AddRelativeForce(forward);
    }
}