using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class SphericalDistance : MonoBehaviour
{
    [Header("Object References")]
    public Transform A;
    public Transform B;

    [Header("Parameters")]
    [Range(0,10)]
    public float Radius;
    
    [Header("Read-Only")]
    public float GreatCircleDistance;
    
    private MeshRenderer mr;
    
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }
    
    void Update()
    {
        //Change Scale of Sphere
        transform.localScale = Vector3.one * Radius * 2;
        
        //Gets a vector from hand position to centre of sphere
        var v1 = A.position - transform.position;
        var v2 = B.position - transform.position;

        //normalise
        var sv1 = v1.normalized ;
        var sv2 = v2.normalized ;
        
        //calculate distance
        GreatCircleDistance = Mathf.Acos(Vector3.Dot(sv1, sv2));
        
        // SETTING DATA TO THE SHADER
        mr.sharedMaterial.SetColor("_ColorA", Color.yellow);
        
        mr.sharedMaterial.SetVector("_A", A.position);
        
       mr.sharedMaterial.SetVector("_PosA", sv1);
       mr.sharedMaterial.SetVector("_PosB", sv2);
    }

    private void SetColor(Vector3 color)
    {
        mr.sharedMaterial.SetVector("_color", new Color(color.x, color.y, color.z));
    }    
}
