using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFire : MonoBehaviour
{
    [SerializeField] float fireSpeed = 20f;
    Rigidbody2D myRigidbody;

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
        if (collision.collider.tag == "Enemy" || collision.collider.tag == "BoxDestroyable")
        {
            Destroy(collision.gameObject);
        }
        if (collision.collider.tag == "BoxReward")
        {
            Destroy(collision.gameObject);
            //Add reward
        }

        //switch (collision.collider.tag)
        //{
        //    case "EnemyShip":
        //        Destroy(collision.gameObject);
        //        break;
        //}
    }
}
