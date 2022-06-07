using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class SeePlayer : ActionNode
{
    protected override void OnStart() 
    {
        Debug.Log("Start SeePlayer");
    }

    protected override void OnStop() 
    {
        //Debug.Log("Stop SeePlayer");
    }

    protected override State OnUpdate() 
    {
        Debug.Log("Success SeePlayer");
        return State.Success;
    }
}
