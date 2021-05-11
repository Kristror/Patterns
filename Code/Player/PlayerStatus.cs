using UnityEngine;

public class PlayerStatus : MonoBehaviour, IEntity
{

    [SerializeField] private float _hp;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10); //change when add enemies
        }   
    }
    public void TakeDamage(int damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        Destroy(gameObject);
    }
}
