using UnityEngine;
using TMPro;

public class EnemyWafe : MonoBehaviour
{
    [SerializeField] internal EnemySpawn _enemySpawn;
    [SerializeField] private GameObject _player;
    [SerializeField] private float _distanceFromPlayer;

    // таймер
    [SerializeField] private float _maxTime;
    [SerializeField] private float _time;

    [SerializeField] private TMP_Text _TextTime;

    public int _countWafe;
    public int _countEnemyInScene;
    public static bool IsDoneEnemy;

    private float x, y;
    private void Start()
    {
        _countWafe = 1;
        _time = _maxTime;
        IsDoneEnemy = true;
    }

    private void Update()
    {
        if (IsDoneEnemy == true) Timer();
    }

    public void Timer()
    {
        if (_time > 0)
        {
            _time -= Time.deltaTime;
            if (_time < 1) _TextTime.text = "GO!";
            else _TextTime.text = Mathf.Floor(_time).ToString();
        }
        else
        {
            NewPosition();
            _enemySpawn.SpawnEnemys(x, y);
            IsDoneEnemy = false;
            _TextTime.text = "";
            _time = _maxTime;
            return;
        }
    }

    public void NewPosition()
    {
        float x1 = Random.Range(_player.transform.position.x + 6, _distanceFromPlayer);
        float x2 = Random.Range(_player.transform.position.x - 6, _distanceFromPlayer);
        float y1 = Random.Range(_player.transform.position.y + 6, _distanceFromPlayer);
        float y2 = Random.Range(_player.transform.position.y - 6, _distanceFromPlayer);

        x = VladMath.OneOfTwoNumber(x1, x2);
        y = VladMath.OneOfTwoNumber(y1, y2);
    }
}
