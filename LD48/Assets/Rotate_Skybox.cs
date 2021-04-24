using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Skybox : MonoBehaviour
{
    public float skyboxSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * skyboxSpeed);
    }
}
