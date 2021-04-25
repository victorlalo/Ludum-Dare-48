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

    [SerializeField] float fadeSpeed;

    public bool doneWithTrippyFade = false;


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
        //StartCoroutine(FadeInTrippy());
        //NirvannaTransition();
        FadePlayer();
    }

    public void HouseTransition()
    {
        house.GetComponent<Animator>().SetTrigger("Break");
    }

    public void TrippyTransition()
    {
        // Fade in Trippy Video Animation
        StartCoroutine(FadeInTrippy());
    }

    public void NirvannaTransition()
    {
        // Fade in white background
        nirvanna.GetComponent<MeshRenderer>().material.DOFade(1, 5);
    }

    public void FadePlayer()
    {
        player.transform.DOMoveZ(20, 20);
        frontFade.GetComponent<MeshRenderer>().material.DOFade(1, 5);
    }

    IEnumerator FadeInTrippy()
    {
        var vid = trippy.GetComponent<VideoPlayer>();
        while(vid.targetCameraAlpha < 1)
        {
            //print(vid.targetCameraAlpha);
            vid.targetCameraAlpha += Time.deltaTime * fadeSpeed;
            yield return new WaitForEndOfFrame();
        }
        doneWithTrippyFade = true;
    }
}
