using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class MoveEnemy : ActionNode
{
    protected override void OnStart() 
    {
        Debug.Log("Start MoveEnemy");
    }

    protected override void OnStop() 
    {
        //Debug.Log("Stop MoveEnemy");
    }

    protected override State OnUpdate() 
    {
        Debug.Log("Success MoveEnemy");
        return State.Success;
    }
}
