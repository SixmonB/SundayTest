using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;
using Firebase.Analytics;
using System.Reflection;

public class MyEventSystem : MonoBehaviour
{
    public static MyEventSystem I;

    private void Awake()
    {
        I = this;
        GameAnalytics.Initialize();
        DontDestroyOnLoad(gameObject);
    }

    public void StartLevel(int level)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, level.ToString());

        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLevelStart, new Parameter(FirebaseAnalytics.ParameterLevel, level.ToString()));
    }
    
    public void FailLevel(int level)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, level.ToString());

        FirebaseAnalytics.LogEvent("EventLevelFailed", new Parameter(FirebaseAnalytics.ParameterLevel, level.ToString()));
    }
    
    public void CompleteLevel(int level)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, level.ToString());

        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLevelEnd, new Parameter(FirebaseAnalytics.ParameterLevel, level.ToString()));
    }
}
