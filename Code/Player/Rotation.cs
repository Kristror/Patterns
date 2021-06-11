using UnityEngine;
internal sealed class Rotation : IRotation
{
    private readonly Transform _transform;
    private readonly float _rotateAngle;

    public Rotation(Transform transform,float rotateAngle)
    {
        _transform = transform;
        _rotateAngle = rotateAngle;
    }

    public void Rotate(float Horizontal)
    {
        float angle = _transform.rotation.eulerAngles.y + _rotateAngle * Horizontal;
        _transform.transform.rotation = Quaternion.Euler(0, angle, 0) ;
    }
}