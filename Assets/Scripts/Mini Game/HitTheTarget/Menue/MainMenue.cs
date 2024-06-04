using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenue : MonoBehaviour
{

    public int Score;
    public int ScoreMenue;
    public Text ScoreText;
    public GameObject Game;
    public GameObject Menue;


    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        Load();
    }

    public void StartGame()
    {
        PlayerPrefs.DeleteKey("Score");
        SceneManager.LoadScene(1);
    }

    public void Load()
    {
        Score = PlayerPrefs.GetInt("Score");
        ScoreMenue = PlayerPrefs.GetInt("ScoreMenue");

        if (Score > ScoreMenue)
        {
            ScoreMenue += Score - ScoreMenue;
            PlayerPrefs.SetInt("ScoreMenue", ScoreMenue);
            PlayerPrefs.DeleteKey("Score");
            ScoreText.text = ScoreMenue.ToString();
        }
        else ScoreText.text = ScoreMenue.ToString();
    }
}
