using System;
using UnityEngine;

public class Meditator : MonoBehaviour
{
    [SerializeField] private float breathSpeed = 2;
    [SerializeField] private float MaxConcentration = 100;
    [SerializeField] private float currentConcentration;

    [SerializeField] private MeshRenderer breathIndicatorMesh;
    private Color originalBreathIndicatorColor;
    [SerializeField] private Transform breathIndicatorTransform;
    [SerializeField] private MeshRenderer concentrationBar;
    private float originalConcentrationBarScale;

    private KeyCode inBreath = KeyCode.Space;

    private int MaxGracePeriodFrames = 60 * 4;
    private int currentGracePeriod;

    private bool BreathingIn
    {
        get => breathingIn;
        set
        {
            breathingIn = value;
            currentGracePeriod = MaxGracePeriodFrames;
        }
    }

    private bool breathingIn;

    private float concentrationLossRate = 0.1f;
    private float breathPeriod;

    // Start is called before the first frame update
    void Start()
    {
        currentConcentration = MaxConcentration;
        originalBreathIndicatorColor = breathIndicatorMesh.material.color;
        originalConcentrationBarScale = concentrationBar.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        breathPeriod = Mathf.Cos(Time.time * breathSpeed / Mathf.PI);
        
        var previousScale = breathIndicatorTransform.localScale.x;
        var scale = Remap(-1, 1, 0.3f, 1, breathPeriod);
        
        // Checks if the scale of the breath indicator is growing or shrinking.
        // Growing means we are breathing in.
        if (!(previousScale > scale) != BreathingIn)
        {
            BreathingIn = !BreathingIn;
        }

        breathIndicatorTransform.localScale = new Vector3(scale, scale, scale);
        if (BreathingIn)
        {
            if (currentGracePeriod > 0 || Input.GetKey(inBreath))
            {
                breathIndicatorMesh.material.color = Color.green;
            } else {
                HandleBreathFuckUp();
            }
        }
        else
        {
            if (currentGracePeriod > 0 || !Input.GetKey(inBreath))
            {
                breathIndicatorMesh.material.color = Color.blue;
            } else {
                HandleBreathFuckUp();
            }
        }
        concentrationBar.transform.localScale = new Vector3(originalConcentrationBarScale * currentConcentration / MaxConcentration, 1, 1);
        currentGracePeriod -= 1;
    }

    private void HandleBreathFuckUp()
    {
        breathIndicatorMesh.material.color = originalBreathIndicatorColor;
        if (currentGracePeriod <= 0)
        {
            currentConcentration -= concentrationLossRate;
        }
    }

    private float Remap(float origFrom, float origTo, float targetFrom, float targetTo, float value)
    {
        float rel = Mathf.InverseLerp(origFrom, origTo, value);
        return Mathf.Lerp(targetFrom, targetTo, rel);
    }
}