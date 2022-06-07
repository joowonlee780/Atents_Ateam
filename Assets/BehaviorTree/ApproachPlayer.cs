using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class ApproachPlayer : ActionNode
{
    protected override void OnStart() 
    {
        Debug.Log("Start ApproachPlayer");
    }

    protected override void OnStop() 
    {
        //Debug.Log("Stop ApproachPlayer");
    }

    protected override State OnUpdate() 
    {
        Debug.Log("Success ApproachPlayer");
        return State.Success;
    }
}
