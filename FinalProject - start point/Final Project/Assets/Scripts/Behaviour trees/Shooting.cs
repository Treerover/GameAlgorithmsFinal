using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : BehaviorTree
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
        Selector TreeRoot = new Selector();
        Sequence Travel = new Sequence();
        DetectTarget DetectTargetTask = new DetectTarget();
        ZapTarget zapTargetTask = new ZapTarget();
        DamageBoid damageBoidTask = new DamageBoid();

        SetValue("Target", target);

        zapTargetTask.targetKey = "Target";

        TreeRoot.children.Add(Travel);
        Travel.children.Add(DetectTargetTask);
        Travel.children.Add(zapTargetTask);
        Travel.children.Add(damageBoidTask);

        Travel.tree = this;
        DetectTargetTask.tree = this;
        zapTargetTask.tree = this;
        damageBoidTask.tree = this;

        root = TreeRoot;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
}
