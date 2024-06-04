using UnityEngine;
using UnityEngine.UI;

public class SpriteAnimator : MonoBehaviour
{
    [SerializeField] private float _maxTime;
    [SerializeField] private Image _image;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite[] _cadrsAnim;
    [SerializeField] private bool _isUI;
    internal bool _isStartAnim;
    private float _time;
    private int _countCadr = 0;

    private void Update()
    {
        if (_isStartAnim == false) return;

        if (_countCadr <= _cadrsAnim.Length - 1)
        {
            if (_time > 0) _time -= Time.deltaTime;
            else
            {
                if (_isUI == true) _image.sprite = _cadrsAnim[_countCadr];
                else _spriteRenderer.sprite = _cadrsAnim[_countCadr];

                _countCadr++;
                _time = _maxTime;
            }
        }
        else _isStartAnim = false;
    }

    public void StartAnim()
    {
        _time = _maxTime;
        _countCadr = 0;
        _isStartAnim = true;
    }

    public void StopAnim()
    {
        _isStartAnim = false;
    }
}