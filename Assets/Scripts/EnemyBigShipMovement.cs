using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBigShipMovement : MonoBehaviour
{
    [SerializeField] float moveSpeedX = 3f;
    [SerializeField] float moveSpeedY = 2f;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletPositionLeft;
    [SerializeField] Transform bulletPositionRight;
    [SerializeField] int numberOfLives = 20;
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
            Instantiate(bullet, bulletPositionLeft.position, transform.rotation);
            Instantiate(bullet, bulletPositionRight.position, transform.rotation);
            bulletTimer = 0.9f;
        }
        myRigidbody.velocity = new Vector2(moveSpeedX, moveSpeedY);

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        moveSpeedX = -moveSpeedX;
        moveSpeedY = -moveSpeedY;
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
