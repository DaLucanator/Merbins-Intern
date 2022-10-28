using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class KeyDetector : MonoBehaviour
{
    public TextMeshProUGUI display;

    public KeyPadControl keyPadControl;
    // Start is called before the first frame update
    void Start()
    {
        display = GameObject.FindGameObjectWithTag("Display").GetComponentInChildren<TextMeshProUGUI>();
        display.text = "";

        keyPadControl = GameObject.FindGameObjectWithTag("Keypad").GetComponent<KeyPadControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KeypadButton"))
        {
            var key = other.GetComponentInChildren<TextMeshProUGUI>();
            if (key != null)
            {
                var keyFeedback = other.gameObject.GetComponent<KeyFeedback>();

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
                keyFeedback.keyHit = true;
            }
        }
    }
}
