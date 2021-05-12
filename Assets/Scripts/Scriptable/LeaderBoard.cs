using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

[CreateAssetMenu(fileName = "LeaderBoard", menuName = "LeaderBoard")]
public class LeaderBoard : ScriptableObject
{
    //Get Best score so no need to look into array for best score
    public float BestScore;

    public List<float> Scores;


    public void AddToLeaderBoard(float score)
    {
        if (Scores == null)
            Scores = new List<float>();

        Scores.Add(score);
        Scores.Sort((x, y) => y.CompareTo(x));

        BestScore = Scores[0];
    }

}
