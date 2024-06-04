using UnityEngine;

public class BowlUse : MonoBehaviour
{
    [SerializeField] private BowlOpenMeneger openMeneger;
    [SerializeField] private GameObject _scroll;
    [SerializeField] private Sprite _bowlFull;
    [SerializeField] internal Sprite _bowlEmpty;
    public bool IsFull;
    public bool _isOpen;
    private void OnMouseDown()
    {
        openMeneger.OpenManagerEat();
        openMeneger.OpenManagerWater();

        if (_isOpen == false)
        {
            _scroll.SetActive(true);
            _isOpen = true;
        }
        else
        {
            _scroll.SetActive(false);
            _isOpen = false;
        }
    }
}
