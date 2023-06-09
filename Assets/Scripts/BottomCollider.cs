using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomCollider : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    float responseSpeed = 1f;

    void Start()
    {
        myRigidbody = transform.parent.gameObject.GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.collider.tag)
        {
            case "Platform":
                myRigidbody.velocity += new Vector2(0f, responseSpeed);
                break;
        }
    }
}
