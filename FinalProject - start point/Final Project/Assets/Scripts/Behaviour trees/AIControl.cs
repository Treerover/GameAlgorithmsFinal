using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControl : BehaviorTree
{
    public float waitTime;
    // Start is called before the first frame update
    void Start()
    {
       //Minimum sequence of Wait for 3 seconds, pick one of 3 directions to turn
        Selector TreeRoot = new Selector();
        Sequence Travel  = new Sequence();
        Wait WaitTask = new Wait();
        PickNewLane PickNewLaneTask = new PickNewLane();

        waitTime = 3.0f;

        SetValue("TimeToWaitKey", waitTime);
        WaitTask.TimeToWaitKey = "TimeToWaitKey";

        TreeRoot.children.Add(Travel);
        Travel.children.Add(WaitTask);
        Travel.children.Add(PickNewLaneTask);
        Travel.tree = this;
        TreeRoot.tree = this;
        WaitTask.tree = this;
        PickNewLaneTask.tree = this;
        root = TreeRoot;

    }


    public override void Update()
    {
        base.Update();
    }
}
