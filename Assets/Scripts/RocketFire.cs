using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFire : MonoBehaviour
{
    [SerializeField] float fireSpeed = 20f;
    Rigidbody2D myRigidbody;
    AudioPlayer audioPlayer;
    GameObject gunUpgrade;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        myRigidbody.velocity = new Vector2(0f, fireSpeed);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (collision.collider.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
        if (collision.collider.tag == "BoxDestroyable")
        {
            audioPlayer.BoxDestructionClip();
            Destroy(collision.gameObject);
        }
        if (collision.collider.tag == "BoxReward")
        {
            audioPlayer.BoxDestructionClip();
            Destroy(collision.gameObject);
            GameObject gunUpgrade = (GameObject)Instantiate(Resources.Load("Life Upgrade"));
            gunUpgrade.transform.position = collision.transform.position;
        }

        //switch (collision.collider.tag)
        //{
        //    case "EnemyShip":
        //        Destroy(collision.gameObject);
        //        break;
        //}
    }
}
