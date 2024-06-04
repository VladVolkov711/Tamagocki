using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] internal GameObject _player;
    [SerializeField] private Enemy _health;
    public float Speed;
    public static int CountEnemyShooter;

    private void OnEnable() => CountEnemyShooter++;

    private void OnDisable()
    {
        CountEnemyShooter--;
        _health.Health = 100;
    }

    private void Start()
    {
        _player = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        float distance = Vector2.Distance(transform.position, _player.transform.position);

        if (distance > 1)
            transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, Speed * Time.fixedDeltaTime);
    }
}
