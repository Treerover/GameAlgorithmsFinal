using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoid : Task
{

    public override NodeResult Execute()
    {
        GameObject target = (GameObject)tree.GetValue("Target");
        if (target != null)
        {
           Boid boid = target.GetComponent<Boid>();
            if (boid != null)
            {
                boid.speed *= 1.1f;
                boid.turnspeed *= 0.9f;

            }

        }
        return NodeResult.SUCCESS;
    }
}
