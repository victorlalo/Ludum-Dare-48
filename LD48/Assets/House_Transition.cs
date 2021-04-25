using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House_Transition : MonoBehaviour
{
    Animator anim;
    [SerializeField] Timer timer;
    bool tranisitioned = false;

    [SerializeField] float transitionTime = 60;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (timer.CurrTime > transitionTime && !tranisitioned)
        {
            Transition();
        }
    }

    public void Transition()
    {
        anim.SetTrigger("Break");
    }
}
