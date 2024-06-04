using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadInfoProduct : MonoBehaviour
{
    [SerializeField] private TMP_Text _price;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _count;
    [SerializeField] private Image _sprite;

    [SerializeField] internal PanelId _id;
    [SerializeField] internal bool _isEat;

    private void Start()
    {

        if(_isEat == true)
        {
            for (int i = 0; i < ProductData.ProductEat.Length; i++)
            {
                if (_id.Id == ProductData.ProductEat[i].ID)
                {
                    _price.text = ProductData.ProductEat[i].Price.ToString() + " $";
                    _name.text = ProductData.ProductEat[i].Name.ToString();
                    _count.text = "x" + ProductData.ProductEat[i].Count.ToString();
                    _sprite.sprite = ProductData.ProductEat[i].Image;
                }
            }
        }
        else
        {
            for (int i = 0; i < ProductData.ProductWater.Length; i++)
            {
                if (_id.Id == ProductData.ProductWater[i].ID)
                {
                    _price.text = ProductData.ProductWater[i].Price.ToString() + " $";
                    _name.text = ProductData.ProductWater[i].Name.ToString();
                    _count.text = "x" + ProductData.ProductWater[i].Count.ToString();
                    _sprite.sprite = ProductData.ProductWater[i].Image;
                }
            }
        }
    }

    public void UpdateInfoEat(int i) => _count.text = "x" + ProductData.ProductEat[i].Count.ToString();

    public void UpdateInfoWater(int i) => _count.text = "x" + ProductData.ProductWater[i].Count.ToString();
}
