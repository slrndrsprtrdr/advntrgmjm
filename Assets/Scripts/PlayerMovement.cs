
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float slideSpeed = 5f;
    [SerializeField] float bounceSpeed = 4f;
    [SerializeField] float antiBounceSpeed = 2f;
    [SerializeField] float slowZoneSpeed = 3.5f;
    [SerializeField] float launchSpeed = 10f;
    [SerializeField] GameObject bullet;
    //[SerializeField] Transform bulletPosition;
    [SerializeField] Transform bulletPositionL;
    [SerializeField] Transform bulletPositionR;
    float enableInputDelayTime = 3f;
    float rocketLaunchDelayTime = 1f;
    float rocketLauncherDestroyerDelayTime = 3f;
    float startNextLevelDelay = 3f;
    float rendererEnableTime = 0.1f;
    public int numberOfLives = 3;
    int curretSceneIndex;

    [SerializeField] ParticleSystem finishedLevelEffect;
    [SerializeField] ParticleSystem collisionEffect;
    [SerializeField] ParticleSystem bounceEffect;
    [SerializeField] ParticleSystem upgradeEffect;

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
        audioPlayer.RocketLaunchClip();

        Invoke("RocketLaunch", rocketLaunchDelayTime);
        Invoke("RocketLauncherDestroy", rocketLauncherDestroyerDelayTime);
        Invoke("EnableInput", enableInputDelayTime);

        curretSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }


    void Update()
    {

        if (!isAlive)
        {
            return;
        }

        Slide();

        FindObjectOfType<HealthManager>().TakeDamage(numberOfLives);

        //Die();
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
            bounceEffect.Play();
            myRigidbody.velocity += new Vector2(0f, bounceSpeed);
            audioPlayer.BouncingClip();
        }
    }

    void OnSlow(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }
        if (value.isPressed)
        {
            myRigidbody.velocity -= new Vector2(0f, antiBounceSpeed);
        }
    }
    void Slide()
    {
        Vector2 rocketMoveSpeed = new Vector2 (moveInput.x * slideSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = rocketMoveSpeed;
    }

    //void Die()
    //{
    //    if(myCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
    //    {
    //        numberOfLives--;
    //        if(numberOfLives==0)
    //        {
    //            isAlive = true;
    //            FindObjectOfType<LevelManager>().RocketDestroy();
    //        }
    //    }
    //}

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
        FindObjectOfType<SceneBalance>().ResetSceneBalance();
        SceneManager.LoadScene(curretSceneIndex+1);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.collider.tag)
        {
            case "RocketLanding":
                audioPlayer.FinishedLevelClip();
                Invoke("StartNextLevel", startNextLevelDelay);
                playerInput.enabled = false;
                Invoke("EnableInput", enableInputDelayTime);
                finishedLevelEffect.Play();
                break;
            case "Enemy":
                Destroy(collision.gameObject);
                if (numberOfLives == 1)
                {
                    audioPlayer.ExplosionClip();
                    numberOfLives--;
                    FindObjectOfType<LevelManager>().RocketDestroy();
                }
                else
                {
                    collisionEffect.Play();
                    numberOfLives--;
                    gameObject.GetComponent<SpriteRenderer>().GetComponent<Renderer>().enabled = false;
                    Invoke("EnableRenderer", rendererEnableTime);
                    audioPlayer.CollisionClip();
                }
                break;
            case "Platform":
                collisionEffect.Play();
                numberOfLives--;
                audioPlayer.PlatformCollisionClip();
                gameObject.GetComponent<SpriteRenderer>().GetComponent<Renderer>().enabled = false;
                Invoke("EnableRenderer", rendererEnableTime);
                if (numberOfLives == 0)
                {
                    FindObjectOfType<LevelManager>().RocketDestroy();
                }
                break;
            case "BoxDestroyable":
                collisionEffect.Play();
                numberOfLives--;
                audioPlayer.BoxDestructionClip();
                gameObject.GetComponent<SpriteRenderer>().GetComponent<Renderer>().enabled = false;
                Invoke("EnableRenderer", rendererEnableTime);
                Destroy(collision.gameObject);
                if (numberOfLives == 0)
                {
                    FindObjectOfType<LevelManager>().RocketDestroy();
                }
                break;
            case "BoxReward":
                collisionEffect.Play();
                numberOfLives--;
                audioPlayer.BoxDestructionClip();
                gameObject.GetComponent<SpriteRenderer>().GetComponent<Renderer>().enabled = false;
                Invoke("EnableRenderer", rendererEnableTime);
                Destroy(collision.gameObject);
                if (numberOfLives == 0)
                {
                    FindObjectOfType<LevelManager>().RocketDestroy();
                }
                break;
            case "Laser":
                collisionEffect.Play();
                numberOfLives--;
                gameObject.GetComponent<SpriteRenderer>().GetComponent<Renderer>().enabled = false;
                Invoke ("EnableRenderer" , rendererEnableTime);
                if (numberOfLives == 0)
                {
                    FindObjectOfType<LevelManager>().RocketDestroy();
                }
            break;
        }
    }

    void EnableRenderer()
    {
    gameObject.GetComponent<SpriteRenderer>().GetComponent<Renderer>().enabled = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "GunUpgrade":
                upgradeEffect.Play();
                audioPlayer.LifeAndGunPickupClip();
                gunUpgrade = true;
                Destroy(collision.gameObject);
                break;

            case "LifeUpgrade":
                upgradeEffect.Play();
                audioPlayer.LifeAndGunPickupClip();
                FindObjectOfType<LevelManager>().IncreaseLife();
                Destroy(collision.gameObject);
                break;

            case "SlowZone":
                myRigidbody.velocity -= new Vector2(0, slowZoneSpeed);
                break;
        }
    }
}
