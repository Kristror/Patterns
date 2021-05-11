using UnityEngine;
public interface IMove
{
    float Speed { get; }
    void Move(Vector3 forward, float Vertical, float deltaTime);
}
