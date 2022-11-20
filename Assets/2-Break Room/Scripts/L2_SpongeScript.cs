using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2_SpongeScript : MonoBehaviour
{
    //[SerializeField] GameObject[] filth;
    [SerializeField] bool currentlyInteracting;
    Vector3 lastPosition;

    Rigidbody rb;

    Vector3 v_moveValue;
    float f_ScrubValue;
    Vector3 currentAxis;
    L2_Filth currentFilth;
    Vector3 startPos;

    [SerializeField] int i_filthQuantity;
    [SerializeField] L2_CleaningManager cM;


    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }
    public void interacting(bool value, Vector3 freedomAxis, L2_Filth filth)
    {
        currentlyInteracting = value;
        currentFilth = !value ? null : currentFilth;
        currentAxis = freedomAxis;
        currentFilth = filth;
        lastPosition = transform.position;
        

    }

    private void FixedUpdate()
    {
        if (currentlyInteracting)
        {
            

            Vector3 v_diff = lastPosition - transform.position;
            v_moveValue = Vector3.Scale(v_diff, currentAxis);
            f_ScrubValue = Mathf.Abs(v_moveValue.x) + Mathf.Abs(v_moveValue.y) + Mathf.Abs(v_moveValue.z);
            f_ScrubValue *= 1;
            lastPosition = transform.position;

            if (currentFilth != null)
            {
                currentFilth.cleanProgress(f_ScrubValue);
            }

            


        }
        if (transform.position.y < -1)
        {
            transform.position = startPos;
            rb.velocity = Vector3.zero;
        }
        
    }
    public void FilthCleaned()
    {
        i_filthQuantity--;
        if (i_filthQuantity <= 0)
        {
            StartCoroutine(FilthFinished());
        }
    }
    IEnumerator FilthFinished()
    {
        //effects or particles
        yield return new WaitForSeconds(0.2f);
        cM.FinishTask(0);
        Destroy(gameObject);
    }





}
