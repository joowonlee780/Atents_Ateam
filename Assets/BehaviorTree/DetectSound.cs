using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class DetectSound : ActionNode
{
    
    protected override void OnStart() 
    {
        Debug.Log("Start DetectSound");
    }

    protected override void OnStop() 
    {
        //Debug.Log("Stop DetectSound");
    }

    protected override State OnUpdate() 
    {
        Debug.Log("Success DetectSound");
        return State.Success;
    }
}
