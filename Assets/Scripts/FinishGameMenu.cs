﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGameMenu : MonoBehaviour
{
    public GameObject FinishGameUI;
    public LeaderBoard LeaderBoard;

    public GameObject BestScoreTxtObj;

    private void Start()
    {
        GameEvents.current.onFinishGameTriggerEvent += FinishGame;
    }

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }


    private void FinishGame(float finalScore)
    {
        LeaderBoard.AddToLeaderBoard(finalScore);
        FinishGameUI.SetActive(true);
        Time.timeScale = 0f;

        if (finalScore > LeaderBoard.BestScore)
            BestScoreTxtObj.SetActive(true);
    }
}
