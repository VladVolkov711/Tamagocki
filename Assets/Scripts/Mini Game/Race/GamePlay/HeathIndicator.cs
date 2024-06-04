using UnityEngine;

public class HeathIndicator : MonoBehaviour
{
    [SerializeField] private GameObject _target; // цель для следования
    [SerializeField] private GameObject _spriteHealth;

    private void Update()
    {
        if(Vector2.Distance(transform.position, _target.transform.position) < 2)
        {
            _spriteHealth.SetActive(false);
            return;
        }
        _spriteHealth.SetActive(true);
        var dir = _target.transform.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
