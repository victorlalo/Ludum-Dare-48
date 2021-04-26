using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class FadeExit : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    void Start()
    {
        text.color = Color.clear;
        text.DOColor(Color.black, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Application.Quit();
        }
    }
}
