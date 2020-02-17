using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArduinoData : MonoBehaviour
{
    public Vector3 arduinoData;
    public float rotationFactor;

    public Material mrToAffect;
    public GameObject objectToAffect;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        mrToAffect.SetVector("_arduinoData", new Vector3(arduinoData.x, arduinoData.y, arduinoData.z));

        float yFactor = 0;
        float zFactor = 0;
        var angles = new Vector3(rotationFactor, yFactor, zFactor);

        //send data to game object rotation
        objectToAffect.transform.localEulerAngles = angles;
    }


    public void UpdateArduino(Vector3 data)
    {
        arduinoData = data;
    }

    public void UpdateArduinoX(float data)
    {
        arduinoData.x = data;
    }

    public void UpdateArduinoY(float data)
    {
        arduinoData.y = data;
    }

    public void UpdateArduinoZ(float data)
    {
        arduinoData.z = data;
    }

    public void UpdateRotation(float data)
    {
        data = map(data, 0, 1023, -45, 45);

        rotationFactor = data;
    }

    public float map(float x, float in_min, float in_max, float out_min, float out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }
}