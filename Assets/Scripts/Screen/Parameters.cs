using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parameters : MonoBehaviour
{
    public static Parameters instance;

    [SerializeField] private static bool _backgroundMusic = true;
    private static float _offsetTime = 0.0f;

    private void Awake()
    {
        instance = this;
    }

    public static void ActivateBackgroundMusic() {
        _backgroundMusic = true;
    }

    public static void DeactivateBackgroundMusic() {
        _backgroundMusic = false;
    }

    public static bool isBackgroundMusicActive() {
        return _backgroundMusic;
    }

    public static void SetOffsetTime(float offset) {
        _offsetTime = offset;
    }

    public static float GetOffsetTime() {
        return _offsetTime;
    }
}
