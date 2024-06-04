using UnityEngine;

public class CatMove : MonoBehaviour
{
    [SerializeField] private StatsManager _statsManager;

    // хеширую трансформ кота
    [HideInInspector] private Transform _PlayerTr;

    public float CurrentX, OldX;

    public string[] ListNeeds = new string[5];
    public int countListNeeds;

    // отслеживание координат мыши
    [HideInInspector] public Vector3 ScreenMousePositin;
    [HideInInspector] public Vector3 WorldMousePosition;

    // перемещение к хотелке кота
    [SerializeField] private Transform[] _targetCat;

    //Миски с едой
    [SerializeField] private BowlUse _waterBowl;
    [SerializeField] private BowlUse _EatBowl;
     
    // скорость передвижения
    [SerializeField] private float _speed;

    // камера
    [SerializeField] private Camera camera;

    private Animator anim;
    [SerializeField] private string[] _nameAnim = new string[] 
                                                                {"CatEating", 
                                                                 "CatDrinking",
                                                                 "CatSleep" , 
                                                                 "Idle" };

    // таймер для окончания действия
    public float _timeEat;
    public float _MaxtimeEat = 4f;

    // игрок взял кота за шкирку или нет
    internal bool IsTake;

    private void Start()
    {
        anim = GetComponent<Animator>();
        _PlayerTr = GetComponent<Transform>();
        _timeEat = _MaxtimeEat;
        camera = Camera.main;
    }
    private void FixedUpdate()
    {
        if (_statsManager.IsPoop == true)
            MoveToTarget(ref _targetCat, 2, ref _nameAnim[5], ref _statsManager.IsPoop,
                ref _statsManager.PoopStatsCount, ref _statsManager._maxPoopStatsCount);

        if (_statsManager.IsWater == true && _statsManager.IsPoop == false)
            MoveToTarget(ref _targetCat, 1, ref _nameAnim[1], ref _statsManager.IsWater,
                ref _statsManager._waterStatsCount, ref _statsManager._maxWaterStatsCount);

        if (_statsManager.IsEat == true && _statsManager.IsWater == false && _statsManager.IsPoop == false)
            MoveToTarget(ref _targetCat, 0, ref _nameAnim[0], ref _statsManager.IsEat,
                ref _statsManager._eatStatsCount, ref _statsManager._maxEatStatsCount);
    }

    private void Update()
    {
        CurrentX = transform.position.x;
        if (OldX > CurrentX) transform.localScale = new Vector2(4, transform.localScale.y);
        if (OldX < CurrentX) transform.localScale = new Vector2(-4, transform.localScale.y);
        OldX = CurrentX;

        MousePosition();
        // перетаскивание кота
        if (IsTake == true) _PlayerTr.position = new Vector2(Mathf.Clamp(WorldMousePosition.x, -25f, 25f), Mathf.Clamp(WorldMousePosition.y, -3.79f, 0));
    }
    // движение к цели
    private void MoveToTarget(ref Transform[] targets, int a, ref string nameanim, ref bool stats, ref float min, ref float max)
    {
        if (_PlayerTr.position.x == targets[a].position.x)
        {
            if (_EatBowl.IsFull == false && _statsManager.IsEat == true) return;
            if (_waterBowl.IsFull == false && _statsManager.IsWater == true) return;
            anim.Play(nameanim);
            _timeEat -= Time.fixedDeltaTime;

            if (_timeEat <= 0)
            {
                if (_statsManager.IsPoop == false) _statsManager.PoopStatsCount -= 40;
                if (_statsManager.IsEat == true)
                {
                    _EatBowl.GetComponent<SpriteRenderer>().sprite = _EatBowl._bowlEmpty;
                    _EatBowl.IsFull = false;
                }
                if (_statsManager.IsWater == true)
                {
                    _waterBowl.GetComponent<SpriteRenderer>().sprite = _waterBowl._bowlEmpty;
                    _waterBowl.IsFull = false;
                }
                    anim.Play("eye_drop");
                _timeEat = _MaxtimeEat;
                min = max;
                stats = false;
            }
        }

        else
        {
            anim.Play("Walk");
            _PlayerTr.position = 
                Vector2.MoveTowards(_PlayerTr.position, targets[a].position, _speed * Time.fixedDeltaTime);
        }
    }
    // координаты мышки
    private void MousePosition()
    {
        ScreenMousePositin = Input.mousePosition; // позиция мышки относительно разрешения экрана
        WorldMousePosition = camera.ScreenToWorldPoint(ScreenMousePositin);// позиция мышки относительно координат
    }

    private void OnMouseDrag()
    {
        IsTake = true;
        anim.Play("Drag");
    }

    private void OnMouseUp()
    {
        IsTake = false;
        anim.Play("eye_drop");
    }
}
