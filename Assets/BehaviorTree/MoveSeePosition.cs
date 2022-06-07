using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class MoveSeePosition : ActionNode
{
    protected override void OnStart() 
    {
        Debug.Log("Start MoveSeePosition");
    }

    protected override void OnStop() 
    {
        //Debug.Log("Stop MoveSeePosition");
    }

    protected override State OnUpdate() 
    {
        Debug.Log("Success MoveSeePosition");
        return State.Success;
    }
}
