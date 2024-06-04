using UnityEngine;

public class SpriteFilter : MonoBehaviour
{
    public GameObject[] HitBuffer;
    public GameObject Enemy;

    private void Start()
    {
        HitBuffer = new GameObject[61];
    }

    private void FixedUpdate()
    {
        
    }
}
