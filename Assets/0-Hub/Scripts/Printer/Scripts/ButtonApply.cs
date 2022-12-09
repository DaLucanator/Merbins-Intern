using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonApply : MonoBehaviour
{
    public UnityEvent invokeButton;

    public bool keyHit = false;
    private Collider keypadCollider;
    private Color originalColor;
    private Renderer rn;

    private float colorReturnTime = 0.6f;
    private float returnColor;

    void Start()
    {
        rn = GetComponent<Renderer>();
        originalColor = rn.material.color;
        keypadCollider = GetComponent<Collider>();
    }

    void Update()
    {
        if (keyHit && returnColor < Time.time)
        {
            returnColor = Time.time + colorReturnTime;
            rn.material.color = Color.green;
            keypadCollider.enabled = false;
            keyHit = false;
        }
        if (rn.material.color != originalColor && returnColor < Time.time)
        {
            keypadCollider.enabled = true;
            rn.material.color = originalColor;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Touch") && keyHit == false)
        {
            keyHit = true;
            invokeButton.Invoke();
        }
    }
}
