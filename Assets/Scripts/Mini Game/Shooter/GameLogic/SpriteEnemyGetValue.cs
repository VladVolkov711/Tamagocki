using UnityEngine;

public class SpriteEnemyGetValue : MonoBehaviour
{
    public string NameSprite;
    public SpriteRenderer SpriteRenderer;
    private void OnDisable()
    {
        NameSprite = "";
    }
}
