using UnityEngine;

public class ShooterGameLogic : MonoBehaviour
{
    [SerializeField] private BufferSprite _spriteBuffer; // ������ �������� ��� ��������� ����� � ��������
    [SerializeField] private LayerMask maskBlock; // ����� ��� ����������� �����
    [SerializeField] private LayerMask maskEnemy; // ����� ��� ����������� �����
    [SerializeField] private float raydistance; // ����� ����
    [SerializeField] private GameObject[] _hitBufferEnemy; // ������ ������ ��� ���������� ����������
    private Vector2 _direction; // ������ ����������� ����

    public int ClearEnemy; // ������� ��� ������� ������ �� ������

    private void Start()
    {
        _hitBufferEnemy = new GameObject[10];
    }

    private void FixedUpdate()
    {
        float position = -9f; // ������� ��� ��������� �����
        float positionEnemy = -9f; // ������� ��� ��������� ������
        int index = 0;
        int countEnemy = 0;
        ClearEnemy++; // ����������� ������� ��� ������� ������

        // ��������� ������
        for (int i = -25; i < 25; i++)
        {
            _direction = new Vector2(i, raydistance);
            RaycastHit2D hit = Physics2D.Raycast(transform.localPosition, _direction, raydistance, maskEnemy);

            if (hit)
            {
                if (hit.collider.gameObject.layer == 7)
                {
                    _hitBufferEnemy[countEnemy] = hit.collider.gameObject; // ��������� ����� � �����
                    DrawEnemy(ref hit, ref countEnemy, ref _spriteBuffer, ref positionEnemy);
                    _hitBufferEnemy[countEnemy].GetComponent<BoxCollider2D>().enabled = false; // ��������� ���������
                    countEnemy++;
                }
            }
            positionEnemy += 0.38f;
        }

        // ��������� �����
        for (int i = -40; i < 40; i++)
        {
            _direction = new Vector2(i - (i * 0.7f), raydistance);
            RaycastHit2D hit = Physics2D.Raycast(transform.localPosition, _direction, raydistance, maskBlock);
            Debug.DrawRay(transform.localPosition, hit.point, Color.red);
            if (hit) DrawMap(ref hit, ref _spriteBuffer, ref index, ref position);
            position += 0.23f;
            index++;
        }

        // �������� ���� ������ � ������� ���������� � ������� ������
        for (int i = 0; i < countEnemy; i++)
        {
            _hitBufferEnemy[i].GetComponent<BoxCollider2D>().enabled = true;
            _hitBufferEnemy[i] = null;
        }

        // ������� ������ �� ������ ������ 15 ���������
        if (ClearEnemy == 15)
        {
            _spriteBuffer.EnemyClearBuffer();
            ClearEnemy = 0;
        }
    }

    // ����� ��������� �����
    private void DrawMap(ref RaycastHit2D hit, ref BufferSprite sprite, ref int index, ref float position)
    {
        sprite.sprite[index].SetActive(true); // �������� ������
        sprite.sprite[index].transform.position = new Vector2(position, 0); // ���������� ������ �� ������ �������
        float y = (1f / (2 * hit.point.y)) * 4f; // ��������� ������ ������� ������������ ��� ����������

        sprite.sprite[index].transform.localScale = new Vector2(0.4f, y); // ������������ ������

        if(hit.point.y < 5) 
            sprite.sprite[index].GetComponent<SpriteRenderer>().color = Color.HSVToRGB(0f, 0f, 1f);

        if(hit.point.y > 5 && hit.point.y < 7) 
            sprite.sprite[index].GetComponent<SpriteRenderer>().color = Color.HSVToRGB(0f, 0f, 0.8f);

        if(hit.point.y > 7 && hit.point.y < 9) 
            sprite.sprite[index].GetComponent<SpriteRenderer>().color = Color.HSVToRGB(0f, 0f, 0.5f);

        if(hit.point.y > 9) 
            sprite.sprite[index].GetComponent<SpriteRenderer>().color = Color.HSVToRGB(0f, 0f, 0.2f);
    }

    private void DrawEnemy(ref RaycastHit2D hit, ref int countenemy, ref BufferSprite sprite, ref float position)
    {
        sprite.EnemyInScen[countenemy].SetActive(true); // �������� ������

        // �������� ������� ������ �� ����� �� �����
        sprite.EnemyInScen[countenemy].GetComponent<SpriteEnemyGetValue>().name = hit.collider.GetComponentInChildren<Enemy>().Name;

        sprite.EnemyInScen[countenemy].GetComponent<SpriteEnemyGetValue>().SpriteRenderer.sprite = hit.collider.GetComponent<SpriteRenderer>().sprite;

        sprite.EnemyInScen[countenemy].transform.position = new Vector2(position, 0);
        float yEnemy = (1.5f / (2 * hit.point.y)) * 2f;
        sprite.EnemyInScen[countenemy].transform.localScale = new Vector2(yEnemy, yEnemy);
    }
}
