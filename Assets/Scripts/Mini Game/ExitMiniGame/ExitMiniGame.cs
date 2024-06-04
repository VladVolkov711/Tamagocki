using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class ExitMiniGame : MonoBehaviour
{
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private TMP_Text _scoreText;

    private void OnEnable()
    {
        _titleText.text = "Вы проиграли";
        _scoreText.text = "Ваш счет: " + GeneralScore.Score.ToString();
    }

    public void ExitToMenue()
    {
        SceneManager.LoadScene(0);
    }
}
