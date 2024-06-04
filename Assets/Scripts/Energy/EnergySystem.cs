using UnityEngine;
using YG;

public class EnergySystem : MonoBehaviour
{
    public GameObject[] ItemEnergy;
    public GameObject RewardIcon;
    public int Energy;
    public int MaxEnergy;

    private void OnEnable() => YandexGame.RewardVideoEvent += RewardEnergy;
    private void OnDisable() => YandexGame.RewardVideoEvent -= RewardEnergy;

    private void Start()
    {
        SetEnergy();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) EnergyMinus();
    }

    public void SetEnergy()
    {
        int EmptyItem = MaxEnergy - Energy;

        if (EmptyItem > 0) RewardIcon.SetActive(true);
        else if (EmptyItem == 0) RewardIcon.SetActive(false);

        for (int i = 0; i < MaxEnergy; i++)
        {
            if (i < Energy) ItemEnergy[i].SetActive(true);
            else ItemEnergy[i].SetActive(false);
        }
    }

    public void RewardEnergy(int id)
    {
        if (id == 0)
        {
            Energy++;
            SetEnergy();
        }
    }

    public void EnergyMinus()
    {
        if (Energy <= 0) return;
        Energy--;
        SetEnergy();
    }

    public void ExempleOpenRewarded(int id)
    {
        YandexGame.RewVideoShow(id);
    }
}
