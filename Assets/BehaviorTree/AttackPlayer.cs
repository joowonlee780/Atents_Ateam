using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class AttackPlayer : ActionNode
{
    protected override void OnStart() 
    {
        Debug.Log("Start AttackPlayer");
    }

    protected override void OnStop() 
    {
        //Debug.Log("Stop AttackPlayer");
    }

    protected override State OnUpdate() 
    {
        Debug.Log("Success AttackPlayer");
        return State.Success;
    }
}
