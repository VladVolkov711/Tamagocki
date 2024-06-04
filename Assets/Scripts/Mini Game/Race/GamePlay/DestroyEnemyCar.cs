using UnityEngine;

public class DestroyEnemyCar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private ObjectBlinking _objectBlinking;
    private EnemyCar _enemyCar;

    private void Awake() => _enemyCar = GetComponent<EnemyCar>();

    private void Update()
    {
        if (_health.HealthCar > 0) return;
        DestroyCar();
        enabled = false;
    }

    private void DestroyCar()
    {
        EnemyCar.CountEnemy--;  
        _enemyCar.enabled = false;
        _objectBlinking.Blinking();
        Invoke("SetActiveCar", 1.5f);
    }

    private void SetActiveCar()
    {
        gameObject.SetActive(false);
        transform.position = Vector3.zero;
    }
}
