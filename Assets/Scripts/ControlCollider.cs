using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;


[ExecuteAlways]
public class ControlCollider : MonoBehaviour
{
    public Transform target_1;
    public Transform target_2;

#if OCULUS
[FormerlySerializedAs("controller")] public OVRInput.Controller offsetAdjustableByController;
#endif

    [Header("Uniform movement")] public Camera cam;
    public Vector2 offset;

    private bool self;

    [Range(-3, 10)] public float forwardOffset;

    [Range(-3, 10)] public float rightOffset;

    [Range(-3, 10)] public float upOffset;

    void Start()
    {
        self = target_1 == null;

        cam = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
#if OCULUS
        if (offsetAdjustableByController == OVRInput.Controller.LTouch || offsetAdjustableByController == OVRInput.Controller.RTouch)
            forwardOffset +=
 OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, offsetAdjustableByController).y * Time.deltaTime;
#endif
        Vector3 dist = target_2.position - target_1.position;
        transform.position = (dist * 0.5f) + target_1.position;

       // transform.localScale = new Vector3(dist.x, dist.y, dist.z);

        Vector3 a = target_1.position;
        Vector3 b = target_2.position;
        Vector3 c = new Vector3((target_1.position.x + target_2.position.x) / 2,
            (target_1.position.y + target_2.position.y) / 2, (target_1.position.z + target_2.position.z) / 2);

        /*
        Vector3 side1 = b - a;
        Vector3 side2 = c - a;

        Vector3 perp = Vector3.Cross(side2, side1);

        perp = perp / perp.magnitude;

        transform.LookAt(perp);
*/

        Vector3 middle = (target_1.up + target_2.up).normalized; // this axis will not be totally respected in the final rotation, but its useful as a guideline
        Vector3 from_to = target_2.position - target_1.position; // this will be the Z axis, connecting the positions of two controllers
        
        transform.localRotation = Quaternion.LookRotation(from_to, middle);
        
        transform.localScale = new Vector3(5, 0.001f, from_to.magnitude);    
        
        Debug.DrawRay(transform.position, middle*10f, Color.yellow);
        Debug.DrawRay(transform.position, from_to*10f, Color.blue);
        Debug.DrawRay(transform.position, transform.up*10f, Color.green);
        // This aligns the object's Z axis to the desored direction
        
        
       // transform.localScale = 
        //
        // if (self) target_1 = transform;
        //
        // transform.position = target_1.position +
        //                      transform.forward * forwardOffset + transform.right * rightOffset +
        //                      transform.up * upOffset;
        // transform.rotation = target_1.rotation;
        //
        //
        var frwrd = cam.transform.forward;
        frwrd.y = 0;
        //
        var right = cam.transform.right;
        right.y = 0;

#if OCULUS
        offset = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, controller) * Time.deltaTime;

#endif

#if UNITY_EDITOR
        offset = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Time.deltaTime;
#endif
        transform.position += frwrd * offset.y + right * offset.x;
    }
}