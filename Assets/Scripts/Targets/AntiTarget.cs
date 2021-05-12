using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiTarget : ShootableTarget
{
    public float ScorePoint = -1f;

    //Decrease points when get hitted by bullet
    public override void GetHit()
    {
        Debug.Log($"Score {ScorePoint}");
        base.GetHit();
    }
}
