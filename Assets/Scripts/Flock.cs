using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockAgent agentPrefab;
    private List<FlockAgent> agents = new List<FlockAgent>();
    public FlockBehaviour behaviour;

    [Range(10, 50)]
    public int startingCount = 20;
    const float agentDensity = 0.08f;

    [Range(1f, 100f)]
    public float driveFactor = 10f;
    [Range(1f, 100f)]
    public float maxSpeed = 5f;
    //[Range(1f, 10f)]
    public float neighbourRadius = 0.15f;
    [Range(0f, 1f)]
    public float avoidanceRadiusMult = 0.5f;

    private float sqMaxSpeed;
    private float sqNeighbourRadius;
    private float sqAvoidanceRadius;

    // Start is called before the first frame update
    void Start()
    {
        sqMaxSpeed = maxSpeed * maxSpeed;
        sqNeighbourRadius = neighbourRadius * neighbourRadius;
        sqAvoidanceRadius = sqNeighbourRadius * avoidanceRadiusMult * avoidanceRadiusMult;

        for (int i = 0; i < startingCount; i++)
        {
            Vector3 pos = Random.insideUnitSphere;
            pos.y = 0;

            FlockAgent newAgent = Instantiate(
                agentPrefab, 
                pos * startingCount * agentDensity,
                Quaternion.identity,
                transform
                );
            newAgent.name = "Agent " + i;
            agents.Add(newAgent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (FlockAgent agent in agents)
        {
            List<Transform> context = GetNearbyObjects(agent); 
            //testing
            //agent.GetComponentInChildren<MeshRenderer>().material.color = Color.Lerp(Color.white, Color.red, context.Count / 6f);

            Vector3 move = behaviour.CalculateMove(agent, context, this);
            move *= driveFactor;

            if (move.sqrMagnitude > sqMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }

            agent.Move(move);
            
        }
    }

    List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        List<Transform> context = new List<Transform>();
        Collider[] contextColliders = Physics.OverlapSphere(agent.transform.position, neighbourRadius);

        foreach (Collider c in contextColliders)
        {
            if (c != agent.GetAgentCollider)
            {
                context.Add(c.transform);
            }
        }

        return context;
    }

    public float GetSqAvoidanceRadius
    {
        get
        {
            return sqAvoidanceRadius;
        }
    }
}
