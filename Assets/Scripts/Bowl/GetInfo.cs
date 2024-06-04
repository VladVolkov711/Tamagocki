using UnityEngine;
using TMPro;

public class GetInfo : MonoBehaviour
{
    [SerializeField] private BowlUse _bowlUse;
    [SerializeField] private Sprite _bowlAll;
    [SerializeField] private TMP_Text _countInfo;
    [SerializeField] private int _id;
    [SerializeField] private bool _isWater;

    private void Update()
    {
        if (_isWater == true) GetInfoWater();
        else GetInfoEat();
    }

    public void BowlFull()
    {
        if(_isWater == true) SearchWater();
        else SearchEat();
    }

    private void SearchWater()
    {
        if (_bowlUse.IsFull == true) return;
        if (ProductData.ProductWater[_id].Count == 0) return;
        switch (_id)
        {
            case 0:
                ProductData.ProductWater[0].Count--;
                break;
            case 1:
                ProductData.ProductWater[1].Count--;
                break;
            case 2:
                ProductData.ProductWater[2].Count--;
                break;
        }
        _bowlUse.GetComponent<SpriteRenderer>().sprite = _bowlAll;
        _bowlUse.IsFull = true;
    }

    private void SearchEat()
    {
        if (_bowlUse.IsFull == true) return;
        if (ProductData.ProductEat[_id].Count == 0) return;
        switch (_id)
        {
            case 0:
                ProductData.ProductEat[0].Count--;
                break;
            case 1:
                ProductData.ProductEat[1].Count--;
                break;
            case 2:
                ProductData.ProductEat[2].Count--;
                break;
            case 3:
                ProductData.ProductEat[3].Count--;
                break;
        }
        _bowlUse.GetComponent<SpriteRenderer>().sprite = _bowlAll;
        _bowlUse.IsFull = true;
    }

    private void GetInfoWater()
    {
        switch (_id)
        {
            case 0:
                _countInfo.text = ProductData.ProductWater[0].Count.ToString();
                break;
            case 1:
                _countInfo.text = ProductData.ProductWater[1].Count.ToString();
                break;
            case 2:
                _countInfo.text = ProductData.ProductWater[2].Count.ToString();
                break;
        }
    }

    private void GetInfoEat()
    {
        switch (_id)
        {
            case 0:
                _countInfo.text = ProductData.ProductEat[0].Count.ToString();
                break;
            case 1:
                _countInfo.text = ProductData.ProductEat[1].Count.ToString();
                break;
            case 2:
                _countInfo.text = ProductData.ProductEat[2].Count.ToString();
                break;
            case 3:
                _countInfo.text = ProductData.ProductEat[3].Count.ToString();
                break;
        }
    }
}
