using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDrawing : MonoBehaviour
{
    
    public Transform controller;
    public GameObject[] pointArray;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.CompareTag("anchorPoint"))
        {
            // if limit is not yet reached...

            // ...add to an array for drawing the live line later
            
            // show anchorpoint (change shader):
            // if first object in array show as green
            
            // if last, show as red
            
            // otherwise show orange
            
            // run draw 
            
        }
    }
}
