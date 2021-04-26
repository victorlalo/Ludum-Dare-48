using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMixController : MonoBehaviour
{
    public AudioMixer mixer;
    public float fadeSpeed;

    [SerializeField] AudioSource sfxTrack;

    [SerializeField] AudioClip bell;
    [SerializeField] AudioClip inhale;
    [SerializeField] AudioClip exhale;


    void Awake()
    {
        sfxTrack.Stop();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    PlayBellSFX();
        //}
        //else if (Input.GetKeyDown(KeyCode.C))
        //{
        //    PlayInhaleSFX();
        //}

        //else if (Input.GetKeyDown(KeyCode.V))
        //{
        //    PlayExhaleSFX();
        //}
    }

    public void PlayBellSFX()
    {
        sfxTrack.PlayOneShot(bell);
    }

    public void PlayInhaleSFX()
    {
        sfxTrack.PlayOneShot(inhale);
    }

    public void PlayExhaleSFX()
    {
        sfxTrack.PlayOneShot(exhale);
    }

    public void StartTrackFade(string name)
    {
        StartCoroutine(FadeInTrack(name));
    }

    IEnumerator FadeInTrack(string name)
    {
        float mixLevel = 0;

        while(mixLevel < 1)
        {
            mixer.SetFloat(name, mixLevel);
            mixLevel += Time.deltaTime * fadeSpeed;
            yield return new WaitForEndOfFrame();
        }
        
    }
}
