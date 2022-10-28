using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeSpill : MonoBehaviour
{
    [SerializeField] [Range(0,1)] public float coffee = 0f;
    [SerializeField] GameObject coffeeParticles;
    [SerializeField] float desireDistance;

    [SerializeField] GameObject clipPlane;
    [SerializeField] GameObject collectionPoint;
    [SerializeField] GameObject startPoint;
    [SerializeField] GameObject endPoint;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(startPoint.transform.position, endPoint.transform.position, coffee);
        collectionPoint.transform.rotation = Quaternion.identity;
        clipPlane.transform.rotation = Quaternion.Euler(new Vector3(Quaternion.identity.x - 90, Quaternion.identity.y , Quaternion.identity.z + 90));

        if (coffee >= desireDistance)
        {
            coffeeParticles.SetActive(true);
        }
        else 
        {
            coffeeParticles.SetActive(false);
        }
    }
}
