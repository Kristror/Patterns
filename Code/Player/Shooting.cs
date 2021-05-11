using UnityEngine;

public class Shooting : MonoBehaviour, IShoot
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _BulletStartPos;

    public void Shoot()
    {
        var temAmmunition = Instantiate(_bullet, _BulletStartPos.position, Quaternion.identity);
    }
}