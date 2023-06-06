using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletPosition;
    [SerializeField] int numberOfLives = 5;
    [SerializeField] float bulletTimer;
    Rigidbody2D myRigidbody;
    bool shooting = false;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        bulletTimer -= Time.deltaTime;
        if (bulletTimer <= 0f)
        {
            Instantiate(bullet, bulletPosition.position, transform.rotation);
            bulletTimer = 1f;
        }
        myRigidbody.velocity = new Vector2(moveSpeed, 0f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        moveSpeed = -moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            numberOfLives--;
            if (numberOfLives == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
