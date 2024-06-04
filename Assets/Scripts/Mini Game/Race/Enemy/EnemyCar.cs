using UnityEngine;

public class EnemyCar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _speed; // скорость передвижения
    [SerializeField] private float _rotateSpeed;
    [SerializeField] float Angle;
    [SerializeField] float _newAngle;
    public static int CountEnemy;

    private GameObject _target; // цель для следования

    private void Awake() => _target = GameObject.FindGameObjectWithTag("Player");

    private void OnEnable()
    {
        CountEnemy++;
        _health.HealthCar = _health.MaxHealthCar;
    }

    private void FixedUpdate()
    {
        Rotate();
        Move();
    }

    private void Rotate()
    {
        var dir = _target.transform.position - transform.position;
        Angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, Angle);
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed);
    }
    
}
