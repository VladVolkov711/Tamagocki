using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPosition : MonoBehaviour
{
    public static TargetPosition singlthon;

    public ParticleSystem SplashWoter;
    public AudioClip SplashWoterClip;

    public Vector3 start;
    public Vector3 end;

    public float speed;
    public int BossHealth;

    public bool IsRight;
    private IEnumerator SpawnObject;
    private bool _IsDie;
    private AudioSource _AU;

    private void Start()
    {
        singlthon = this;
        _AU = GetComponent<AudioSource>();
        SpawnObject = SpawnCorotine();

        speed = TargetSpawn.targetSpawn.Speed;

        if (TargetSpawn.targetSpawn.IsBoss == true) BossHealth = 2;
    }

    private void FixedUpdate()
    {
        if(_IsDie == false)
        {
            Moving();
            ChangePosition();
        }
    }

    public void Moving()
    {
        if (IsRight == false) transform.Translate(start * speed);
        if (IsRight == true) transform.Translate(end * speed);
    }

    public void ChangePosition()
    {
        if (transform.position.x >= 2) IsRight = false;
        if (transform.position.x <= -1.5f) IsRight = true;
    }

    public void Destroy()
    {
        //_AU.PlayOneShot(SplashWoterClip);
        SplashWoter.Play();
        _IsDie = true;
        GeneralScore.Score++; // прибавление счеита
        GameController.gameController.BossScore++;
        if(TargetSpawn.targetSpawn.Speed <= 0.1) TargetSpawn.targetSpawn.Speed += 0.01f;
        RenderOff();
        StartCoroutine(SpawnObject);
    }

    public void Damage()
    {
        DestroyBoss();
    }

    public void DestroyBoss()
    {
        BossHealth--;
        //_AU.PlayOneShot(SplashWoterClip);
        SplashWoter.Play();
        if (BossHealth <= 0)
        {
            _AU.PlayOneShot(SplashWoterClip);
            SplashWoter.Play();
            _IsDie = true;
            GameController.gameController.Score++;
            RenderOff();
            StartCoroutine(SpawnObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (TargetSpawn.targetSpawn.IsBoss == true) Damage();
            if (TargetSpawn.targetSpawn.IsBoss == false) Destroy();
        }
    }

    public void RenderOff()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    IEnumerator SpawnCorotine()
    {
        yield return new WaitForSeconds(0.8f);
        TargetSpawn.targetSpawn.Spawn();
        Destroy(gameObject);
    }
}
