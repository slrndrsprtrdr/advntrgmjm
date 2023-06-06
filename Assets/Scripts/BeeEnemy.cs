using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeEnemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1.5f;
    Rigidbody2D myRigidbody;
    Transform rocketTransform; // Reference to the rocket's transform

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        rocketTransform = GameObject.FindGameObjectWithTag("Rocket").transform; // Find the rocket's transform
    }

    void FixedUpdate()
    {
        if (rocketTransform != null)
        {
            // Calculate the direction to the rocket
            Vector2 direction = rocketTransform.position - transform.position;
            direction.Normalize();

            // Move towards the rocket using MovePosition()
            myRigidbody.MovePosition((Vector2)transform.position - direction * moveSpeed * Time.fixedDeltaTime);

            // Flip the enemy sprite based on movement direction
            if (direction.x < 0)
            {
                transform.localScale = new Vector2(1f, 1f); // Facing right
            }
            else if (direction.x > 0)
            {
                transform.localScale = new Vector2(-1f, 1f); // Facing left
            }
        }
    }
}








/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeEnemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = -1.5f;
    Rigidbody2D myRigidbody;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        myRigidbody.velocity = new Vector2(moveSpeed, 0f);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        moveSpeed = -moveSpeed;
        FlipBeeEnemy();
    }

    void FlipBeeEnemy()
    {
        transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
    }
}
*/