using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    float laserDisableTimer;
    float laserEnableTime = 1f;
    void Update()
    {
        laserDisableTimer -= Time.deltaTime;
        if (laserDisableTimer <= 0f)
        {
            gameObject.SetActive (false);
            laserDisableTimer = 1f;
            Invoke ("ActivateLasers", laserEnableTime);
        }
    }

    void ActivateLasers()
    {
        gameObject.SetActive (true);
    }
}
