using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Video;

public class SkyBoxVideo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] VideoPlayer _videoPlayer;
    [SerializeField] VideoClip[] Case1Clip;
    [SerializeField] VideoClip[] Case2Clip;
    [SerializeField] VideoClip[] Case1CounselingClip;
    [SerializeField] VideoClip[] Case2CounselingClip;
    int _videoClipIndex;
    
    [SerializeField] public Material mainSkyBox;
    [SerializeField] public Material videoSkyBox;
    [SerializeField] public GameObject continueButton;
    [SerializeField] private GameObject _canvasCursor;

    [SerializeField] BackgroundScript _backgroundScript;

    [SerializeField] private GameObject _backButton;
    
    // Set this variable to false if change to mobile version
    // bool _isDesktopVersion = true;
    
    public void StartVideo()
    {
        _backButton.SetActive(false);
        
        if (_videoPlayer.waitForFirstFrame) {
            _videoPlayer.Play();
            _videoPlayer.loopPointReached += ContinueButtonEnable;
        }
    }
    public void Start()
    {
        continueButton.SetActive(false);
        _videoPlayer.clip = Case1Clip[0];
    }

    private void ChangeToMainSkyBox()
    {
        RenderSettings.skybox = mainSkyBox;
    }
    
    public void ChangeToVideoSkyBox(int index)
    {
        _backgroundScript.SetBackgroundToInactive();
        StateNameController.IsVideoPlaying = true;
        RenderSettings.skybox = videoSkyBox;
        
        if (!StateNameController.IsDesktopVersion) {
            _canvasCursor.SetActive(false);
        }
        
        if (_videoPlayer.isPlaying == false)
        {
            if (StateNameController.ClinicalCaseNumber == 1) {
                _videoPlayer.clip = Case1Clip[index];
            }
            else if (StateNameController.ClinicalCaseNumber == 2) {
                _videoPlayer.clip = Case2Clip[index];
            }
            else if (StateNameController.ClinicalCaseNumber == 3) {
                _videoPlayer.clip = Case1CounselingClip[index];
            }
            else if (StateNameController.ClinicalCaseNumber == 4) {
                _videoPlayer.clip = Case2CounselingClip[index];
            }
            
            StartVideo();
        }
    }

    void ContinueButtonEnable(VideoPlayer vp)
    {
        StateNameController.IsVideoPlaying = false;
        continueButton.SetActive(true);
        if (!StateNameController.IsDesktopVersion) {
            _canvasCursor.SetActive(true);
        }
    }
    
    // Use in teh Continue button
    public void ExitVideoSkybox()
    {
        ChangeToMainSkyBox();
        continueButton.SetActive(false);
        _backButton.SetActive(true);
    
        if (StateNameController.CurrentActivePanel.name == "Case1_h_Instruction_02_Demographic")
        {
            // CaseOneHistory.GoToInstruction02();
        }
        
    }
    
}
