using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject[] _enemyInScene;
    [SerializeField] private Transform[] _spawnPoints;

    private void Start()
    {
        _enemyInScene = new GameObject[10];
        for (int i = 0; i < _enemyInScene.Length; i++)
        {
            GameObject newEnemy = Instantiate(_enemyPrefab);
            newEnemy.transform.parent = transform;
            _enemyInScene[i] = newEnemy;
            newEnemy.SetActive(false);
        }
    }

    public void StartEnemy(ref int countEnemy)
    {
        for (int i = 0; i < countEnemy; i++)
        {
            int randpoint = Random.Range(0, _spawnPoints.Length);
            _enemyInScene[i].transform.position = _spawnPoints[randpoint].position;
            _enemyInScene[i].SetActive(true);
        }
    }
}
