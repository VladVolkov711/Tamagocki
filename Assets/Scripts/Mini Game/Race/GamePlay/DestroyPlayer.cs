using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void Update()
    {
        if (_health.HealthCar > 0) return;
        DestroyCar();
    }

    private void DestroyCar()
    {
        Time.timeScale = 0;
    }
}
