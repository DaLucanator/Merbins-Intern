using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class L2_Filth : MonoBehaviour
{
    [SerializeField] L2_SpongeScript sponge;
    [SerializeField] Vector3 v_axisOfFreedom;
    [SerializeField] float f_cleanMaxAmount = 100;
    float f_cleanProgress = 100;
    Vector3 v_startScale;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        f_cleanProgress = f_cleanMaxAmount;
        v_startScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == sponge.gameObject)
        {
            Debug.Log("CorrectObject");
            sponge.interacting(true, v_axisOfFreedom, this);
        }else{
    Debug.Log(other.gameObject);}
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == sponge.gameObject)
        {
            Debug.Log("CorrectObject");
            sponge.interacting(false, Vector3.zero, this);
        }else{
    Debug.Log(other.gameObject);}
    }
    public void cleanProgress(float amount)
    {
        f_cleanProgress -= amount*5;// change the multiplier to increase the clean speed
        f_cleanProgress = f_cleanProgress < 0 ? 0 : f_cleanProgress;
        transform.localScale = v_startScale * (f_cleanProgress / f_cleanMaxAmount);
        Debug.LogWarning(f_cleanProgress);
        if(f_cleanProgress / f_cleanMaxAmount <= 0.05)
        {
            Debug.Log("FINISHED");
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
