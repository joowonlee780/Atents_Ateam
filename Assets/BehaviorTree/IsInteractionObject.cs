using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class IsInteractionObject : ActionNode
{
    protected override void OnStart() 
    {
        Debug.Log("Start IsInteractionObject");
    }

    protected override void OnStop() 
    {
        //Debug.Log("Stop IsInteractionObject");
    }

    protected override State OnUpdate() 
    {
        Debug.Log("Success IsInteractionObject");
        return State.Success;
    }
}
