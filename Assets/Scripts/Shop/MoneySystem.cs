using UnityEngine;
using TMPro;

public class MoneySystem : MonoBehaviour
{
    public static int Money;
    public TMP_Text MoneyText;

    private void Start()
    {
        Money = 999;
        //UpMoney();
    }

    public void Update()
    {
        MoneyText.text = Money.ToString();
    }
}
