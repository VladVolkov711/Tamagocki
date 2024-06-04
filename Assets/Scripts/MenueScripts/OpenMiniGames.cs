using UnityEngine.SceneManagement;
using UnityEngine;

public class OpenMiniGames : MonoBehaviour
{
    public void MiniGames(int count) => SceneManager.LoadScene(count);
}
