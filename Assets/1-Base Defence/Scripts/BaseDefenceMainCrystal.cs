using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDefenceMainCrystal : MonoBehaviour
{
    [SerializeField] private GameObject crystalRagdollObject;

    [SerializeField] private float explosionForce, explosionForceUp, explosionRadius, explosionDamage;
    [SerializeField] private GameObject explosionObject;

    [SerializeField] private GameObject lightningVFX;
    [SerializeField] private GameObject explosionVFX;

    [SerializeField] private float maxHealth;
    private float currentHealth;

    [SerializeField] private Rigidbody rb1;
    [SerializeField] private Rigidbody rb2;

    private Material material;
    private Renderer[] renderers;
    private Light[] lights;

    Gradient gradient;
    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;


    bool canTakeDamage = true;

    void Start()
    {
        material = new Material(Shader.Find("Standard"));
        renderers = gameObject.GetComponentsInChildren<Renderer>();
        lights = gameObject.GetComponentsInChildren<Light>();

        currentHealth = maxHealth;

        foreach (Renderer r in renderers)
        {
            r.material = material;
            material.color = Color.green;
        }

        foreach(Light light in lights)
        {
            light.color = Color.green;
        }

        gradient = new Gradient();

        // Populate the color keys at the relative time 0 and 1 (0 and 100%)
        colorKey = new GradientColorKey[3];
        colorKey[0].color = Color.green;
        colorKey[0].time = 0.0f;
        colorKey[1].color = new Color(1, 0.5f, 0);
        colorKey[1].time = 0.5f;
        colorKey[2].color = Color.red;
        colorKey[2].time = 0.9f;

        // Populate the alpha  keys at relative time 0 and 1  (0 and 100%)
        alphaKey = new GradientAlphaKey[3];
        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.0f;
        alphaKey[1].alpha = 1.0f;
        alphaKey[1].time = 0.5f;
        alphaKey[2].alpha = 1.0f;
        alphaKey[2].time = 0.9f;


        gradient.SetKeys(colorKey, alphaKey);

    }

    private void Update()
    {
        if (canTakeDamage)
        {
            StartCoroutine(TakeDamage());
        }
    }

    void LoseHealth()
    {
        currentHealth--;

        UpdateColour();

        if (currentHealth <= 0f)
        {
            BaseDefenceGameController.current.DeActivateEnemyPortal();
            rb1.isKinematic = false;
            rb2.isKinematic = false;
        }
    }

    void UpdateColour()
    {
        foreach (Renderer r in renderers)
        {

            float percent = 1f - (currentHealth / maxHealth);

            material.color = gradient.Evaluate(percent);

            foreach (Light light in lights)
            {
                light.color = gradient.Evaluate(percent);
            }
        }
    }

    private IEnumerator TakeDamage()
    {
        canTakeDamage = false;

        foreach (GameObject enemy in BaseDefenceGameController.current.allEnemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < (transform.localScale.x * 3f))
            {
                LoseHealth();
            }
        }

        yield return new WaitForSeconds(1f);

        canTakeDamage = true;
    }
}
