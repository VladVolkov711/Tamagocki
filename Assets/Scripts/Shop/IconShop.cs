using UnityEngine;
using TMPro;

public class IconShop : MonoBehaviour
{
    public MoneySystem _moneySystem;
    public GameObject ButtonPrice;
    public GameObject ButtonEqup;
    public TMP_Text PriceText;
    public TMP_Text CountProductText;
    public int price;
    public int CountProduct;

    private void Start()
    {
        CountProduct = 0;
        CountProductText.text = "x" + CountProduct.ToString();
        PriceText.text = price.ToString();
    }

    public void ByProduct()
    {
        if (MoneySystem.Money >= price)
        {
            MoneySystem.Money -= price;
            CountProduct++;
            CountProductText.text = "x" + CountProduct.ToString();
            //_moneySystem.UpMoney();
        }
    }
}
