using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private int x, y;
    [SerializeField] private float _step;
    [SerializeField] private GameObject _point;
    private void Awake()
    {
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                GameObject newpoint = Instantiate(_point, new Vector2(transform.position.x + i, transform.position.y - j), Quaternion.identity);
                newpoint.transform.parent = transform;
            }
        }
    }
}
