using UnityEngine;

public class BowlOpenMeneger : MonoBehaviour
{
    [SerializeField] private BowlUse _bowlWater;
    [SerializeField] private BowlUse _bowlEat;

    [SerializeField] private GameObject _pannelBowlWater;
    [SerializeField] private GameObject _pannelBowlEat;

    public void OpenManagerWater()
    {
        if(_bowlEat._isOpen == true) _pannelBowlEat.SetActive(false);
    }

    public void OpenManagerEat()
    {
        if (_bowlWater._isOpen == true) _pannelBowlWater.SetActive(false);
    }
}
