using UnityEngine;
using TMPro;

public class ShooterEnemyWafe : MonoBehaviour
{
    [SerializeField] private SpawnerEnemy _spawnerEnemy;
    // таймер
    [SerializeField] private float _maxTime;
    [SerializeField] private float _time;

    [SerializeField] private TMP_Text _TextTime;

    public int _countWafe;
    public int _countEnemyInScene;
    public bool IsStartWafe;

    private void Start()
    {
        _countWafe = 1;
        _time = _maxTime;
        IsStartWafe = true;
        _countEnemyInScene = 2;
    }

    private void Update()
    {
        if (IsStartWafe == true) Timer();
        if (IsStartWafe == false && EnemyMove.CountEnemyShooter == 0) TimerWin();
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
            _spawnerEnemy.StartEnemy(ref _countEnemyInScene);
            IsStartWafe = false;
            _TextTime.text = "";
            _time = _maxTime;
            return;
        }
    }

    public void TimerWin()
    {
        if (_time > 0)
        {
            _time -= Time.deltaTime;
            if (_time < 1) _TextTime.text = "Следующая волна!";
            else _TextTime.text = "Победа!";
        }
        else
        {
            _countWafe++;
            if(_countEnemyInScene < 10) _countEnemyInScene++;
            IsStartWafe = true;
            _time = _maxTime;
        }
    }
}
