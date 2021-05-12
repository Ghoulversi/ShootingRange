using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public GameSettings GameSettings;

    public TextMeshProUGUI TimeRemainingTxt;
    public float GamePlayTime = 60f;

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log($"Current GameMode: {GameSettings.gameMode}");
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        while (GamePlayTime > 0)
        {
            TimeRemainingTxt.text = $"Time: {Mathf.FloorToInt(GamePlayTime % 60)}";
            Debug.Log("Countdown: " + GamePlayTime);
            yield return new WaitForSeconds(1.0f);
            GamePlayTime--;
        }

        Debug.Log("Game Over");
        TimeRemainingTxt.text = "Time: 0";
        GamePlayTime = 0;
    }

    //Load GameScene
        public void ExitToMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}
