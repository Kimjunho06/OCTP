using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAction : AIAction
{
    public override void TakeAction()
    {
        _brain.Move(true, _brain.Player.transform.position);
    }
}
