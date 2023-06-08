using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBigShipMovement : MonoBehaviour
{
    [SerializeField] float moveSpeedX = 1.5f;
    [SerializeField] float moveSpeedY = 3f;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletPositionLeft;
    [SerializeField] Transform bulletPositionRight;
    [SerializeField] int numberOfLives = 30;
    float bulletTimer;
    float verticalMoveTimer;
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
            bulletTimer = 1f;
        }
        verticalMoveTimer -= Time.deltaTime;
        if (verticalMoveTimer <= 0f)
        {
            moveSpeedY = -moveSpeedY;
            verticalMoveTimer = 12.5f; 
        }
        myRigidbody.velocity = new Vector2(moveSpeedX, moveSpeedY);



    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        moveSpeedX = -moveSpeedX;
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
