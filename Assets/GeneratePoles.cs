using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GeneratePoles : MonoBehaviour
{
    public int count;

    public GameObject prefab;

    public Vector3 direction;

    public float spacing;

    // Start is called before the first frame update
    void Awake()
    {
        GenerateObjects();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void GenerateObjects()
    {
        if (prefab == null) return;

        for (int i = 0; i < count; i++)
        {
            var pos = transform.position + direction.normalized * (spacing * i);
            var go = Instantiate(prefab, pos, quaternion.identity, transform);
            go.transform.localScale = Vector3.one * 0.1f;
        }
    }
}