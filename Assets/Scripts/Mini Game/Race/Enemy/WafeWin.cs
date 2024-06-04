using UnityEngine;
using TMPro;

public class WafeWin : MonoBehaviour
{
    [SerializeField] private EnemyWafe _enemyWafe;
    [SerializeField] private TMP_Text _winText;
    [SerializeField] public float _time;
    [SerializeField] private float _maxTime;

    private void Start()
    {
        _time = _maxTime;
    }
    private void Update()
    {
        Debug.Log(EnemyCar.CountEnemy);
        if (EnemyWafe.IsDoneEnemy == false && EnemyCar.CountEnemy == 0) Timer();
    }

    private void Timer()
    {
        if(_time > 0)
        {
            _time -= Time.deltaTime;
            if (_time < 1) _winText.text = "Следующая волна!";
            else _winText.text = "Победа!";
        }
        else
        {
            EnemyWafe.IsDoneEnemy = true;
            _enemyWafe._countWafe++;

            if(_enemyWafe._countEnemyInScene < _enemyWafe._enemySpawn.EnemysInScen.Length)
                _enemyWafe._countEnemyInScene++;

            _time = _maxTime;
        }
    }
}
