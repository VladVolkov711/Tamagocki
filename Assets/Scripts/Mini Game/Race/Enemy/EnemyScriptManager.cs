using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptManager : MonoBehaviour
{
    [SerializeField] private EnemyCar _enemyCar;
    [SerializeField] private DestroyEnemyCar _destroyEnemyCar;
    private void OnEnable()
    {
        _enemyCar.enabled = true;
        _destroyEnemyCar.enabled = true;
    }
}
