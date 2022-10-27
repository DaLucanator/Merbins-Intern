using UnityEngine;

public class DestroyTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<TrashAllowed>())
        {
            Destroy(other.gameObject);
        }
    }
}
