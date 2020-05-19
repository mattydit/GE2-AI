﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JitterWander : MonoBehaviour
{
    public float power = 100;
    public Vector3 seekTarget;
    public float distance = 20;
    public float radius = 10;
    public float jitter = 100;

    public Vector3 target;
    public Vector3 worldTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrawGizmos()
    {
        Vector3 localCP = Vector3.forward * distance;
        Vector3 worldCP = transform.TransformPoint(localCP);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(worldCP, radius);

        Vector3 localTarget = (Vector3.forward * distance) + target;
        worldTarget = transform.TransformPoint(localTarget);
        Gizmos.DrawSphere(worldTarget, 0.1f);
        Gizmos.DrawLine(transform.position, worldTarget);

    }
}
