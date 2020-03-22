using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSoundPlayer : MonoBehaviour
{
    public AudioClip bgm;
    public AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgm;

    }

    private void OnTriggerEnter(Collider other)
    {
        audioSource.Play();
    }
}
