﻿using System;
using System.Collections;
using System.Collections.Generic;
using SplineMesh;
using UnityEngine;

public class PathDrawing : MonoBehaviour
{
    public CollisionTest collisionTest;
    public int counter;  
    
    public bool shouldCreateNew;
    
    
    GameObject newSpline;

    /// <summary>
    /// Reference to last created spline
    /// </summary>
    private SplineMesh.Spline spline;
    private SplineMesh.SplineNode currentNode, prevNode, startNode;
    private Vector3 currentCollider;

    private Boolean buttonPressed;


    
    
    // Start is called before the first frame update
    void Start()
    {
        spline = GetComponent<Spline>();
    }

    // Update is called once per frame
    void Update()
    {
        
        /*
        if (collisionTest.colliding == true)
        {
            if (spline.nodes.Count > 10 || spline.nodes.Count < 1)
            {
                //make a new GameObject
                newSpline = new GameObject("New Spline");
                newSpline.AddComponent<SplineMesh.Spline>();

                // add the spline script to that GameObject
                spline = newSpline.GetComponent<SplineMesh.Spline>();

                if (spline.nodes == null)
                {
                    spline.nodes = new List<SplineNode>();
                    spline.nodes.Add(new SplineNode(Vector3.zero, Vector3.one));
                    spline.nodes.Add(new SplineNode(Vector3.zero, Vector3.one));

                }

                // starting node set past zero as zero index is reserved for profile for extrusion
                currentNode = spline.nodes[1];

                // initialise start/prev nodes
                startNode = prevNode = spline.nodes[0];
            }
        }
        */
        
    }


    public void OnPointCollision()
    {

        if (shouldCreateNew)
        {
            CreateNew();
        }

        else
        {
            AddNodeToExisting();
        }
        
    }

    void CreateNew()
    {
        //
        //
        
        counter = 1;
        shouldCreateNew = false;
    }

    void AddNodeToExisting()
    {
        if (counter == 10)
        {
            counter = 0;
            shouldCreateNew = true;
            return;
        }
        
        //
        //...
        //
        
        counter++;

    }
    
    /*
    void OnCollisionEnter(Collision obj)
    {
        //MAKE NEW SPLINE OR ADD TO EXISTING ONE WITH COLLIDING OBJECT
#if OCULUS
         buttonPressed = OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger);
#endif

        // If the point limit is reached or 0 (or timer is more than 2 mins)
        if (
            spline.nodes.Count > 10 || spline.nodes.Count < 1
            //true
            )
        {
            if (buttonPressed == true)
            {
                //make a new GameObject
                newSpline = new GameObject("New Spline");
                newSpline.AddComponent<SplineMesh.Spline>();

                // add the spline script to that GameObject
                spline = newSpline.GetComponent<SplineMesh.Spline>();

                if (spline.nodes == null)
                {
                    spline.nodes = new List<SplineNode>();
                    spline.nodes.Add(new SplineNode(Vector3.zero, Vector3.one));
                    spline.nodes.Add(new SplineNode(Vector3.zero, Vector3.one));

                }
                // starting node set past zero as zero index is reserved for profile for extrusion
                currentNode = spline.nodes[1];

                // initialise start/prev nodes
                startNode = prevNode = spline.nodes[0];
            }
        }
        else
        {
            if (buttonPressed == true)
            {
                // if the object the controller has collided with is one of our points
                if (obj.gameObject.CompareTag("anchorPoint"))
                {
                    // get obj position and store as vector3 (direction helps for curve smoothing, not reqd, set same as position)
                    // currentCollider = obj.transform.position;
                    currentNode.Position = currentNode.Direction = obj.transform.position;
                    // currentNode.Direction = obj.transform.position;

                    // add node to the current spline with this vector3
                    spline.AddNode(new SplineMesh.SplineNode(currentNode.Position, currentNode.Direction));
                    prevNode = currentNode; //setting the current node to be "prevNode"
                    currentNode = spline.nodes[spline.nodes.Count - 1]; //updating new node to be "currentNode"

                    // get obj's name (and parent) as a string
                    // add to array of strings for exporting as CSV later/by another script
                    
                }
            }
        }
    }
    */
}