using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float StartTime { get; set; }
    public float CurrTime { get; set; }

    public bool Enabled
    {
        get => _enabled;
        set
        {
            _enabled = value;
            StartTime = Time.time;
        }
    }

    private bool _enabled;

    [SerializeField] private TMP_Text TimeText;

    int transitionCount = 0;
    Transitions transitions;

    float firstTransitionTime = 15f;
    float secondTransitionTime = 20f;
    float thirdTransitionTime = 30f;
    float fourthTransitionTime = 50f;
    float fifthTransitionTime = 80f;
    

    // Start is called before the first frame update
    void Start()
    {
        transitions = GetComponent<Transitions>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Enabled)
        {
            return;
        }
        
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
    }

    
}