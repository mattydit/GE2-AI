using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/FilteredAvoidance")]
public class FilteredAvoidance : FilteredBehaviour
{
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //If there's no neighbours, no adjustment
        if (context.Count == 0)
        {
            return Vector3.zero;
        }

        //Average of all points
        Vector3 avoidanceMove = Vector3.zero;
        int numAvoid = 0;
        List<Transform> filteredContext = filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            if (Vector3.SqrMagnitude(item.position - agent.transform.position) < flock.GetSqAvoidanceRadius)
            {
                numAvoid++;
                avoidanceMove += agent.transform.position - item.position;
                avoidanceMove.y = 0;
            }

        }

        if (numAvoid > 0)
        {
            avoidanceMove /= numAvoid;
        }

        return avoidanceMove;
    }
}
