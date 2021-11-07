using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioClip walkingSound;
    public AudioClip attackSound;
    public AudioSource sourceOfSounds;

    public void playStepsSound()
    {
        sourceOfSounds.volume = 0.08f;
        sourceOfSounds.pitch = Random.Range(0.9f, 1.1f);
        sourceOfSounds.PlayOneShot(walkingSound);
    }

    public void playAttackSound()
    {
        sourceOfSounds.volume = 0.08f;
        sourceOfSounds.pitch = Random.Range(0.9f, 1.1f);
        sourceOfSounds.PlayOneShot(attackSound);
    }
}
