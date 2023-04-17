using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickNewLane : Task
{
    int direction;
    
    public override NodeResult Execute()
    {
        direction = Random.Range(0, 3);
        
        FollowTrack follow = tree.gameObject.GetComponent<FollowTrack>();
        if (direction == 0)
        {
            follow.SetValue("TurnRequested", Turning.LEFT);
        }
        if (direction == 1)
        {
            follow.SetValue("TurnRequested", Turning.RIGHT);
        }
        if (direction == 2)
        {
            follow.SetValue("TurnRequested", Turning.STRAIGHT);
        }

        return NodeResult.SUCCESS;
    }


}
