using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerToEvent : MonoBehaviour
{
    [SerializeField] Component requirement;
    UnityEvent triggeredEvent;



    private void OnTriggerEnter(Collider other)
    {
         if(other.GetComponent(requirement.GetType()))
        {
            triggeredEvent.Invoke();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
