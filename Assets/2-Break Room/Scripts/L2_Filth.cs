using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class L2_Filth : MonoBehaviour
{
    [SerializeField] L2_SpongeScript sponge;
    [SerializeField] Vector3 v_axisOfFreedom;
    [SerializeField] float f_cleanMaxAmount = 100;
    [SerializeField] float f_cleanProgress = 100;
    Vector3 v_startScale;
 

    private void OnEnable()
    {
        f_cleanProgress = f_cleanMaxAmount;
        v_startScale = transform.localScale;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == sponge.gameObject)
        {
            sponge.interacting(true, v_axisOfFreedom, this);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == sponge.gameObject)
        {
            sponge.interacting(false, Vector3.zero, this);
        }
    }
    public void cleanProgress(float amount)
    {
        f_cleanProgress -= amount*5;// change the multiplier to increase the clean speed
        f_cleanProgress = f_cleanProgress < 0 ? 0 : f_cleanProgress;
        transform.localScale = v_startScale * (f_cleanProgress / f_cleanMaxAmount);
        if(f_cleanProgress / f_cleanMaxAmount <= 0.05)
        {
            sponge.interacting(false, Vector3.zero, this);
            StartCoroutine(Done());
        }
    }



    IEnumerator Done()
    {
        sponge.interacting(false, Vector3.zero, this);
        //animation or particles
        yield return new WaitForSeconds(0.2f);
        sponge.FilthCleaned();
        Destroy(gameObject);

    }

}
