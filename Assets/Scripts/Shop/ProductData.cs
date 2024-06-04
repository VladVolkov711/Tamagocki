using UnityEngine;

public class ProductData : MonoBehaviour
{
    public static ProductData Instance;
    public static Product[] ProductEat;
    public static Product[] ProductWater;

    private void Awake()
    {
        Instance = this;
        ProductEat = Resources.LoadAll<Product>("Data/DataEat");
        ProductWater = Resources.LoadAll<Product>("Data/DataWater");

        BubbleSort(ProductEat);
        BubbleSort(ProductWater);
    }

    public void BubbleSort(Product[] a)
    {
        Product reserv;

        for (int i = 0; i < a.Length; i++)
        {
            for (int j = 0; j < a.Length - 1; j++)
            {
                if (a[j].ID > a[j + 1].ID)
                {
                    reserv = a[j + 1];
                    a[j + 1] = a[j];
                    a[j] = reserv;
                }
            }
        }
    }
}
