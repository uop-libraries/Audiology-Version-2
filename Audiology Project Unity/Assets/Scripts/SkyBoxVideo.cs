using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SkyBoxVideo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] public Material mainSkyBox;
    [SerializeField] public Material videoSkyBox;
    [SerializeField] public GameObject skyboxCanvas;
    
    public void StartVideo()
    {
        _videoPlayer.Play();
        _videoPlayer.loopPointReached += ContinueButtonEnable;
    }
    public void Start()
    {
        skyboxCanvas.SetActive(false);
    }

    private void ChangeToMainSkyBox()
    {
        RenderSettings.skybox = mainSkyBox;
    }
    
    public void ChangeToVideoSkyBox()
    {
        RenderSettings.skybox = videoSkyBox;
        if (_videoPlayer.isPlaying == false)
        {
            StartVideo();
        }
    }

    void ContinueButtonEnable(VideoPlayer vp)
    {
        skyboxCanvas.SetActive(true);
    }

    public void ExitVideoSkybox()
    {
        ChangeToMainSkyBox();
        skyboxCanvas.SetActive(false);
        
    }
    
}
