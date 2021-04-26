using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    VideoPlayer player;
    string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, "Mandala.mp4");
    void Start()
    {
        player = GetComponent<VideoPlayer>();
        player.url = videoPath;
    }

    public void Play()
    {
        player.Play();
    }
}
