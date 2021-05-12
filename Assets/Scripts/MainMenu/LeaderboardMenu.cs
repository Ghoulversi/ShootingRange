using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardMenu : MonoBehaviour
{
    public LeaderBoard LeaderBoard;
    public GameObject LeaderboardTxtPrefab;
    public Transform LeaderboardTxtParent;


    public void ShowLeaderBoard()
    {
        if (LeaderBoard.Scores == null || LeaderBoard.Scores.Count < 0) return;

        if (LeaderBoard.Scores.Count > 5)
        {
            SetLeaderboardUiData(5);
        }
        else
        {
            SetLeaderboardUiData(LeaderBoard.Scores.Count);
        }
    }

    private void SetLeaderboardUiData(int count)
    {
        int index = 0;

        for (int x = 0; x < count; x++)
        {
            var txtObj = Instantiate(LeaderboardTxtPrefab, LeaderboardTxtParent);
            txtObj.GetComponent<TextMeshProUGUI>().text = $"{++index}. Player - Score: {LeaderBoard.Scores[x]}";
        }
    }
}
