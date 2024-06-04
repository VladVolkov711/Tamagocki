using UnityEngine;

public class Point : MonoBehaviour
{
    public bool IsMovebl = true;
    public SpriteRenderer SpriteRenderer;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Furniture"))
        {
            IsMovebl = false;
            SpriteRenderer.color = Color.red;
        }
    }
}
