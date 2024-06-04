using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Scrollbar _scrollBar;
    [SerializeField] private GameObject _failPannel;
    [SerializeField] Transform _mapTransform;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    [SerializeField] private float _mobileSpeed;
    [SerializeField] private float _speedRotation;
    [SerializeField] private float _mobileSpeedRotation;
    public static bool _isMobileInput;
    private float H, V;

    private void Start()
    {
        Cursor.visible = false;
    }
    
    private void FixedUpdate()
    {
        if(_playerHealth.HealthCar <= 0)
        {
            _failPannel.SetActive(true);
            Time.timeScale = 0;
        }
        // вращение по мышке
        float Xrotation = Input.GetAxis("Mouse X");

        // перемещение
        if(_isMobileInput == true)
        {
            H = _joystick.Horozontal(); // left, right
            V = _joystick.Vertical(); // up, down
        }
        else
        {
            H = Input.GetAxis("Horizontal") *_speed* Time.fixedDeltaTime;
            V = Input.GetAxis("Vertical") * _speed * Time.fixedDeltaTime;
        }    

        float move = _speed * Time.fixedDeltaTime;
        float rotate = _speedRotation * Time.fixedDeltaTime;
        float Mobilerotate = _mobileSpeedRotation * Time.fixedDeltaTime;

        // поворот камеры
        if (_isMobileInput == true)
        {
            if(_scrollBar.value > 0.5f) _mapTransform.transform.Rotate(new Vector3(0, 0, Mobilerotate));
            if(_scrollBar.value < 0.5f) _mapTransform.transform.Rotate(new Vector3(0, 0, -Mobilerotate));
            if(_scrollBar.value == 0.5f) _mapTransform.transform.Rotate(new Vector3(0, 0, 0));
        }
        else
        {
            if (Xrotation > 0) _mapTransform.transform.Rotate(new Vector3(0, 0, rotate));
            else if (Xrotation < 0) _mapTransform.transform.Rotate(new Vector3(0, 0, -rotate));
            else if (Xrotation == 0) _mapTransform.transform.Rotate(new Vector3(0, 0, 0));
        }

        // перемещение
        if(_isMobileInput == true)
        {
            if (H == 0 || V == 0) _rb.velocity = new Vector2(0, 0);
            _rb.velocity = new Vector2(H * _mobileSpeed, V * _mobileSpeed);
        }
        else
        {
            if (H == 0 || V == 0) _rb.velocity = new Vector2(0, 0);

            if (H > 0) _rb.velocity = new Vector2(-move, 0);
            else if (H < 0) _rb.velocity = new Vector2(move, 0);

            if (V > 0) _rb.velocity = new Vector2(0, -move);
            else if (V < 0) _rb.velocity = new Vector2(0, move);
        }
    }
}
