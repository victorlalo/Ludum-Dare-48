using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using DG.Tweening;

public class Transitions : MonoBehaviour
{
    [SerializeField] GameObject house;
    [SerializeField] GameObject space;
    [SerializeField] GameObject trippy;
    [SerializeField] GameObject nirvanna;
    [SerializeField] GameObject frontFade;
    [SerializeField] GameObject player;
    [SerializeField] DistractionSpawner spawner;
    [SerializeField] GameObject endCanvas;

    [SerializeField] float fadeSpeed;

    public bool doneWithTrippyFade = false;
    string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, "Mandala.mp4");


    void Start()
    {
        trippy.GetComponent<VideoPlayer>().targetCameraAlpha = 0;

        Color32 c = nirvanna.GetComponent<MeshRenderer>().material.color;
        c.a = 0;
        nirvanna.GetComponent<MeshRenderer>().material.SetColor("_Color", c);

        Color32 c2 = frontFade.GetComponent<MeshRenderer>().material.color;
        c2.a = 0;
        frontFade.GetComponent<MeshRenderer>().material.SetColor("_Color", c);

        //HouseTransition();
        StartCoroutine(FadeInTrippy());
        //NirvannaTransition();
        //SwapPlayerModels();
        //FadePlayer();
    }

    public void HouseTransition()
    {
        house.GetComponent<Animator>().SetTrigger("Break");
        space.GetComponent<ObjectSpawner>().spawning = true;
    }

    public void TrippyTransition()
    {
        // Fade in Trippy Video Animation
        //trippy.SetActive(true);
        StartCoroutine(FadeInTrippy());
    }

    public void NirvannaTransition()
    {
        // Fade in white background
        nirvanna.GetComponent<MeshRenderer>().material.DOFade(1, 5);
        spawner.StopSpawning();
    }

    public void SwapPlayerModels()
    {
        player.GetComponent<Meditator>().SwapModels();
    }

    public void FadePlayer()
    {
        player.transform.DOMoveZ(20, 8);
        frontFade.GetComponent<MeshRenderer>().material.DOFade(1, 5);
        StartCoroutine(FadeInEndCanvas());
    }

    IEnumerator FadeInTrippy()
    {
        var vid = trippy.GetComponent<VideoPlayer>();
        vid.url = videoPath;
        vid.Play();
        while (vid.targetCameraAlpha < 1)
        {
            //print(vid.targetCameraAlpha);
            vid.targetCameraAlpha += Time.deltaTime * fadeSpeed;
            yield return new WaitForEndOfFrame();
        }
        doneWithTrippyFade = true;
    }

    IEnumerator FadeInEndCanvas()
    {
        yield return new WaitForSeconds(8);
        Instantiate(endCanvas, transform.position, Quaternion.identity);

    }

}
