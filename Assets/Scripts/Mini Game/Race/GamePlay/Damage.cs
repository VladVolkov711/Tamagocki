using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private string _triggerName;
    [SerializeField] private float _damage;
    [SerializeField] private Health _health;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(_triggerName))
        {
            collision.gameObject.GetComponent<Health>().HealthCar -= _damage; // наносим урон врагу
            _health.HealthCar -= _damage * 0.5f; // наносим урон машине
        }
    }
}
