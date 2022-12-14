using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{

    public AudioSource Death_Goblin;
    public GameObject deathParticles;

    // public int cubesPerAxis = 100;
    // public float delay = 0.1f;
    // public float force = 600f;
    //  public float radius = 7f;

    private int count;

    /* void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.tag.Equals("DestrucTrigger"))
         {

             other.gameObject.SetActive(false);
             //Death_Goblin.Play();
             count = count + 1;
             //cube.SetActive(true);
             //Invoke("Main", delay);

         }

         Debug.Log(count);

     }
    */


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DestrucTrigger"))

        {
            Instantiate(deathParticles, transform.position, transform.rotation);

            other.gameObject.SetActive(false);
            Death_Goblin.Play();
            count = count + 1;
            Debug.Log(count);
            //Instantiate(cube); //cube.SetActive(true);

           
        }

        /*
            void Main()
            {
                for (int x = 0; x < cubesPerAxis; x++)
                {
                    for (int y = 0; y < cubesPerAxis; y++)
                    {
                        for (int z = 0; z < cubesPerAxis; z++)
                        {
                            CreateCube(new Vector3(x, y, z));
                        }
                    }
                }
                //Destroy(gameObject);

            }

            void CreateCube(Vector3 coordinates)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                //Renderer rd = cube.GetComponent<Renderer>().material;
                //rd.material = GetComponent<Renderer>().material;

                cube.transform.localScale = transform.localScale / cubesPerAxis;

                Vector3 firstCube = transform.position - transform.localScale / 2 + cube.transform.localScale / 2;
                cube.transform.position = firstCube + Vector3.Scale(coordinates, cube.transform.localScale);

                Rigidbody rb = cube.AddComponent<Rigidbody>();
                rb.AddExplosionForce(force, transform.position, radius);

            }

        */
    }

}