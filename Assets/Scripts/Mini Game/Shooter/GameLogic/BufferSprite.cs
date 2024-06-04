using UnityEngine;

public class BufferSprite : MonoBehaviour
{
    public GameObject Block;
    public GameObject Enemy;
    public GameObject[] sprite;
    public GameObject[] EnemyInScen;

    private void Awake()
    {
        sprite = new GameObject[80];
        EnemyInScen = new GameObject[10];
        FullBuffer();
        ClearBuffer();
    }

    public void FullBuffer()
    {
        Enemy.SetActive(false);
        for (int i = 0; i < sprite.Length; i++)
        {
            GameObject obj = Instantiate(Block);
            obj.name = "block: " + i;
            sprite[i] = obj;
        }

        for (int i = 0; i < EnemyInScen.Length; i++)
        {
            GameObject obj = Instantiate(Enemy);
            obj.name = "Enemy: " + i;
            EnemyInScen[i] = obj;
        }
    }

    public void ClearBuffer()
    {
        for (int i = 0; i < sprite.Length; i++) sprite[i].SetActive(false);
    }

    public void EnemyClearBuffer()
    {
        for (int i = 0; i < EnemyInScen.Length; i++) EnemyInScen[i].SetActive(false);
    }
}
