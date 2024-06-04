using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class ExitMiniGame : MonoBehaviour
{
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private TMP_Text _scoreText;

    private void OnEnable()
    {
        _titleText.text = "�� ���������";
        _scoreText.text = "��� ����: " + GeneralScore.Score.ToString();
    }

    public void ExitToMenue()
    {
        SceneManager.LoadScene(0);
    }
}
