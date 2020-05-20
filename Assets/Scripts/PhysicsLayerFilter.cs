using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Filter/Physics Layer")]
public class PhysicsLayerFilter : ContextFilter
{
    public LayerMask mask;

    public override List<Transform> Filter(FlockAgent agent, List<Transform> transforms)
    {
        List<Transform> filtered = new List<Transform>();

        foreach (Transform item in transforms)
        {
            if (mask == (mask | (1 << item.gameObject.layer)))
            {
                filtered.Add(item);
            }
        }

        return filtered;
    }
}
