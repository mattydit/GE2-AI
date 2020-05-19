﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class FlockAgent : MonoBehaviour
{
    private Collider agentCollider;

    // Start is called before the first frame update
    void Start()
    {
        agentCollider = GetComponent<Collider>(); 
    }

    public void Move(Vector3 velocity)
    {
        transform.forward = velocity;
        transform.position += velocity * Time.deltaTime;
    }

    public Collider GetAgentCollider
    {
        get
        {
            return agentCollider;
        }
    }
}
