using UnityEngine;
using UnityEngine.UI;

public class UiScrollBar : MonoBehaviour
{
    [SerializeField] private Scrollbar _scrollbar;
    [SerializeField] private bool _isEnter;

    public void ScrollBarEnter()
    {
        _isEnter = true;
    }

    public void ScrollBarExit()
    {
        _scrollbar.value = 0.5f;
    }
}
