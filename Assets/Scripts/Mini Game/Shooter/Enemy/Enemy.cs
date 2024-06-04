using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _parentOBJ;
    [SerializeField] internal SpriteAnimator[] _anim;
    [SerializeField] private float _damage;
    [SerializeField]private float _maxTimeDamage;
    private float _timeDamage;
    public string Name;
    public int Health;

    private void Start()
    {
        _timeDamage = _maxTimeDamage;
    }

    private void Update()
    {
        if (_anim[0]._isStartAnim == false && _anim[1]._isStartAnim == false && _anim[2]._isStartAnim == false) _anim[0].StartAnim();

        if (Health <= 0 && _anim[2]._isStartAnim == false) _parentOBJ.SetActive(false);

        if (_timeDamage > 0) _timeDamage -= Time.deltaTime;
        else
        {
            _parentOBJ.GetComponent<EnemyMove>()._player.GetComponent<Health>().HealthCar -= _damage;
            float rand = Random.Range(2, _maxTimeDamage);
            _timeDamage = rand;
        }
    }
}
