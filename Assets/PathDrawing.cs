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
        // AND if trigger is pressed & released
        
            // AND if point limit is not reached
        
            // AND the object the controller has collided with is one of our points
        if (obj.gameObject.CompareTag("anchorPoint"))
        {
          // get obj.transform and store as vector3
          
          // add node to the current spline with this vector3
          
          // get obj's name (and parent) as a string
          
          // add to array of strings for exporting as CSV later
            
        }
        
        // Otherwise (If the point limit IS reached)
        
        // make a new spline
    }
}
