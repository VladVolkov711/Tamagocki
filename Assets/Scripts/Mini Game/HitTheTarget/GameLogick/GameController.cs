using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _exitPannel;
    public static GameController gameController;

    public GameObject ButtonClick;

    [HideInInspector] public GameObject SpawnUiKnifeSave;

    public TMP_Text ScoreText;

    public int Score;
    public int ScoreMenue;
    public int BossScore;
    public int LiveKnife;

    public bool IsClick;

    private void Start()
    {
        gameController = this;
        ButtonClick.SetActive(true);
        GeneralScore.Score = 0;
        BossScore = 0;
        LiveKnife = 6;
        TargetSpawn.targetSpawn.Spawn();
    }

    private void Update()
    {
        if (_exitPannel.activeInHierarchy == true) return;
        if (LiveKnife <= 0) _exitPannel.SetActive(true);
        ScoreText.text = GeneralScore.Score.ToString();
    }

    public void Click() => IsClick = true;
}
