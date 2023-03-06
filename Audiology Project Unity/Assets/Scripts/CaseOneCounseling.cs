using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


public class CaseOneCounseling : MonoBehaviour {
    private GameObject _nextNarration;
    private GameObject _nextInstruction;
    private GameObject _nextFeedback;
    private GameObject _nextTopic;
    private GameObject _nextExplanation;

    [Header("Narrator Panel")]
    [SerializeField] private GameObject _C1C_Narrator_01;
    [SerializeField] private GameObject _C1C_Narrator_02;
    [SerializeField] private GameObject _C1C_Narrator_03;

    [Header("Instruction Panel")]
    [SerializeField] private GameObject _C1C_Instruction_01;
    [SerializeField] private GameObject _C1C_Instruction_02;
    [SerializeField] private GameObject _C1C_Instruction_03;
    [SerializeField] private GameObject _C1C_Instruction_04;
    [SerializeField] private GameObject _C1C_Instruction_05;
    [SerializeField] private GameObject _C1C_Instruction_06;
    [SerializeField] private GameObject _C1C_Instruction_07;
    [SerializeField] private GameObject _C1C_Instruction_08;
    [SerializeField] private GameObject _C1C_Instruction_09;
    [SerializeField] private GameObject _C1C_Instruction_10;
    [SerializeField] private GameObject _C1C_Instruction_11;
    [SerializeField] private GameObject _C1C_Instruction_12;

    [Header("Feedback Panel")]
    [SerializeField] private GameObject _C1C_Feedback_01;
    [SerializeField] private GameObject _C1C_Feedback_02;
    [SerializeField] private GameObject _C1C_Feedback_03;
    [SerializeField] private GameObject _C1C_Feedback_04;
    [SerializeField] private GameObject _C1C_Feedback_05;
    [SerializeField] private GameObject _C1C_Feedback_06;
    [SerializeField] private GameObject _C1C_Feedback_07;
    [SerializeField] private GameObject _C1C_Feedback_08;

    [Header("Topic Panel")]
    [SerializeField] private GameObject _C1C_Topic_01_1;
    [SerializeField] private GameObject _C1C_Topic_01_2;
    [SerializeField] private GameObject _C1C_Topic_02;
    [SerializeField] private GameObject _C1C_Topic_03;
    [SerializeField] private GameObject _C1C_Topic_04;
    [SerializeField] private GameObject _C1C_Topic_05_1;
    [SerializeField] private GameObject _C1C_Topic_05_2;
    [SerializeField] private GameObject _C1C_Topic_05_3;
    [SerializeField] private GameObject _C1C_Topic_05_4;

    [Header("Explanation Panel")]
    [SerializeField] private GameObject _C1C_Explanation_01_1;
    [SerializeField] private GameObject _C1C_Explanation_01_2;
    [SerializeField] private GameObject _C1C_Explanation_01_3;
    [SerializeField] private GameObject _C1C_Explanation_02_1;
    [SerializeField] private GameObject _C1C_Explanation_02_2;
    [SerializeField] private GameObject _C1C_Explanation_02_3;

    [Header("AudioSource")]
    [SerializeField] private AudioSource audioSource;
    // Narration audio clip
    [SerializeField] private AudioClip clipC1CNarration01;
    [SerializeField] private AudioClip clipC1CNarration02;
    [SerializeField] private AudioClip clipC1CNarration03;
    
    // Feedback audio clip
    [SerializeField] private AudioClip clipC1CFeedback01;
    [SerializeField] private AudioClip clipC1CFeedback02;
    [SerializeField] private AudioClip clipC1CFeedback03;
    [SerializeField] private AudioClip clipC1CFeedback04;
    [SerializeField] private AudioClip clipC1CFeedback05;
    [SerializeField] private AudioClip clipC1CFeedback06;
    [SerializeField] private AudioClip clipC1CFeedback07;
    [SerializeField] private AudioClip clipC1CFeedback08;
    
    // Instruction audio clip
    [SerializeField] private AudioClip clipC1CInstruction01;
    
    private int _counter;

    public void StartCase1Counseling() {
        _counter = 0;
        InitializePanel();
    }

    private void InitializePanel() {
        // Initial first panel so it is not null
        StateNameController.CurrentActivePanel = _C1C_Narrator_01;

        var currentPanel = "Case1_counseling";
        var parent = GameObject.Find(currentPanel);

        Debug.Log("parent: " + parent);

        // make all child object inactive
        foreach (Transform child in parent.transform) {
            child.gameObject.SetActive(false);
        }

        GoToNarratorPanel(1);
    }

    public void GoToNarratorPanel(int panelNum) {
        AudioClip _nextClip = null;

        switch (panelNum) {
            case 1:
                _nextInstruction = _C1C_Narrator_01;
                _nextClip = clipC1CNarration01;
                break;
            case 2:
                _nextInstruction = _C1C_Narrator_02;
                _nextClip = clipC1CNarration02;
                break;
            case 3:
                _nextInstruction = _C1C_Narrator_03;
                _nextClip = clipC1CNarration03;
                break;
        }

        StateNameController.SwitchPanel(_nextInstruction);

        var child2 = _nextInstruction.transform.GetChild(1).gameObject;
        StartCoroutine(ActionAfterAudioStop(child2, _nextClip));
    }

