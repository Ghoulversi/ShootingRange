using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public GameSettings GameSettings;
    public TextMeshProUGUI CurrentGameModeTxt;

    private void Start()
    {
        CurrentGameModeTxt.text = $"Current GameMode: {GameSettings.gameMode}";
    }

    //Set game mode settings for scriptable and local for text
    public void SetGameMode(string gameMode)
    {
        switch (gameMode)
        {
            case "easy":
                GameSettings.gameMode = GameMode.Easy;
                Debug.Log($"Set {GameSettings.gameMode} mode");
                break;
            case "normal":
                GameSettings.gameMode = GameMode.Normal;
                Debug.Log($"Set {GameSettings.gameMode} mode");
                break;
            case "hard":
                GameSettings.gameMode = GameMode.Hard;
                Debug.Log($"Set {GameSettings.gameMode} mode");
                break;
            default:
                GameSettings.gameMode = GameMode.Easy;
                Debug.Log("Set default as easy mode");
                break;

        }

        CurrentGameModeTxt.text = $"Current GameMode: {GameSettings.gameMode}";
    }
}
