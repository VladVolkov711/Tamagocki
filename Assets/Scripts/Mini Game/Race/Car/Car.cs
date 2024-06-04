using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private Health _carHealth;
    [SerializeField] private ObjectBlinking _objBlinking;
    public float speed = 5f;
    public float turnSpeed = 200f;

    private bool _isUp;
    private bool _isDown;
    private bool _isLeft;
    private bool _isRight;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(transform.position.x > GenerateObject._WorldSpawn + 4 || 
            transform.position.y > GenerateObject._WorldSpawn + 4)
        {
            Debug.Log("вышли за пределы карты");
            transform.position = new Vector2(Random.Range(-GenerateObject._WorldSpawn + 30, GenerateObject._WorldSpawn - 30), Random.Range(-GenerateObject._WorldSpawn + 30, GenerateObject._WorldSpawn - 30));
            _carHealth.HealthCar -= 30;
            _objBlinking.Blinking();
            return;
        }
        // Поворот машинки
        if(_isRight == true && (_isUp == true || _isLeft == true))
        {
            transform.Rotate(Vector3.back, 1 * turnSpeed * Time.fixedDeltaTime);
        }

        if(_isLeft == true && (_isUp == true || _isLeft == true))
        {
            transform.Rotate(Vector3.back, -1 * turnSpeed * Time.fixedDeltaTime);
        }

        // Движение машинки вперед/назад
        if(_isUp == true)
        {
            Vector3 movement = transform.up * speed;
            _rb.AddForce(movement);
        }

        if(_isDown == true)
        {
            Vector3 movement = transform.up * speed;
            _rb.AddForce(-movement);
        }
        
    }

    public void Up() => _isUp = !_isUp;
    public void Down() => _isDown = !_isDown;
    public void Left() => _isLeft = !_isLeft;
    public void Right() => _isRight = !_isRight;
}
