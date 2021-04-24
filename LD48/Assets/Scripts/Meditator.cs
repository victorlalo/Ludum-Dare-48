using UnityEngine;

public class Meditator : MonoBehaviour
{

    [SerializeField] private float breathSpeed = 1;
    [SerializeField] private float MaxConcentration = 100;
    [SerializeField] private float currentConcentration;

    [SerializeField] private Transform breathIndicatorTransform;
    
    private KeyCode inBreath = KeyCode.Space;
    // private KeyCode outBreath = KeyCode.DownArrow;

    private bool BreathingIn
    {
        get
        {
            return breathPeriod >= 0;
        }
    }

    private float concentrationLossRate = 0.1f;
    private float breathPeriod = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        currentConcentration = MaxConcentration;
    }

    // Update is called once per frame
    void Update()
    {

        breathPeriod = Mathf.Cos(Time.time * breathSpeed / Mathf.PI);

        var scale = Mathf.InverseLerp(-1, 1, breathPeriod);
        
        breathIndicatorTransform.localScale = new Vector3(scale, scale, scale);
        print($"breathPeriod was {breathPeriod}");
        
        if (BreathingIn)
        {
            if (!Input.GetKey(inBreath))
            {
                currentConcentration -= concentrationLossRate;
            }
        }
        else
        {
            if (Input.GetKey(inBreath))
            {
                currentConcentration -= concentrationLossRate;
            }
        }
    }
}
