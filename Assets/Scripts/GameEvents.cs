using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action<float> onScoreChangeTriggerEvent;

    public void OnScoreChangeEvent(float score)
    {
        onScoreChangeTriggerEvent?.Invoke(score);
    }

    public event Action<float> onFinishGameTriggerEvent;

    public void OnFinishGameEvent(float finalScore)
    {
        onFinishGameTriggerEvent?.Invoke(finalScore);
    }
}
