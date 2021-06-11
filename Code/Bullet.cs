using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float speed = 10;
    [SerializeField] public int damage = 25;
    [SerializeField] public float timeOfDes = 2.5f;
    private Rigidbody _rb ;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>(); 
        _rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        Destroy(gameObject, timeOfDes);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //other.gameObject.GetComponent<IEntity>().TakeDamage(damage);
        }
        Destroy(gameObject);
    } 
}
