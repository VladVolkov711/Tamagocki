using UnityEngine;

public class SpawnUIKnife : MonoBehaviour
{
    public static SpawnUIKnife singlton;
    public GameObject[] frontUI;
    public GameObject[] BackUI;
    public GameObject front;
    public GameObject back;
    [SerializeField] private float _useStepUp;
    [SerializeField] private float _stepRight;
    private float _step;
    private float DestrouUi;
    private Vector2 _startPos;

    private void Start()
    {
        _startPos = transform.position;
        singlton = this;
        SpawnUi();
    }

    public void SpawnUi()
    {
        _step = 0;
        for (int i = 0; i < frontUI.Length; i++)
        {
            if(i == 3) _step = 0;
            if (i > 2)
            {
                transform.position = _startPos;
                SpawnKnife(i, _stepRight, _step);
            }
            else SpawnKnife(i, 0, _step);
        }
    }

    private void SpawnKnife(int i, float stepright, float stepup)
    {
        frontUI[i] = Instantiate(front, new Vector2(transform.position.x + stepright, transform.position.y + stepup), Quaternion.identity);
        frontUI[i].transform.parent = transform;

        BackUI[i] = Instantiate(back, new Vector2(transform.position.x + stepright, transform.position.y + stepup), Quaternion.identity);
        BackUI[i].transform.parent = transform;
        _step += _useStepUp;
    }

    public void DamageKnifeUi()
    {
        Destroy(frontUI[5 - (int)DestrouUi]);
        DestrouUi++;
    }
}
