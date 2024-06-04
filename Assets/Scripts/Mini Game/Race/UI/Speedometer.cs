using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    [SerializeField] private GameObject _car;
    [SerializeField] private Car _carComponent;

    private Text _speedText;

    private void Awake()
    {
        _speedText = GetComponent<Text>();
        _car = GameObject.FindGameObjectWithTag("Player");
        _carComponent = _car.GetComponent<Car>();
    }

    private void Update()
    {
        //if(_carComponent._speed >= 0) _speedText.text = "Скорость: " + Mathf.Floor(_carComponent._speed);
        //else _speedText.text = "Скорость: " + Mathf.Floor(-_carComponent._speed);
    }
}
