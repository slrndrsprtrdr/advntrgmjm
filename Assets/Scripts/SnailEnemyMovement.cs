using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailEnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = -0.3f;
    Rigidbody2D myRigidbody;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector2(moveSpeed, 0f);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        moveSpeed = -moveSpeed;
        FlipSnailEnemy();
    }

    void FlipSnailEnemy()
    {
        transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
    }
}
