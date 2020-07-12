﻿using UnityEngine;

public class SpeedPad : ObstalcleBase
{
    [SerializeField] private float speedMultiplier = 2f;
    [SerializeField] AudioClip[] blockSounds = null;
    private AudioSource myAudioSorce;

    private void Awake()
    {
        myAudioSorce = GetComponent<AudioSource>();
    }

    private void PlaySound()
    {
        AudioClip clip = blockSounds[Random.Range(0, blockSounds.Length)];

        myAudioSorce.PlayOneShot(clip);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsObjectBall(collision.gameObject))
        {
            var ball = GetBallComponent(collision.gameObject);
            
            if (ball)
            {
                ball.IncreaseSpeed(speedMultiplier);

                PlaySound();
            }
        }
    }
}
