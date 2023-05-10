using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITransition : MonoBehaviour
{
    //ì¡°ê±´?¤ì„ ?•ì˜
    
    public List<AIDecision> decisions; //ê²°ì • ?¬í•­?¤ì„ listë¡?

    public AIState positiveResult; //ëª¨ë“  decision??true?¼ë©´ ê°?ê³?
    public AIState negativeResult; //decision ì¤??˜ë‚˜?¼ë„ true ê°€ ?„ë‹ˆ?¼ë©´ ê°?ê³?
}
