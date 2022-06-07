using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class IsPlayer : ActionNode
{
    protected override void OnStart() 
    {
        Debug.Log("Start IsPlayer");
    }

    protected override void OnStop() 
    {
        //Debug.Log("Stop IsPlayer");
    }

    protected override State OnUpdate() 
    {
        Debug.Log("Success IsPlayer");
        return State.Success;
    }
}
