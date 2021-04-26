using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWaveAnim : MonoBehaviour
{
    [SerializeField] GameObject[] wavePoints;
    [SerializeField] float offsetTime = 1f;
    [SerializeField] float oscSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i< wavePoints.Length; i++)
        {
            Vector3 scale = wavePoints[i].transform.localScale;
            float yScale = 0.25f * Mathf.Sin(Time.time * oscSpeed + i * offsetTime) + 0.3f;
            scale.y = yScale;
            wavePoints[i].transform.localScale = scale;
        }

        //oscSpeed = Mathf.Sin(Time.time);
    }

    float Remap(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }
}
