using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    [SerializeField] private TMP_Text EndScreenText;
    [SerializeField] private Image Backdrop;
    [SerializeField] Color backdropColor;
    [SerializeField] AudioMixController mixer;
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
        
        firstTransitionTime = 40f;
        secondTransitionTime = 30f + firstTransitionTime;
        thirdTransitionTime = 20f + secondTransitionTime;
        fourthTransitionTime = 22f + thirdTransitionTime;
        fifthTransitionTime = 12f + fourthTransitionTime;
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
            mixer.PlayBellSFX();
            EndScreenText.text = "Your concentration\ndeepens";
            EndScreenText.DOColor(Color.black, 1f);
            Backdrop.DOColor(backdropColor, 1f);
            StartCoroutine(FadeOutText());
            transitions.HouseTransition();
            transitionCount++;
        }
        if (CurrTime > secondTransitionTime && transitionCount == 1)
        {
            mixer.PlayBellSFX();
            EndScreenText.text = "You reveal your true essence";
            EndScreenText.DOColor(Color.white, 1f);
            // Backdrop.DOColor(backdropColor, 1f);
            StartCoroutine(FadeOutText());
            transitions.SwapPlayerModels();
            transitionCount++;
        }
        if (CurrTime > thirdTransitionTime && transitionCount == 2)
        {
            mixer.PlayBellSFX();
            EndScreenText.text = "You transcend this plane";
            EndScreenText.DOColor(Color.white, 1f);
            // Backdrop.DOColor(backdropColor, 1f);
            StartCoroutine(FadeOutText());
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
            EndScreenText.text = "You have achieved\nNirvana.";
            EndScreenText.DOColor(Color.black, 1f);
            mixer.PlayBellSFX();
            transitionCount++;
        }
    }

    IEnumerator FadeOutText()
    {
        yield return new WaitForSeconds(3.5f);
        EndScreenText.DOColor(Color.clear, 2f);
        Backdrop.DOColor(Color.clear, 2f);

    }

    
}