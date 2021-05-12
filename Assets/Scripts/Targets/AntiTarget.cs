using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiTarget : Target
{
    //Decrease amount of points when get hitted by bullet
    public override void GetHit()
    {
        Debug.Log("Score -1");
        base.GetHit();
    }
}
