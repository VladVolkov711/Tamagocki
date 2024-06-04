using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthFillAmount : MonoBehaviour
{
    [SerializeField] private Image _green;
    [SerializeField] private Image _orange;
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _green.fillAmount = 1;
        _orange.fillAmount = 1;
    }

    public void HealthDown()
    {
        _green.fillAmount = _health.HealthCar / _health.MaxHealthCar;
        StartCoroutine(HealthDownOrange());
    }

    private IEnumerator HealthDownOrange()
    {
        while (_orange.fillAmount >= _green.fillAmount)
        {
            yield return new WaitForSeconds(0.03f);
            _orange.fillAmount -= 0.01f;
        }
    }
}
