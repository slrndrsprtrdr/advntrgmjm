using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Rocket Launch")]
    [SerializeField] AudioClip rocketLaunchClip;
    [SerializeField] [Range(0f, 1f)] float rocketLaunchVolume = 1f;

    [Header("Bouncing")]
    [SerializeField] AudioClip bouncingClip;
    [SerializeField] [Range(0f, 1f)] float bouncingVolume = 1f;

    [Header("Firing")]
    [SerializeField] AudioClip firingClip;
    [SerializeField] [Range(0f, 1f)] float firingVolume = 1f;

    [Header("Collision")]
    [SerializeField] AudioClip collisionClip;
    [SerializeField] [Range(0f, 1f)] float collisionVolume = 1f;

    [Header("Explosion")]
    [SerializeField] AudioClip explosionClip;
    [SerializeField] [Range(0f, 1f)] float explosionVolume = 1f;

    [Header("Coin Pickup")]
    [SerializeField] AudioClip coinPickupClip;
    [SerializeField] [Range(0f, 1f)] float coinPickupVolume = 1f;

    [Header("Life and Gun Pickup")]
    [SerializeField] AudioClip lifeAndGunPickupClip;
    [SerializeField] [Range(0f, 1f)] float lifeAndGunPickupVolume = 1f;

    [Header("Box Destruction")]
    [SerializeField] AudioClip boxDestructionClip;
    [SerializeField] [Range(0f, 1f)] float boxDestructionVolume = 1f;


    [Header("Finished Level")]
    [SerializeField] AudioClip finishedLevelClip;
    [SerializeField] [Range(0f, 1f)] float finishedLevelVolume = 1f;

    void Start()
    {
        FindObjectOfType<Music>().StopMusic();
    }

    public void RocketLaunchClip()
    {
        PlayClip(rocketLaunchClip, rocketLaunchVolume);
    }
    public void BouncingClip()
    {
        PlayClip(bouncingClip, bouncingVolume);
    }

    public void FiringClip()
    {
        PlayClip(firingClip, firingVolume);
    }

    public void CollisionClip()
    {
        PlayClip(collisionClip, collisionVolume);
    }

    public void ExplosionClip()
    {
        PlayClip(explosionClip, explosionVolume);
    }

    public void CoinPickupClip()
    {
        PlayClip(coinPickupClip, coinPickupVolume);
    }

    public void LifeAndGunPickupClip()
    {
        PlayClip(lifeAndGunPickupClip, lifeAndGunPickupVolume);
    }
    public void BoxDestructionClip()
    {
        PlayClip(boxDestructionClip, boxDestructionVolume);
    }
    public void FinishedLevelClip()
    {
        PlayClip(finishedLevelClip, finishedLevelVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
