using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class InteractObject : ActionNode
{
    protected override void OnStart() 
    {
        Debug.Log("Start InteractObject");
    }

    protected override void OnStop() 
    {
        //Debug.Log("Stop InteractObject");
    }

    protected override State OnUpdate() 
    {
        Debug.Log("Success InteractObject");
        return State.Success;
    }
}
