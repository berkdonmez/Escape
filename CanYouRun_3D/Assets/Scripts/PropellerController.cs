using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerController : MonoBehaviour
{
    public Animator PropellerAnim;
    public float WaitSecond;
    public BoxCollider Wind;

    public void PropellerAnimStop(string open)
    {
        if (open == "true")
        {
            PropellerAnim.SetBool("Opening",true);
            Wind.enabled = true;
        }
        else
        {
            PropellerAnim.SetBool("Opening", false);
            StartCoroutine(TriggerAnimation());
            Wind.enabled = false;
        }

    }

    IEnumerator TriggerAnimation()
    {
        yield return new WaitForSeconds(WaitSecond);
        PropellerAnimStop("true");

    }
}
