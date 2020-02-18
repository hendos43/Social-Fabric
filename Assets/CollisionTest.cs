using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionTest : MonoBehaviour
{
    public bool justCollided;
    public bool colliding;

    public CollisionEvent OnCollision;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnCollisionEnter(Collision other)
    {
        justCollided = true;
        colliding = true;
        OnCollision.Invoke();
    }

    private void OnCollisionStay(Collision other)
    {
        justCollided = false;
    }

    private void OnCollisionExit(Collision other)
    {
        colliding = false;
    }
    
    [System.Serializable]
   public class CollisionEvent:UnityEvent{} 
}