    private IEnumerator ActionAfterAudioStop(GameObject button, AudioClip currentClip) {
        if (button != null) {
            button.gameObject.SetActive(false);
        }
        if (currentClip != null) {
            audioSource.clip = currentClip;
            audioSource.Play();
        }

        yield return new WaitForSeconds(audioSource.clip.length);
        if (button != null) {
            button.gameObject.SetActive(true);
        }
    }

    public void GoToInstruction(int panelNumber) {
              Debug.Log("Instruction Panel: " + panelNumber);
        switch (panelNumber) {
            case 1:
                _nextInstruction = _C1C_Instruction_01;
                StartCoroutine(ActionAfterAudioStop(null, clipC1CInstruction01));
                break;
            case 2:
                _nextInstruction = _C1C_Instruction_02;
                GoToInstructionNumber(panelNumber);
                break;
            case 3:
                _nextInstruction = _C1C_Instruction_03;
                break;
            case 4:
                _nextInstruction = _C1C_Instruction_04;
                GoToInstructionNumber(panelNumber);
                break;
            case 5:
                _nextInstruction = _C1C_Instruction_05;
                break;
            case 6:
                _nextInstruction = _C1C_Instruction_06;
                GoToInstructionNumber(panelNumber);
                break;
            case 7:
                _nextInstruction = _C1C_Instruction_07;
                GoToInstructionNumber(panelNumber);
                break;
            case 8:
                _nextInstruction = _C1C_Instruction_08;
                break;
            case 9:
                _nextInstruction = _C1C_Instruction_09;
                break;
            case 10:
                _nextInstruction = _C1C_Instruction_10;
                GoToInstructionNumber(panelNumber);
                break;
            case 11:
                _nextInstruction = _C1C_Instruction_11;
                GoToInstructionNumber(panelNumber);
                break;
            case 12:
                _nextInstruction = _C1C_Instruction_12;
                GoToInstructionNumber(panelNumber);
                break;
       
        }
        StateNameController.SwitchPanel(_nextInstruction);
        BackgroundScript.ActivateBackground(true);
        ChangeFeedbackBackground(false);
    }

    private void GoToInstructionNumber(int instructionNumber) {
        _counter = 0;
        var child1 = _nextInstruction.transform.GetChild(1).gameObject;
        var child2 = _nextInstruction.transform.GetChild(2).gameObject;

        //Todo Debug
        child2.SetActive(false);
        //Todo Debug

        foreach (Transform child in child1.transform) {
            if (child.gameObject.GetComponent<Image>().color == Color.grey) {
                if (instructionNumber == 7) {
                    child.gameObject.SetActive(false);
                }

                _counter++;
            }
        }

        if (_counter == 2 && instructionNumber == 2 ||
            _counter == 1 && instructionNumber == 4 ||
            _counter == 6 && instructionNumber == 6 ||
            _counter == 7 && instructionNumber == 7 ||
            _counter == 3 && instructionNumber == 10 ||
            _counter == 2 && instructionNumber == 11 ||
            _counter == 1 && instructionNumber == 12 ||
            _counter == 1 && instructionNumber == 13 ||
            _counter == 1 && instructionNumber == 14) {
            child2.SetActive(true);
        }
    }
    
    public void ChangeFeedbackBackground(bool isFeedback) {
        BackgroundScript.DeactivateBackground();
        BackgroundScript.DeactivateDocImages();
        //
        // if (isFeedback) {
        //     if (_nextFeedback != _Feedback04 && _nextFeedback != _Feedback04_1) {
        //         BackgroundScript.GetBackground()[1].gameObject.SetActive(true);
        //         BackgroundScript.GetDocImages()[1].gameObject.SetActive(true);
        //     }
        //     else {
        //         BackgroundScript.GetBackground()[2].gameObject.SetActive(true);
        //         BackgroundScript.GetDocImages()[2].gameObject.SetActive(true);
        //     }
        // }
        // else {
        //     BackgroundScript.GetBackground()[0].gameObject.SetActive(true);
        //     BackgroundScript.GetDocImages()[0].gameObject.SetActive(true);
        // }
    }
    
    public void GoToFeedBack(int value) {
        AudioClip nextAudioClip = null;

        // Get current feedback panel
        _nextFeedback = value switch {
            1 => _C1C_Feedback_01,
            2 => _C1C_Feedback_02,
            3 => _C1C_Feedback_03,
            4 => _C1C_Feedback_04,
            5 => _C1C_Feedback_05,
            6 => _C1C_Feedback_06,
            7 => _C1C_Feedback_07,
            8 => _C1C_Feedback_08,
            _ => _nextFeedback,
        };
        var child2 = _nextFeedback.transform.GetChild(1).gameObject;

        // Get next audio feedback clip
        nextAudioClip = value switch {
            1 => clipC1CFeedback01,
            2 => clipC1CFeedback02,
            3 => clipC1CFeedback03,
            4 => clipC1CFeedback04,
            5 => clipC1CFeedback05,
            6 => clipC1CFeedback06,
            7 => clipC1CFeedback07,
            8 => clipC1CFeedback08,
            _ => nextAudioClip
        };

        ChangeFeedbackBackground(true);
        StateNameController.SwitchPanel(_nextFeedback);

        // Play audio and control the button activation
        StartCoroutine(ActionAfterAudioStop(child2, nextAudioClip));

    }



}