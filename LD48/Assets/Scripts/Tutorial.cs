using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private TMP_Text TutorialText;
    [SerializeField] private Image backdrop;
    Color backdropColor;
    [SerializeField] private GameObject Player;
    [SerializeField] private DistractionSpawner Spawner;
    [SerializeField] private Timer Timer;
    [SerializeField] private AudioMixController AudioMixController;

    private int currentMessage;
    private int perfectBreaths;
    private bool waitingForBreaths;

    private (string message, float waitTime, Func<bool> action)[] TutorialSteps;

    public bool skipTutorial = false;

    private void Awake()
    {
        backdropColor = backdrop.color;
        TutorialText.color = Color.clear;
        backdrop.color = Color.clear;
    }

    void Start()
    {
        if (skipTutorial)
        {
            StartGame();
            return;
        }

        TutorialSteps = new (string message, float waitTime, Func<bool> action)[]
        {
            ("Welcome to Deep Breathing", 0f, null), 
            ("You will experience\nDeeper and Deeper meditative states", 0f, null), 
            ("Say hi to you", 2f, ShowPlayer),
            ("When the focus indicator grows, hold the space bar to breathe in", 0, null),
            ("When the focus indicator shrinks, release the space bar to exhale", 0, null),
            ("Try taking three deep breaths\n(Press on inhale, release on exhale)", 0, WaitForPerfectBreaths),
            ("Good job!", 0, null),
            ("Press the left and right arrow keys to aim your breath", 0, null),
            ("Acknowledge distractions with a breath.", 0, StartGame)
        };

        TutorialText.DOColor(Color.black, 3f).SetDelay(1.5f);
        backdrop.DOColor(backdropColor, 3.5f).SetDelay(1.5f);


        Meditator.PerfectBreath += () => perfectBreaths++;

        StartCoroutine(DisplayNextTutorialMessage());
        
    }

    private IEnumerator DisplayNextTutorialMessage()
    {
        do
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

            yield return new WaitForSeconds(4f);
            TutorialText.DOColor(Color.clear, 1f);
        } while (currentMessage < TutorialSteps.Length);
        TutorialText.DOColor(Color.clear, 1f);
        backdrop.DOColor(Color.clear, 1f);
    }

    private bool ShowPlayer()
    {
        Player.SetActive(true);
        AudioMixController.PlayBellSFX();
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