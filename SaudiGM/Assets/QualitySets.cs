using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualitySets : MonoBehaviour
{
    public int qualityIndex;
    //private GameObject[] children;

    private void Update()
    {
        Transform[] children = this.transform.GetComponentsInChildren<Transform>();
        
        
        
        int qualityLevel = QualitySettings.GetQualityLevel();
        if (qualityLevel >= qualityIndex)
        {
            for (int i = 0; i < children.Length; i++)
                children[i].gameObject.SetActive(true);
            //gameObject.SetActive(true);
        }
        else if (qualityLevel < qualityIndex)
        {
            for (int i = 0; i < children.Length; i++)
                children[i].gameObject.SetActive(false);
            //gameObject.SetActive(false);
        }
        Debug.Log(children);
    }
}
