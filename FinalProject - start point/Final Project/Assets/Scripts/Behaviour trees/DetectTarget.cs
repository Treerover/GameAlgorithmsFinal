using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTarget : Task
{
    public GameObject HitTar;

    public override NodeResult Execute()
    {
        LayerMask layerm = (LayerMask)tree.GetValue("Mask");
        RaycastHit hit;
        if (Physics.Raycast(tree.gameObject.transform.position, tree.gameObject.transform.forward, out hit, 20.0f, layerm))
        {
            tree.SetValue("Target", hit.transform.gameObject);
            return NodeResult.SUCCESS;
        }
        else
        {
            tree.gameObject.GetComponent<LineRenderer>().positionCount = 0;
            return NodeResult.RUNNING;
        }
    }
}
