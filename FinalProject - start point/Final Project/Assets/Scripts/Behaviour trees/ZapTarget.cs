using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZapTarget : Task
{
    public string targetKey;
    public GameObject target;

    public override NodeResult Execute()
    {
        target = (GameObject)tree.GetValue(targetKey);
        
        if (target == null )
        {
            LineRenderer line = tree.gameObject.GetComponent<LineRenderer>();
            line.positionCount = 2;
            line.SetPosition(0, tree.gameObject.transform.position);
            line.SetPosition(1, target.transform.position);
        }

        return NodeResult.SUCCESS;
    }
   
}
