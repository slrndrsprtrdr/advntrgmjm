using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinEffect : MonoBehaviour
{
    [SerializeField] int coinPoints = 100;
    AudioPlayer audioPlayer;
    [SerializeField] ParticleSystem coinEffect;
    [SerializeField] float destroyCoinDelay = 0.1f;
    [SerializeField] int collectedCoins = 0;
    

    bool coinCollected = false;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void DestroyCoin()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Rocket" && !coinCollected)
        {
            audioPlayer.CoinPickupClip();
            coinEffect.Play();
            coinCollected = true;
            FindObjectOfType<LevelManager>().PointsToScore(coinPoints);
            //gameObject.GetComponent<SpriteRenderer>().enabled = false;
            //Invoke("DestroyCoin", destroyCoinDelay);
        }
    }
}
