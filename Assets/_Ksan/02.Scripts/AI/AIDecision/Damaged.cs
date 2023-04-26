using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaged : AIDecision
{
    public override bool MakeADecision()
    {
        return _brain.IsDamaged;
    }
}
