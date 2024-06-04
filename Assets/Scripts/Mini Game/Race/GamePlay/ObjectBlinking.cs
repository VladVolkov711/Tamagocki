using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBlinking : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;

    public void Blinking() => StartCoroutine(BlinkingSprite());

    private IEnumerator BlinkingSprite()
    {
        int i = 7;
        while (i > 0)
        {
            _sprite.color = new Color(1, 1, 1, 1f);
            yield return new WaitForSeconds(0.1f);

            _sprite.color = new Color(1, 1, 1, 0f);
            yield return new WaitForSeconds(0.1f);
            i--;
        }
        _sprite.color = new Color(1, 1, 1, 1f);
    }
}
