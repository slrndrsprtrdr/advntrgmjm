using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipFire : MonoBehaviour
{
    [SerializeField] float fireSpeed = 15f;
    Rigidbody2D myRigidbody;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        myRigidbody.velocity = new Vector2(0f, -fireSpeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "EnemyShip")
        {
            return;
        }
        Destroy(gameObject);
    }
}
