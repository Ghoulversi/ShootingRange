using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Settings", menuName = "Game Settings")]
public class GameSettings : ScriptableObject
{
    public GameMode gameMode;
}


public enum GameMode
{
    Easy,
    Normal,
    Hard
}
