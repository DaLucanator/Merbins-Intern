using UnityEngine;

public class SodaCans : MonoBehaviour
{
    [SerializeField] string newName;

    void Awake()
    {
        gameObject.name = newName;
    }

    public void DestroyTimer()
    {
        Destroy(gameObject);
    }
}
