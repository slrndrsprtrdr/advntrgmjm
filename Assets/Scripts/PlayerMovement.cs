using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float slideSpeed = 5f;
    [SerializeField] float bounceSpeed = 4f;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletPosition;

    bool isAlive = true;

    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    CapsuleCollider2D myCollider;
    AudioPlayer audioPlayer;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<CapsuleCollider2D>();
    }


    void Update()
    {
        if(!isAlive)
        {
            return;
        }
        Slide();
        Die();
    }

    void OnFire(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }
        Instantiate(bullet, bulletPosition.position, transform.rotation);
        audioPlayer.FiringClip();
    }

    void OnMove(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void OnBounce(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }
        if (value.isPressed)
        {
            myRigidbody.velocity += new Vector2(0f, bounceSpeed);
            audioPlayer.BouncingClip();
        }
    }

    void Slide()
    {
        Vector2 rocketMoveSpeed = new Vector2 (moveInput.x * slideSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = rocketMoveSpeed;
    }

    void Die()
    {
        if(myCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            isAlive = false;
            FindObjectOfType<LevelManager>().RocketDestroy();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
    }


}
