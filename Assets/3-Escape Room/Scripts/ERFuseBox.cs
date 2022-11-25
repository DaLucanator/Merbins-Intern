using UnityEngine;

public class ERFuseBox : MonoBehaviour
{
    public GameObject crystal1;
	public GameObject crystal2;
	public GameObject crystal3;
    public ServerLightOnOff buttonLight;
    public ServerLightOnOff lowerLight;
    public AudioSource audioPlayingCrystal;
    public AudioSource audioPlayingPowerOn;


    private GlobalLevelLoader levelLoader;
	public void Start()
	{
    	levelLoader = GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<GlobalLevelLoader>();
	}

	private void OnTriggerEnter(Collider other)
	{
    	if(other.gameObject.CompareTag("erCrystal1"))
    	{
            audioPlayingCrystal.Play();
            crystal1.SetActive(true);
        	Destroy(other.gameObject);
    	}
    	if (other.gameObject.CompareTag("erCrystal2"))
    	{
            audioPlayingCrystal.Play();
            crystal2.SetActive(true);
        	Destroy(other.gameObject);
    	}
    	if (other.gameObject.CompareTag("erCrystal3"))
    	{
            audioPlayingCrystal.Play();
            crystal3.SetActive(true);
        	Destroy(other.gameObject);
    	}
	}

	public void restorePower()
	{
        audioPlayingPowerOn.Play();
        if (crystal1.activeSelf == true && crystal2.activeSelf == true && crystal3.activeSelf == true)
    	{
        	//power turned on
        	Debug.Log("You turned on the power!");
            buttonLight.lightCheck();
            lowerLight.lightCheck();
            levelLoader.LoadLevel("HUB_GreyBox");
    	}
    	else
    	{
        	Debug.Log("Power not restored yet...");
        }
	}
}
