using UnityEngine;

public class SwichPannel : MonoBehaviour
{
    [SerializeField] private GameObject[] _panels;
    public void OpenPannel(int id)
    {
        for (int i = 0; i < _panels.Length; i++)
        {
            if (i != id) _panels[i].SetActive(false);
            else if(i == id) _panels[i].SetActive(true);
        }
    }
}
