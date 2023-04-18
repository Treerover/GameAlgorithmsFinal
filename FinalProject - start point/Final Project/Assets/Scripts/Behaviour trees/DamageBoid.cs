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
                boid.speed *= 1.05f;
                boid.turnspeed *= 0.6f;

            }

        }
        return NodeResult.SUCCESS;
    }
}
