using UnityEngine;

public class MobilOrPC : MonoBehaviour
{
    [SerializeField] private GameObject m_Prefab;
    public void Mobile()
    {
        PlayerMove._isMobileInput = true;
        m_Prefab.SetActive(false);
    }

    public void PC()
    {
        PlayerMove._isMobileInput = false;
        m_Prefab.SetActive(false);
    }
}
