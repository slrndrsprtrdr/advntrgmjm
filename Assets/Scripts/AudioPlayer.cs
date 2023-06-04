using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Bouncing")]
    [SerializeField] AudioClip bouncingClip;
    [SerializeField] [Range(0f, 1f)] float bouncingVolume = 1f;

    [Header("Firing")]
    [SerializeField] AudioClip firingClip;
    [SerializeField] [Range(0f, 1f)] float firingVolume = 1f;

    [Header("Landing")]
    [SerializeField] AudioClip landingClip;
    [SerializeField] [Range(0f, 1f)] float landingVolume = 1f;

    [Header("Turbo")]
    [SerializeField] AudioClip turboClip;
    [SerializeField] [Range(0f, 1f)] float turboVolume = 1f;

    [Header("Collision")]
    [SerializeField] AudioClip collisionClip;
    [SerializeField] [Range(0f, 1f)] float collisionVolume = 1f;

    [Header("Coin Pickup")]
    [SerializeField] AudioClip coinPickupClip;
    [SerializeField] [Range(0f, 1f)] float coinPickupVolume = 1f;

    [Header("Finished Level")]
    [SerializeField] AudioClip finishedLevelClip;
    [SerializeField] [Range(0f, 1f)] float finishedLevelVolume = 1f;
    public void BouncingClip()
    {
        PlayClip(bouncingClip, bouncingVolume);
    }

    public void FiringClip()
    {
        PlayClip(firingClip, firingVolume);
    }

    public void LandingClip()
    {
        PlayClip(landingClip, landingVolume);
    }

    public void TurboClip()
    {
        PlayClip(turboClip, turboVolume);
    }

    public void CollisionClip()
    {
        PlayClip(collisionClip, collisionVolume);
    }

    public void CoinPickupClip()
    {
        PlayClip(coinPickupClip, coinPickupVolume);
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
