using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private HealthFillAmount _healthFillAmount;

    public float HealthCar;
    public float MaxHealthCar;

    private float _oldHealth;

    private void OnEnable()
    {
        HealthCar = MaxHealthCar;
        _oldHealth = HealthCar;
    }

    private void Update()
    {
        if (HealthCar == _oldHealth) return;

        _healthFillAmount.HealthDown();
        _oldHealth = HealthCar;
    }

}
