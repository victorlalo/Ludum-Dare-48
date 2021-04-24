using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KeystrokeDetector : MonoBehaviour
{
    private List<Distraction> distractions;
    private Distraction targetedDistraction;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (targetedDistraction == null)
            {
                targetedDistraction = distractions.FirstOrDefault(d => d.Text.Contains(Input.inputString));
            }
        }
    }
}
