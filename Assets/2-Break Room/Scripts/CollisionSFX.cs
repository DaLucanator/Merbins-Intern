using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]


public class CollisionSFX : MonoBehaviour
{
    [SerializeField] AudioClip sfx;
    AudioSource AS;
    float cooldown = -0.2f;
    float activeCooldown;

    private void OnCollisionEnter(Collision collision)
    {
        if (activeCooldown >= 0)
        {
            AS.Play();
            activeCooldown = cooldown;
        }
        
    }

    private void OnEnable()
    {
        AS = GetComponent<AudioSource>();
        if (sfx != null)
            AS.clip = sfx;
    }
    private void FixedUpdate()
    {
        if (activeCooldown < 0)
        {
            activeCooldown += Time.deltaTime;
        }
    }
}
