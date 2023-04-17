using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowTrack : BehaviorTree
{
    public GameObject[] waypoints;
    public int index;
    public float Speed;
    public float TurnSpeed;
    public float Accuracy;

    void Start()
    {
        Selector TreeRoot = new Selector();
        Sequence Travel = new Sequence();
        MoveTo MoveToWP = new MoveTo();
        PlayerChangeLane ChangeLane = new PlayerChangeLane();
        SelectNextGameObject PickNextWP = new SelectNextGameObject();

        Speed = 10.0f;
        TurnSpeed = 15.0f;
        Accuracy = 2.0f;

        SetValue("TurnRequested", Turning.STRAIGHT);
        SetValue("Waypoints", waypoints);
        SetValue("Waypoint", waypoints[0]);
        SetValue("Index", 0);
        SetValue("Speed", Speed);
        SetValue("TurnSpeed", TurnSpeed);
        SetValue("Accuracy", Accuracy);
        SetValue("Direction", 1);


        //set keys and connect to blackboard
        MoveToWP.TargetName = "Waypoint";
        PickNextWP.DirectionKey = "Direction";
        PickNextWP.ArrayKey = "Waypoints";
        PickNextWP.GameObjectKey = "Waypoint";
        PickNextWP.IndexKey = "Index";


        // build the tree
        TreeRoot.children.Add(Travel);
        Travel.children.Add(MoveToWP);
        Travel.children.Add(PickNextWP);
        Travel.children.Add(ChangeLane);
        Travel.tree = this;
        TreeRoot.tree = this;
        MoveToWP.tree = this;
        PickNextWP.tree = this;
        ChangeLane.tree = this;
        root = TreeRoot;

    }
    // Update is called once per frame
    public override void Update()
    {
        SetValue("Speed", Speed);
        SetValue("TurnSpeed", TurnSpeed);
        SetValue("Accuracy", Accuracy);

        base.Update();
    }
    
}
