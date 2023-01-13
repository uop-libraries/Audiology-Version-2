using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.Events;
using Image = UnityEngine.UIElements.Image;
using Slider = UnityEngine.UI.Slider;

public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject button;
    public Slider cursorTimer;
    public UnityEvent click;
    private float totalTime = 1f;
    private bool _gazedStatus;
    public float gazedTimer;
    private bool _playingHoverOnAnimation;


    void Start()
    {
        cursorTimer.value = 0;
        _playingHoverOnAnimation = false;
        _gazedStatus = false;
    }



    void Update()
    {
        if (_gazedStatus)
        {
            button.GetComponent<Animator>().StopPlayback();
            gazedTimer += Time.deltaTime;
            cursorTimer.value = gazedTimer / totalTime;
            StartCoroutine(PlayHoverOn());
        }
        
        if (gazedTimer > totalTime)
        {
            click.Invoke();
        }
    }

    public void OnPointerEnter1()
    {
        _gazedStatus = true;
    }

    public void OnPointerExit1()
    {
        _playingHoverOnAnimation = false;
        _gazedStatus = false;
        gazedTimer = 0;
        cursorTimer.value = 0;
        button.GetComponent<Animator>().Play("HoverOffAnimation");
        button.GetComponent<Animator>().Play("StartAnimation");
    }

    IEnumerator PlayHoverOn()
    {
        button.GetComponent<Animator>().Play("HoverOnAnimation");
        yield return null;
    }


}
