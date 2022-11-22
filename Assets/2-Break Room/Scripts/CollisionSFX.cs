using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]

public class CollisionSFX : MonoBehaviour
{
    [SerializeField] AudioClip sfx;
    AudioSource AS;

    private void OnCollisionEnter(Collision collision)
    {
        AS.Play();
    }

    private void OnEnable()
    {
        AS = GetComponent<AudioSource>();
        AS.clip = sfx;
    }

}
