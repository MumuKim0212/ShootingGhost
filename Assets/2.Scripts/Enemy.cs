using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float speed = 0.1f;
    private int isUp;
    Player attack;

    private void Awake()
    {
        player = GameObject.Find("SpawnManager").GetComponent<Spawn>().player;
        Destroy(gameObject, 5f);
        Random.Range(0, 2);
    }
    void Update()
    {
        transform.LookAt(player.transform);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        UpDown();
    }
    private void UpDown()
    {
        if (isUp == 1)
        {
            transform.DOMoveY(0.5f, 1f);
            if (transform.position.y >= 0.4f)
                isUp = 0;
        }
        else
        {
            transform.DOMoveY(-0.5f, 1f);
            if (transform.position.y <= -0.4f)
                isUp = 1;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            attack = collision.gameObject.GetComponent<Player>();
            attack.Damage(10);
        }
    }

    private void OnDestroy()
    {
        DOTween.Clear();
    }
}
