using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class BaseDefenseCrystal : MonoBehaviour
{
    [SerializeField] private float health = 5f;
    [SerializeField] private GameObject crystalRagdollObject;

    private float crystalScale;

    private bool isActive;

    public void SetCrystaLScale(float num)
    {
        crystalScale = num;
        gameObject.transform.localScale *= crystalScale;
        health *= num;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void Activate()
    {
        isActive = true;
        // activate a random mesh
    }

    //if I collide with a portal
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<BaseDefensePortal>() && isActive)
        {
            GameObject newCrystalRagdollObject = Instantiate(crystalRagdollObject, collider.gameObject.transform.position, Quaternion.identity);
            CrystalRagdoll crystalRagdoll = newCrystalRagdollObject.GetComponent<CrystalRagdoll>();

            crystalRagdoll.SetCrystaLScale(crystalScale);

            crystalRagdoll.Activate();

            Destroy(gameObject);
        }
    }
}
