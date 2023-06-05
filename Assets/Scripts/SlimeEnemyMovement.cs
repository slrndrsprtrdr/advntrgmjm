using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = -1f;
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
        FlipSlimeEnemy();
    }

    void FlipSlimeEnemy()
    {
        transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
    }
}
