using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private EnemyWafe _enemyWafe;
    public GameObject[] Enemys;
    public GameObject[] EnemysInScen;

    public int MaxEnemysInScen;
    private void Awake()
    {
        EnemysInScen = new GameObject[7];
        for (int i = 0; i < MaxEnemysInScen; i++)
        {
            if (i >= 0 && i < 3) EnemysInScen[i] = Instantiate(Enemys[0]);
            if(i >= 3 && i < 5) EnemysInScen[i] = Instantiate(Enemys[1]);
            if (i >= 5 && i < 7) EnemysInScen[i] = Instantiate(Enemys[2]);
        }

        for (int i = 0; i < EnemysInScen.Length; i++)
            EnemysInScen[i].gameObject.SetActive(false);

        EnemyCar.CountEnemy = 0;
    }

    public void SpawnEnemys(float x, float y)
    {
        for (int i = 0; i < _enemyWafe._countEnemyInScene; i++)
        {
            EnemysInScen[i].gameObject.SetActive(true);
            EnemysInScen[i].gameObject.transform.position = new Vector2(x, y);
        }
    }
}
