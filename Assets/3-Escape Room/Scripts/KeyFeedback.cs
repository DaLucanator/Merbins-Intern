using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class KeyFeedback : MonoBehaviour
{
    public bool keyHit = false;
    private Collider keypadCollider;

    private Color originalColor;
    private Renderer rn;

    private float colorReturnTime = 0.6f;
    private float returnColor;

    public TextMeshProUGUI display;

    public KeyPadControl keyPadControl;
    public AudioSource keyAudio1;

    // Start is called before the first frame update
    void Start()
    {
        rn = GetComponent<Renderer>();
        originalColor = rn.material.color;
        keypadCollider = GetComponent<Collider>();

        display = GameObject.FindGameObjectWithTag("Display").GetComponentInChildren<TextMeshProUGUI>();
        display.text = "";

        keyPadControl = GameObject.FindGameObjectWithTag("Keypad").GetComponent<KeyPadControl>();
    }

    // Update is called once per frame
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Touch") && keyHit == false)
        {
            keyAudio1.Play();
            var key = this.GetComponentInChildren<TextMeshProUGUI>();
            if (key != null)
            {
                keyHit = true;
                if (key.text == "BACK")
                {
                    if (display.text.Length > 0)
                        display.text = display.text.Substring(0, display.text.Length - 1);
                }
                else if (key.text == "ACCESS")
                {
                    var accessGranted = false;
                    bool onlyNumbers = int.TryParse(display.text, out int value);
                    if (onlyNumbers == true && display.text.Length > 0)
                    {
                        accessGranted = keyPadControl.CheckIfCorrect(Convert.ToInt32(display.text));
                    }

                    if (accessGranted == true)
                    {
                        display.text = "ACCESS";
                    }
                    else
                    {
                        display.text = "RETRY";
                    }
                }
                else if (key.text == "RESET")
                {
                    display.text = "";
                }
                else
                {
                    bool onlyNumbers = int.TryParse(display.text, out int value);
                    if (onlyNumbers != true)
                    {
                        display.text = "";
                    }

                    if (display.text.Length < 4)
                        display.text += key.text;
                }
                
            }
        }
    }

    
}
