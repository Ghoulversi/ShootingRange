using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public GameSettings GameSettings;

    public TextMeshProUGUI TimeRemainingTxt;
    public TextMeshProUGUI CurrentScoreTxt;
    public float GamePlayTime = 60f;

    private float _currentScore = 0f;

    // Start is called before the first frame update
    private void Start()
    {
        GameEvents.current.onScoreChangeTriggerEvent += OnScoreChanged;

        CurrentScoreTxt.text = "Score: 0";

        StartCoroutine(StartCountdown());
    }

    //Gameplay timer
    private IEnumerator StartCountdown()
    {
        while (GamePlayTime > 0)
        {
            yield return new WaitForSeconds(1.0f);
            TimeRemainingTxt.text = $"Time: {GamePlayTime}";
            GamePlayTime--;
        }

        Debug.Log("Game Over");
        TimeRemainingTxt.text = "Time: 0";
        GameEvents.current.OnFinishGameEvent(_currentScore);
        GamePlayTime = 0;
    }

    //change score and update UI score after hitting a target
    private void OnScoreChanged(float score)
    {
        _currentScore += score;
        if (_currentScore <= 0)
            _currentScore = 0;

        CurrentScoreTxt.text = $"Score: {_currentScore}";
    }

    //Load GameScene
    public void ExitToMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}
