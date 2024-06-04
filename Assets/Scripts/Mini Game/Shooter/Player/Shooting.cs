using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private LayerMask _enemymask;
    [SerializeField] private Image _aim;
    [SerializeField] private Sprite[] _aimChenge;
    [SerializeField] private SpriteAnimator[] _animatorPistol;

    private void Update()
    {
        if (PlayerMove._isMobileInput == false) Shoot();
    }

    public void Shoot()
    {
        if (_animatorPistol[1]._isStartAnim == false && _animatorPistol[0]._isStartAnim == false) _animatorPistol[0].StartAnim();

        if (!Input.GetKeyDown(KeyCode.Mouse0) && PlayerMove._isMobileInput == false) return;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 20, _enemymask);
        _animatorPistol[0].StopAnim();
        _animatorPistol[1].StartAnim();

        if (hit)
        {
            hit.collider.GetComponent<Enemy>().Health -= _damage;
            hit.collider.GetComponent<Enemy>()._anim[1].StartAnim(); // попадание урона

            if (hit.collider.GetComponent<Enemy>().Health <= 0)
            {
                GeneralScore.Score++;
                hit.collider.GetComponent<Enemy>()._anim[2].StartAnim(); // смерть
            }
        }
    }
}
