using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]


public class CollisionSFX : MonoBehaviour
{
    AudioSource AS;
    Rigidbody rb;
    float cooldown = -0.2f;
    [SerializeField] float activeCooldown;
    float setVelocity = 1.3f;

    private void OnCollisionEnter(Collision collision)
    {
        if (activeCooldown >= 0)
        {
            Debug.Log(collision.relativeVelocity.magnitude);
            if (collision.relativeVelocity.magnitude > setVelocity)
            {
                AS.Play();
                activeCooldown = cooldown;
                Debug.LogWarning($"PLAYING {AS.clip} SOUND from {gameObject.name} ");
            }
        }
        
    }

    private void OnEnable()
    {
        AS = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (activeCooldown < 0)
        {
            activeCooldown += Time.deltaTime;
        }
    }
}
