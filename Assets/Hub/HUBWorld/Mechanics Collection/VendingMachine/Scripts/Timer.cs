using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] float currentTime = 0f;
    [SerializeField] float setTime = 10f;
    [SerializeField] bool loop = false;
    [SerializeField] bool downOrUp = false;

    [SerializeField] Text countText;

    bool callOnce = true;

    public UnityEvent startTime;
    public UnityEvent endTime;

    void Start()
    {
        startTime.Invoke();
        if (downOrUp == false)
        {
            currentTime = setTime;
        }
    }

    private void Update()
    {
        if (downOrUp == false) // Count Down
        {
            currentTime -= 1 * Time.deltaTime;

            if (countText != null)
            {
                countText.text = currentTime.ToString("0");
            }

            if (currentTime <= 0)
            {
                currentTime = 0;
            }

            if (currentTime == 0)
            {
                if (callOnce)
                {
                    callOnce = false;
                    endTime.Invoke();

                    if (loop == true)
                    {
                        currentTime = setTime;
                        callOnce = true;
                    }
                }
            }
        }
        else // Count Up
        {
            currentTime += 1 * Time.deltaTime;

            if (countText != null)
            {
                countText.text = currentTime.ToString("0");
            }

            if (currentTime >= setTime)
            {
                currentTime = setTime;
                //endTime.Invoke();
            }

            if (currentTime == setTime)
            {
                if (callOnce)
                {
                    callOnce = false;
                    endTime.Invoke();

                    if (loop == true)
                    {
                        currentTime = 0;
                        callOnce = true;
                    }
                }
            }
        }
    }
    public void DeLog()
    {
        Debug.Log("LOL");
    }
}
