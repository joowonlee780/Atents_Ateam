using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class IsPlayerDead : ActionNode
{
    protected override void OnStart() 
    {
        Debug.Log("Start IsPlayerDead");
    }

    protected override void OnStop() 
    {
        //Debug.Log("Stop IsPlayerDead");
    }

    protected override State OnUpdate() 
    {
        Debug.Log("Success IsPlayerDead");
        return State.Failure;
    }
}
