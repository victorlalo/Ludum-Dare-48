using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    [SerializeField] private TMP_Text EndScreenText;
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

    private float firstTransitionTime;
    private float secondTransitionTime;
    private float thirdTransitionTime;
    private float fourthTransitionTime;
    private float fifthTransitionTime;
    

    // Start is called before the first frame update
    void Start()
    {
        transitions = GetComponent<Transitions>();
        firstTransitionTime = 45f;
        secondTransitionTime = 20f + firstTransitionTime;
        thirdTransitionTime = 30f + secondTransitionTime;
        fourthTransitionTime = 50f + thirdTransitionTime;
        fifthTransitionTime = 20f + fourthTransitionTime; 
    }

    // Update is called once per frame
    void Update()
    {
        if (!Enabled)
        {
            return;
        }
        
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
            EndScreenText.text = "You have achieved nirvana.";
            EndScreenText.DOColor(Color.black, 1f);
            transitionCount++;
        }
    }

    
}