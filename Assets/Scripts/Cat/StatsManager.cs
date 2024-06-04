using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    [SerializeField] private CatMove _catMove;
    // �������� ������� ������
    [SerializeField] private Image _eatStatImage;
    [SerializeField] private Image _waterStatImage;
    [SerializeField] public Image _energyImage;

    // ������� ������� ������
    public float _waterStatsCount;
    public float _eatStatsCount;
    public float EnergyStatsCount;
    public float PoopStatsCount;

    // ����������� ��� ���������� ������ ������
    [HideInInspector] public float _maxEnergyStatsCount = 100;
    [HideInInspector] public float _maxEatStatsCount = 100;
    [HideInInspector] public float _maxPoopStatsCount = 100;
    [HideInInspector] public float _maxWaterStatsCount = 100;

    // �������� ��� �������� ������ � ����������� ������
    public bool IsEat;
    public bool IsWater;
    public bool IsPoop;

    private void Start()
    {
        PoopStatsCount = _maxPoopStatsCount;
        _eatStatsCount = _maxEatStatsCount;
        _waterStatsCount = _maxWaterStatsCount;
        EnergyStatsCount = _maxEnergyStatsCount;
    }

    private void Update() => StatsDown();

    // ��������� �������� � ������
    private void StatsDown()
    {
        // ����������� ���
        if (_eatStatsCount > 0)
        {
            _eatStatsCount -= Time.deltaTime;
            _eatStatImage.fillAmount = _eatStatsCount / _maxEatStatsCount;
        }

        // ����������� ����
        if (_waterStatsCount > 0)
        {
            _waterStatsCount -= Time.deltaTime;
            _waterStatImage.fillAmount = _waterStatsCount / _maxWaterStatsCount;
        }

        // ����� ���������� �� ������� ����
        if (_eatStatsCount <= 30 && IsEat == false)
        {
            IsEat = true;
        }
        if (_waterStatsCount <= 50 && IsWater == false)
        {
            IsWater = true;
        }

        if (PoopStatsCount <= 0 && IsPoop == false) IsPoop = true;
    }

    public void EnergyStats()
    {
        _energyImage.fillAmount = EnergyStatsCount / _maxEnergyStatsCount;
    }
}
