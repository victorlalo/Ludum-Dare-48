using System;
using TMPro;
using UnityEngine;

public class Distraction : MonoBehaviour
{
    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    private float speed = 1f;

    [SerializeField] public Transform Player;

    public string Text;

    public string RemainingText
    {
        get => remainingText;
        set
        {
            if (DisplayText != null)
            {
                DisplayText.text = value;
            }
            remainingText = value;
        }
    }

    private string remainingText;

    [SerializeField] private TMP_Text DisplayText;

    // Start is called before the first frame update
    void Start()
    {
        RemainingText = Text;
        DistractionSpawner.OnStopSpawning += SelfDestruct;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, Speed *Time.deltaTime);
        }
        if (!string.IsNullOrEmpty(Input.inputString) &&
            RemainingText.StartsWith(Input.inputString, StringComparison.InvariantCultureIgnoreCase))
        {
            RemainingText =
                RemainingText.Substring(RemainingText.IndexOf(Input.inputString, StringComparison.InvariantCultureIgnoreCase) + 1);
        }

        if (RemainingText.Length == 0)
        {
            SelfDestruct();
        }
    }

    public void SelfDestruct()
    {
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}