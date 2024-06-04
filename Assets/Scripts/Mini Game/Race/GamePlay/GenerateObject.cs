using UnityEngine;

public class GenerateObject : MonoBehaviour
{
    [SerializeField] private GameObject[] _obj;
    [SerializeField] private int _maxCount;
    static public float _WorldSpawn = 50;
    [SerializeField] private Transform Objposition;
    private void Awake()
    {
        for (int i = 0; i < _maxCount; i++)
        {
            int rand = Random.Range(0, _obj.Length);
            float x = Random.Range(-_WorldSpawn, _WorldSpawn);
            float y = Random.Range(-_WorldSpawn, _WorldSpawn);

            GameObject obj = Instantiate(_obj[rand], Objposition);
            obj.transform.position = new Vector2(x, y);
        }
    }
}
