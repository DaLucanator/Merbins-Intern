using UnityEngine;

public class DestroyTrigger : MonoBehaviour
{
    public AudioSource shreddedSound; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<TrashAllowed>())
        {
            Destroy(other.gameObject);

            if (shreddedSound != null)
            {
                shreddedSound.Play();
            }
        }
    }
}
