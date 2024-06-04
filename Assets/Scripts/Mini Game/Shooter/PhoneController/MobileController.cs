using UnityEngine;

public class MobileController : MonoBehaviour
{
    [SerializeField] private GameObject _mobilePannel;
    private void Start()
    {
        if(PlayerMove._isMobileInput == true) _mobilePannel.SetActive(true);
        else _mobilePannel.SetActive(false);
    }
}
