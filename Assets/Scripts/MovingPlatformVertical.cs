using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformVertical : MonoBehaviour
{
    [SerializeField] float moveSpeed = -2f;
    Rigidbody2D myRigidbody;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        myRigidbody.velocity = new Vector2(0f, moveSpeed);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        moveSpeed = -moveSpeed;
    }
}
