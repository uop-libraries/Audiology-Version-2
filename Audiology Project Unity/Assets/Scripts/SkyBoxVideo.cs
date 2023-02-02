using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Video;

public class SkyBoxVideo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private VideoClip[] Case1Clip;
    private int _videoClipIndex;
    
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
    
    public void ChangeToVideoSkyBox(int index)
    {
        RenderSettings.skybox = videoSkyBox;
        if (_videoPlayer.isPlaying == false)
        {
            _videoPlayer.clip = Case1Clip[index];
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

        if (StateNameController.currentActivePanel.name == "Case1_h_Instruction_02_Demographic")
        {
            // CaseOneHistory.GoToInstruction02();
        }
        
    }
    
}
