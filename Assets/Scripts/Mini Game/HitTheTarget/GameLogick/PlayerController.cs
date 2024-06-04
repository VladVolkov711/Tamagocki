using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip KnifeTakeWood;
    public float speed;
    private AudioSource _AU;
    private bool _IsMove;
    private PlayerController pc;

    private void Start()
    {
        pc = GetComponent<PlayerController>();
        _AU = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if(_IsMove == false)
            if (GameController.gameController.IsClick == true) transform.Translate(Vector3.up * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zone")
        {
            _IsMove = true;
            //_AU.PlayOneShot(KnifeTakeWood);
            SpawnUIKnife.singlton.DamageKnifeUi();
            GameController.gameController.LiveKnife--;
            StartCoroutine(Spawner());
        }

        if (collision.gameObject.tag == "Target")
        {
            RenderOff();
            StartCoroutine(Spawner());
        }
    }

    public void SpawnKnife()
    {
        GameController.gameController.IsClick = false;
        SpwnKnife.singlthon.Spawn();
        //GameController.gameController.Save();
        pc.enabled = false;
    }

    public void RenderOff()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(0.8f);
        SpawnKnife();
    }
}
