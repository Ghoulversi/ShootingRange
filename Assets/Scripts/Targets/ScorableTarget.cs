using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorableTarget : ShootableTarget
{
    public float ScorePoint = 1f;

    //Increase or decrease points when get hitted by bullet
    public override void GetHit()
    {
        AddToScore(ScorePoint);
        base.GetHit();
    }

    private void AddToScore(float score)
    {
        GameEvents.current.OnScoreChangeEvent(score);
    }
}
