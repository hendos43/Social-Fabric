﻿using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

// Originally written by keijiro for his OscJack Unity asset.
// Adapted for use with this Arduino asset.
// Original code:
// https://github.com/keijiro/OscJack

[AddComponentMenu("Arduino/Arduino Property Sender")]
public class ArduinoPropertySender : MonoBehaviour
{
    
    #region Editable fields

    [SerializeField] ArduinoHandler _arduino;
    [SerializeField] int _framerate = 30;
    [SerializeField] int _command = 1;
    [SerializeField] Component _dataSource = null;
    [SerializeField] string _propertyName = "";
    
    #endregion
    
    #region Internal members
    
    PropertyInfo _propertyInfo;
    private float _frameDuration;
    private float _frameTimer;
    
    void UpdateSettings()
    {
        if (_dataSource != null && !string.IsNullOrEmpty(_propertyName))
            _propertyInfo = _dataSource.GetType().GetProperty(_propertyName);
        else
            _propertyInfo = null;

        _frameDuration = 1f / _framerate;
    }
    
    #endregion
    
    #region MonoBehaviour implementation
    
    void Start()
    {
        UpdateSettings();
    }

    void OnValidate()
    {
        if (Application.isPlaying) UpdateSettings();
    }

    void Update()
    {
        if (_propertyInfo == null) return;

        _frameTimer -= Time.deltaTime;
        if (_frameTimer > 0) return;
        _frameTimer = _frameDuration;

        var type = _propertyInfo.PropertyType;
        var value = _propertyInfo.GetValue(_dataSource, null); // boxing!!

        if (type == typeof(byte[])) 
            _arduino.SendBytes(_command, (byte[])value);
        else if (type == typeof(bool)) 
            _arduino.SendBool(_command, (bool)value);
        else if (type == typeof(int)) 
            _arduino.SendInt(_command, (int)value);
        else if (type == typeof(float)) 
            _arduino.SendFloat(_command, (float)value);
        else if (type == typeof(string)) 
            _arduino.SendString(_command, (string)value);
        else if (type == typeof(Vector2Int)) 
            _arduino.SendVector2Int(_command, (Vector2Int)value);
        else if (type == typeof(Vector3Int)) 
            _arduino.SendVector3Int(_command, (Vector3Int)value);
        else if (type == typeof(Vector2)) 
            _arduino.SendVector2(_command, (Vector2)value);
        else if (type == typeof(Vector3)) 
            _arduino.SendVector3(_command, (Vector3)value);
        else if (type == typeof(Vector4)) 
            _arduino.SendVector4(_command, (Vector4)value);
    }
    
    #endregion
    
    
}
