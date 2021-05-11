using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    public GameSettings GameSettings;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Current GameMode: {GameSettings.gameMode}");
    }
}
