using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2_Remodelable : MonoBehaviour
{
    [SerializeField] Material[] materials;
    [SerializeField] List<MeshRenderer> lMRs = new List<MeshRenderer>();
    L2_RemodelData rData;
    [SerializeField] int i_id;

    [SerializeField] int appearance;
    [SerializeField] bool selfDependent = true;

    private void OnCollisionEnter(Collision other)
    {
        if (selfDependent)
        {
            if (other.gameObject.GetComponent<L2_RemodelTool>())
            {
                changeMaterial();
            }
        }
    }



    private void OnEnable()
    {
        MeshRenderer[] _mRsTemp = GetComponentsInChildren<MeshRenderer>();
        lMRs = new List<MeshRenderer>(_mRsTemp);

        if (TryGetComponent(out MeshRenderer _mR))
        {
            lMRs.Add(_mR);
        }

        
        foreach(MeshRenderer mR in lMRs)
        {
            mR.material = materials[0];
        }
    }

    public void changeMaterial()
    {
        appearance = appearance == materials.Length-1 ? 0 : appearance + 1;

        foreach (MeshRenderer mR in lMRs)
        {
            mR.material = materials[appearance];
        }
        rData.saveMaterial(i_id, appearance);


    }

    void Start()
    {
        rData = GameObject.FindGameObjectWithTag("L2_RemodelData").GetComponent<L2_RemodelData>();

        int tempInt = rData.savedMaterial(i_id);

        foreach (MeshRenderer mR in lMRs)
        {
            mR.material = materials[tempInt];
        }
    }

}
