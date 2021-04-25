using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private TMP_Text TutorialText;
    [SerializeField] private GameObject Player;
    [SerializeField] private DistractionSpawner Spawner;
    [SerializeField] private Timer Timer;

    private int currentMessage;
    private int perfectBreaths;
    private bool waitingForBreaths;

    private (string message, float waitTime, Func<bool> action)[] TutorialSteps;
    
    void Start()
    {
        
        TutorialSteps = new (string message, float waitTime, Func<bool> action)[]
        {
            ("Welcome to Deep Breathing.", 0f, null), 
            ("You will experience some deep meditation.", 0f, null), 
            ("Say hi to you.", 2f, ShowPlayer),
            ("When the focus indicator grows, hold the space bar to breathe in.", 0, null),
            ("When the focus indicator shrinks, release the space bar to exhale.", 0, null),
            ("Try three perfect breaths now.", 0, WaitForPerfectBreaths),
            ("Good job!", 0, null),
            ("Press the left and right arrow keys to aim your breath.", 0, null),
            ("Don't get distracted!", 0, StartGame)
        };

        Meditator.PerfectBreath += () => perfectBreaths++;
        
        StartCoroutine(DisplayNextTutorialMessage());
    }

    private IEnumerator DisplayNextTutorialMessage()
    {
        while (currentMessage < TutorialSteps.Length)
        {
            yield return new WaitForSeconds(2);
            TutorialText.DOColor(Color.black, 1f);
            var currentStep = TutorialSteps[currentMessage++];
            TutorialText.text = currentStep.message;
            
            yield return new WaitForSeconds(currentStep.waitTime);

            bool continueToNextStep;
            do
            {
                yield return null;
                continueToNextStep = currentStep.action?.Invoke() ?? true;
            } while (continueToNextStep == false);

            yield return new WaitForSeconds(4);
            TutorialText.DOColor(Color.clear, 1f);
        }
        TutorialText.DOColor(Color.clear, 1f);
    }

    private bool ShowPlayer()
    {
        Player.SetActive(true);
        return true;
    }

    private bool WaitForPerfectBreaths()
    {
        if (!waitingForBreaths)
        {
            perfectBreaths = 0;
            waitingForBreaths = true;
        }
        return perfectBreaths >= 3;
    }

    private bool StartGame()
    {
        Timer.Enabled = true;
        Spawner.StartSpawning();
        return true;
    }
}