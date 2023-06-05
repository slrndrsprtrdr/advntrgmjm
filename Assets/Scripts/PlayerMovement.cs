using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float slideSpeed = 5f;
    [SerializeField] float bounceSpeed = 4f;
    [SerializeField] float launchSpeed = 10f;
    [SerializeField] GameObject bullet;
    //[SerializeField] Transform bulletPosition;
    [SerializeField] Transform bulletPositionL;
    [SerializeField] Transform bulletPositionR;
    float enableInputDelayTime = 3f;
    float rocketLaunchDelayTime = 1f;
    float rocketLauncherDestroyerDelayTime = 3f;
    float startNextLevelDelay = 3f;

    bool isAlive = true;
    bool gunUpgrade = false;

    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    CapsuleCollider2D myCollider;
    AudioPlayer audioPlayer;
    PlayerInput playerInput;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<CapsuleCollider2D>();
        playerInput = GetComponent<PlayerInput>();

        playerInput.enabled = false;

        Invoke("RocketLaunch", rocketLaunchDelayTime);
        Invoke("RocketLauncherDestroy", rocketLauncherDestroyerDelayTime);
        Invoke("EnableInput", enableInputDelayTime);
    }


    void Update()
    {

        if (!isAlive)
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
        if(gunUpgrade)
        {
            Instantiate(bullet, bulletPositionL.position, transform.rotation);
            Instantiate(bullet, bulletPositionR.position, transform.rotation);
            audioPlayer.FiringClip();
        }
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
        if(myCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) || myCollider.IsTouchingLayers(LayerMask.GetMask("Enemies")))
        {
            isAlive = false;
            FindObjectOfType<LevelManager>().RocketDestroy();
        }
    }

    void RocketLaunch()
    {
        myRigidbody.velocity += new Vector2(0f, launchSpeed);
    }

    void RocketLauncherDestroy()
    {
        Destroy(GameObject.FindWithTag("RocketLauncher"));
    }

    void EnableInput()
    {
        playerInput.enabled = true;
    }
    void StartNextLevel()
    {
        SceneManager.LoadScene(0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.collider.tag)
        {
            case "RocketLanding":
                Invoke("StartNextLevel", startNextLevelDelay);
                playerInput.enabled = false;
                Invoke("EnableInput", enableInputDelayTime);
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "GunUpgrade":
                gunUpgrade = true;
                Destroy(collision.gameObject);
                break;

            case "LifeUpgrade":
                FindObjectOfType<LevelManager>().IncreaseLife();
                Destroy(collision.gameObject);
                break;

            case "BonusLevel":
                SceneManager.LoadScene(0);
                break;
        }
    }
}
