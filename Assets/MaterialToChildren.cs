using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialToChildren : MonoBehaviour
{

    public Material givenMaterial;


    // Start is called before the first frame update
    void Start()
    {
ChangeMaterial(givenMaterial);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void ChangeMaterial(Material newMat)
    {
        Renderer[] children;
        children = GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in children)
        {
            var mats = new Material[rend.materials.Length];
            for (var j = 0; j < rend.materials.Length; j++)
            {
                mats[j] = newMat;
            }
            rend.materials = mats;
        }
    }
}
