using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDrawing : MonoBehaviour
{
    private SplineMesh.Spline spline;
    private SplineMesh.SplineNode currentNode, prevNode, startNode;
    private Vector3 currentCollider;

    private Boolean buttonPressed;


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
        //MAKE NEW SPLINE
#if OCULUS
         buttonPressed = OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger);
#endif

        if (spline.nodes.Count > 10 || spline.nodes.Count < 1)
        {
            if (buttonPressed == true)
            {
                // If the point limit is reached or 0 (or timer is more than 2 mins)

                // make a new spline
                spline = GetComponent<SplineMesh.Spline>();

                // starting node set past zero as zero index is reserved for profile for extrusion
                currentNode = spline.nodes[1];
            }
        }
        else
        {
            if (buttonPressed == true)
            {
                // if the object the controller has collided with is one of our points
                if (obj.gameObject.CompareTag("anchorPoint"))
                {
                    // get obj.transform and store as vector3 (direction helps for curve smoothing, not reqd, set same as position)
                    currentNode.Position = currentCollider;
                    currentNode.Direction = currentCollider;

                    // add node to the current spline with this vector3
                    spline.AddNode(new SplineMesh.SplineNode(currentNode.Position, currentNode.Direction));
                    prevNode = currentNode; //setting the current node to be "prevNode"
                    currentNode = spline.nodes[spline.nodes.Count - 1]; //updating new node to be "currentNode"


                    // get obj's name (and parent) as a string

                    // add to array of strings for exporting as CSV later
                }
            }
        }
    }