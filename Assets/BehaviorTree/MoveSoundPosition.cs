using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class MoveSoundPosition : ActionNode
{
    protected override void OnStart() 
    {
        Debug.Log("Start MoveSoundPosition");
    }

    protected override void OnStop() 
    {
        //Debug.Log("Stop MoveSoundPosition");
    }

    protected override State OnUpdate() 
    {
        Debug.Log("Success MoveSoundPosition");
        return State.Success;
    }
}
