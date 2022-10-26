using UnityEngine;

public class ERFuseBox : MonoBehaviour
{
    public GameObject crystal1;
    public GameObject crystal2;
    public GameObject crystal3;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("erCrystal1"))
        {
            crystal1.SetActive(true);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("erCrystal2"))
        {
            crystal2.SetActive(true);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("erCrystal3"))
        {
            crystal3.SetActive(true);
            Destroy(other.gameObject);
        }
    }

    public void restorePower()
    {
        if(crystal1.activeSelf == true && crystal2.activeSelf == true && crystal3.activeSelf == true)
        {
            //power turned on
            Debug.Log("You turned on the power!");
        }
        else
        {
            Debug.Log("Power not restored yet...");
        }
    }
}
