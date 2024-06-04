using UnityEngine;

public class ByProduct : MonoBehaviour
{
    public void ByProductSystem(LoadInfoProduct loadinfo)
    {
        if(loadinfo._isEat == true)
        {
            MoneySystem.Money -= ProductData.ProductEat[loadinfo._id.Id].Price;
            ProductData.ProductEat[loadinfo._id.Id].Count++;
            loadinfo.UpdateInfoEat(loadinfo._id.Id);
        }

        else
        {
            MoneySystem.Money -= ProductData.ProductWater[loadinfo._id.Id].Price;
            ProductData.ProductWater[loadinfo._id.Id].Count++;
            loadinfo.UpdateInfoWater(loadinfo._id.Id);
        }
    }
}
