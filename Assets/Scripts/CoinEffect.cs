using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinEffect : MonoBehaviour
{
    [SerializeField] int coinPoints = 100;

    bool coinCollected = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Rocket" && !coinCollected)
        {
            coinCollected = true;
            FindObjectOfType<LevelManager>().PointsToScore(coinPoints);
            Destroy(gameObject);
        }
    }
}
