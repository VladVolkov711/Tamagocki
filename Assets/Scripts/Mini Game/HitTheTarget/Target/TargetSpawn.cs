using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetSpawn : MonoBehaviour
{
    public static TargetSpawn targetSpawn;
    public GameObject[] Target;
    public float Speed;
    public bool IsBoss;

    public List<GameObject> BollsList = new List<GameObject>();

    public TMP_Text BossHealthText;
    public GameObject BossHealthObjectText;

    private void Start()
    {
        targetSpawn = this;
        Speed = 0.04f;
    }

    private void Update()
    {
        if (GameController.gameController.Score % 5 == 0 && GameController.gameController.Score != 0) IsBoss = true;
        else IsBoss = false;

        if (IsBoss == true)
        {
            BossHealthObjectText.SetActive(true);
            BossHealthText.text = "Жизни босса: " + TargetPosition.singlthon.BossHealth.ToString();
        }
        else BossHealthObjectText.SetActive(false);
    }

    public void Spawn()
    {
        if(GameController.gameController.LiveKnife > 0)
        {
            if (GameController.gameController.Score < 11)
            {
                GameObject NewTarget_One = Instantiate(Target[Random.Range(0, Target.Length)], transform.position = new Vector2(Random.Range(-3, 3), 2f), Quaternion.identity);
                BollsList.Add(NewTarget_One);
            }
            else
            {
                GameObject NewTarget_Two = Instantiate(Target[Random.Range(0, Target.Length)], transform.position = new Vector2(Random.Range(-3, 3), Random.Range(2f, 0)), Quaternion.identity);
                BollsList.Add(NewTarget_Two);
            }
        }
    }
}
