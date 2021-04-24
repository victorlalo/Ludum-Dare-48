using System;
using UnityEngine;

public class Distraction : MonoBehaviour
{
    public string Text;
    public string RemainingText;
    
    // Start is called before the first frame update
    void Start()
    {
        RemainingText = Text;
    }

    // Update is called once per frame
    void Update()
    {
     
        if (!string.IsNullOrEmpty(Input.inputString) && RemainingText.StartsWith(Input.inputString, StringComparison.InvariantCultureIgnoreCase))
        {
            RemainingText = RemainingText.Substring(RemainingText.IndexOf(Input.inputString, StringComparison.InvariantCultureIgnoreCase) + 1);
        }
        
        if (RemainingText.Length == 0)
        {
            SelfDestruct();
        }
    }

    private void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
