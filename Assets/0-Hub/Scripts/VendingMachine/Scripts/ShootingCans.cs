using UnityEngine;
using UnityEngine.Events;

public class ShootingCans : MonoBehaviour
{
    public GameObject projectile;
    public Vector3 forceCans;
    public Vector3 projectileRotation;
    public GameObject instantiatePos;

    public UnityEvent shootCan;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InstantiateProjectile();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Touch"))
        {
            InstantiateProjectile();
        }
    }


    public void InstantiateProjectile()
    {
        shootCan.Invoke();
        GameObject bullet = Instantiate(projectile, instantiatePos.transform.position, transform.rotation * Quaternion.Euler(projectileRotation));
        bullet.GetComponent<Rigidbody>().AddForce(forceCans);
    }
}
