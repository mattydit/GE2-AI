using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SteeringBehaviour : MonoBehaviour
{
    public float weight = 1.0f;
    public Vector3 force;

    public DogAgent agent;

    public void Awake()
    {
        agent = GetComponent<DogAgent>();
    }

    public abstract Vector3 Calculate();
}
