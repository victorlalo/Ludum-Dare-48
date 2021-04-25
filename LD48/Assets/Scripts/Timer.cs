using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float StartTime { get; set; }
    public float CurrTime { get; set; }

    [SerializeField] private TMP_Text TimeText;

    int transitionCount = 0;
    Transitions transitions;

    float firstTransitionTime = 60f;
    float secondTransitionTime = 120f;
    float thirdTransitionTime = 150f;
    float fourthTransitionTime = 180f;
    float fifthTransitionTime = 210f;
    

    // Start is called before the first frame update
    void Start()
    {
        StartTime = Time.time;
        transitions = GetComponent<Transitions>();
    }

    // Update is called once per frame
    void Update()
    {
        // TimeText.text = (Time.time - StartTime).ToString();
        var ts = TimeSpan.FromSeconds(Time.time - StartTime);
        CurrTime = Time.time - StartTime;

        if (CurrTime > firstTransitionTime && transitionCount == 0)
        {
            transitions.HouseTransition();
            transitionCount++;
        }
        if (CurrTime > secondTransitionTime && transitionCount == 1)
        {
            transitions.SwapPlayerModels();
            transitionCount++;
        }
        if (CurrTime > thirdTransitionTime && transitionCount == 2)
        {
            transitions.TrippyTransition();
            transitionCount++;
        }
        if (CurrTime > fourthTransitionTime && transitionCount == 3)
        {
            transitions.NirvannaTransition();
            transitionCount++;
        }
        if (CurrTime > fifthTransitionTime && transitionCount == 4)
        {
            transitions.FadePlayer();
            transitionCount++;
        }
        
        //TimeText.text = string.Format("{0:00}:{1:00}", ts.TotalMinutes, ts.Seconds);
    }

    
}