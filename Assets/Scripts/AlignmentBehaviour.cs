using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Alignment")]
public class AlignmentBehaviour : FlockBehaviour
{
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //If there's no neighbours, maintain alignment
        if (context.Count == 0)
        {
            return agent.transform.forward;
        }

        //Average of all points
        Vector3 alignmentMove = Vector3.zero;

        foreach (Transform item in context)
        {
            alignmentMove += item.transform.forward;
        }

        alignmentMove /= context.Count;

        alignmentMove.y = 0;

        return alignmentMove;
    }
}
