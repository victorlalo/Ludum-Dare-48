using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Skybox : MonoBehaviour
{
    public float skyboxSpeed;
    public float zoomSpeed;
    Camera cam;
    void Start()
    {
        cam = GetComponent<Camera>();
        StartCoroutine(IncreaseFOV());
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * skyboxSpeed);
    }

    public void ZoomFOV()
    {
        StartCoroutine(IncreaseFOV());
    }

    IEnumerator IncreaseFOV()
    {
        while (cam.fieldOfView < 178)
        {
            cam.fieldOfView += Time.deltaTime * zoomSpeed;
            yield return new WaitForEndOfFrame();
        }
    }
}
