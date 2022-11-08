using UnityEngine;
using UnityEngine.Events;

public class ShootingCans : MonoBehaviour
{
    public GameObject projectile;
    public float force = 500;
    public Vector3 projectileRotation;

    public UnityEvent shootCan;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InstantiateProjectile();
        }
    }

    public void InstantiateProjectile()
    {
        shootCan.Invoke();
        GameObject bullet = Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(projectileRotation));
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * force);
    }
}
