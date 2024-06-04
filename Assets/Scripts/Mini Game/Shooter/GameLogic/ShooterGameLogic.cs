using UnityEngine;

public class ShooterGameLogic : MonoBehaviour
{
    [SerializeField] private BufferSprite _spriteBuffer; // буффер спрайтов для отрисовки карты и объектов
    [SerializeField] private LayerMask maskBlock; // маска для обнаружения стены
    [SerializeField] private LayerMask maskEnemy; // маска для обнаружения врага
    [SerializeField] private float raydistance; // длина луча
    [SerializeField] private GameObject[] _hitBufferEnemy; // буффер врагов для отключения коллайдера
    private Vector2 _direction; // вектор направления луча

    public int ClearEnemy; // счетчик для очистки врагов на экране

    private void Start()
    {
        _hitBufferEnemy = new GameObject[10];
    }

    private void FixedUpdate()
    {
        float position = -9f; // позиция для отрисовки карты
        float positionEnemy = -9f; // позиция для отрисовки врагов
        int index = 0;
        int countEnemy = 0;
        ClearEnemy++; // увеличиваем счетчик для очистки врагов

        // отрисовка врагов
        for (int i = -25; i < 25; i++)
        {
            _direction = new Vector2(i, raydistance);
            RaycastHit2D hit = Physics2D.Raycast(transform.localPosition, _direction, raydistance, maskEnemy);

            if (hit)
            {
                if (hit.collider.gameObject.layer == 7)
                {
                    _hitBufferEnemy[countEnemy] = hit.collider.gameObject; // добавляем врага в буфер
                    DrawEnemy(ref hit, ref countEnemy, ref _spriteBuffer, ref positionEnemy);
                    _hitBufferEnemy[countEnemy].GetComponent<BoxCollider2D>().enabled = false; // отключаем коллайдер
                    countEnemy++;
                }
            }
            positionEnemy += 0.38f;
        }

        // отрисовка карты
        for (int i = -40; i < 40; i++)
        {
            _direction = new Vector2(i - (i * 0.7f), raydistance);
            RaycastHit2D hit = Physics2D.Raycast(transform.localPosition, _direction, raydistance, maskBlock);
            Debug.DrawRay(transform.localPosition, hit.point, Color.red);
            if (hit) DrawMap(ref hit, ref _spriteBuffer, ref index, ref position);
            position += 0.23f;
            index++;
        }

        // включаем всем врагам в буффере коллайдеры и очищаем буффер
        for (int i = 0; i < countEnemy; i++)
        {
            _hitBufferEnemy[i].GetComponent<BoxCollider2D>().enabled = true;
            _hitBufferEnemy[i] = null;
        }

        // очищаем врагов на экране каждие 15 отрисовок
        if (ClearEnemy == 15)
        {
            _spriteBuffer.EnemyClearBuffer();
            ClearEnemy = 0;
        }
    }

    // метод отрисовки карты
    private void DrawMap(ref RaycastHit2D hit, ref BufferSprite sprite, ref int index, ref float position)
    {
        sprite.sprite[index].SetActive(true); // включаем спрайт
        sprite.sprite[index].transform.position = new Vector2(position, 0); // перемещаем спрайт на нужную позицию
        float y = (1f / (2 * hit.point.y)) * 4f; // вычисляем размер спрайта относительно его расстояния

        sprite.sprite[index].transform.localScale = new Vector2(0.4f, y); // масштабируем спрайт

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
        sprite.EnemyInScen[countenemy].SetActive(true); // включаем спрайт

        // передаем спрайту данные об враге на карте
        sprite.EnemyInScen[countenemy].GetComponent<SpriteEnemyGetValue>().name = hit.collider.GetComponentInChildren<Enemy>().Name;

        sprite.EnemyInScen[countenemy].GetComponent<SpriteEnemyGetValue>().SpriteRenderer.sprite = hit.collider.GetComponent<SpriteRenderer>().sprite;

        sprite.EnemyInScen[countenemy].transform.position = new Vector2(position, 0);
        float yEnemy = (1.5f / (2 * hit.point.y)) * 2f;
        sprite.EnemyInScen[countenemy].transform.localScale = new Vector2(yEnemy, yEnemy);
    }
}
