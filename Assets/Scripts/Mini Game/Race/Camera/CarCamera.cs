using UnityEngine;

public class CarCamera : MonoBehaviour
{
    [SerializeField] private float _chengeSizeUp, _chengeSizeDown;
    [SerializeField] private float _cameraSizeMin = 3.5f, _cameraSizeMax = 5f;

    private GameObject _player;
    private Car _car;
    private Transform _camTr;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        _player = GameObject.FindGameObjectWithTag("Player");
        _car = _player.GetComponent<Car>();
        _camTr = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        _camTr.position = new Vector3(Mathf.Clamp(_player.transform.position.x,-GenerateObject._WorldSpawn, GenerateObject._WorldSpawn), Mathf.Clamp(_player.transform.position.y, -GenerateObject._WorldSpawn, GenerateObject._WorldSpawn), -10);

        //if (_car._isBoost == true)
        //    _camera.orthographicSize = 
        //        Mathf.Clamp(_camera.orthographicSize + _chengeSizeUp, _cameraSizeMin, _cameraSizeMax);

        //if (_car._isBoost == false)
        //    _camera.orthographicSize = 
        //        Mathf.Clamp(_camera.orthographicSize - _chengeSizeDown, _cameraSizeMin, _cameraSizeMax);
    }
}
