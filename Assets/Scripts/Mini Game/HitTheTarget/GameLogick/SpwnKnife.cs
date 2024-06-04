using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwnKnife : MonoBehaviour
{
    public static SpwnKnife singlthon;
    public GameObject Knife;

    public List<GameObject> KnifeList = new List<GameObject>();

    private void Start()
    {
        singlthon = this;
        GameObject NewKnife = Instantiate(Knife, transform.position = new Vector2(0, -3.5f), Quaternion.identity);
        KnifeList.Add(NewKnife);
    }

    public void Spawn()
    {
        if (GameController.gameController.Score < 7)
        {
            GameObject NewKnife_One = Instantiate(Knife, transform.position = new Vector3(0, -3.5f, 0), Quaternion.identity);
            KnifeList.Add(NewKnife_One);
        }
        else
        {
            GameObject NewKnife_Two = Instantiate(Knife, transform.position = new Vector3(Random.Range(-1.5f, 2), -3.5f, 0), Quaternion.identity);
            KnifeList.Add(NewKnife_Two);
        }
    }
}
