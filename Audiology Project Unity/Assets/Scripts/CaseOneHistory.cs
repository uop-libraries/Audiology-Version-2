using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CaseOneHistory : MonoBehaviour  {
    // private GameObject _currentPanel;
    private GameObject _nextInstruction;
    private GameObject _nextFeedback;

    [Header("Dependencies Script")]
    [SerializeField] private BackgroundScript backgroundScript;

    [Header("Narrator Panel")]
    [SerializeField] private GameObject Narrator01;

    [Header("Instruction Panel")]
    [SerializeField] private GameObject _Instruction01;
    [SerializeField] private GameObject _Instruction02;
    [SerializeField] private GameObject _Instruction03;
    [SerializeField] private GameObject _Instruction04;
    [SerializeField] private GameObject _Instruction05;
    [SerializeField] private GameObject _Instruction06;
    [SerializeField] private GameObject _Instruction07;
    [SerializeField] private GameObject _Instruction08;
    [SerializeField] private GameObject _Instruction09;
    [SerializeField] private GameObject _Instruction10;
    [SerializeField] private GameObject _Instruction11;
    [SerializeField] private GameObject _Instruction12;
    [SerializeField] private GameObject _Instruction13;
    [SerializeField] private GameObject _Instruction14;
    [SerializeField] private GameObject _Instruction15;

    [Header("Feedback Panel")]
    [SerializeField] private GameObject _Feedback01;
    [SerializeField] private GameObject _Feedback02;
    [SerializeField] private GameObject _Feedback03;
    [SerializeField] private GameObject _Feedback04;
    [SerializeField] private GameObject _Feedback04_1;
    [SerializeField] private GameObject _Feedback05;
    [SerializeField] private GameObject _Feedback06;
    [SerializeField] private GameObject _Feedback07;

    [Header("AudioSource")]
    [SerializeField] private AudioSource audioSource;
    
    [Header("AudioClip")]
    [SerializeField] private AudioClip clipCase1HistoryNarrator;
    [SerializeField] private AudioClip clipCase1HistoryNarrator2;

    
    // Instruction audio clip
    [SerializeField] private AudioClip clipCase1HistoryInstruction1;
    
    // Feedback audio clip
    [SerializeField] private AudioClip clipCase1HistoryFeedback1;
    [SerializeField] private AudioClip clipCase1HistoryFeedback2;
    [SerializeField] private AudioClip clipCase1HistoryFeedback3;
    [SerializeField] private AudioClip clipCase1HistoryFeedback4;
    [SerializeField] private AudioClip clipCase1HistoryFeedback4_1;
    [SerializeField] private AudioClip clipCase1HistoryFeedback5;
    [SerializeField] private AudioClip clipCase1HistoryFeedback6;
    [SerializeField] private AudioClip clipCase1HistoryFeedback7;

    private int _counter;
    int audioPlayCounter = 0;
    private bool _isFirstTime = true;
    private bool _isFirstTime1 = true;

    public void StartCase1History() {
        _counter = 0;
        InitializePanel();
    }

    private void InitializePanel() {
        var currentPanel = "Case1_history";
        var parent = GameObject.Find(currentPanel);

        Debug.Log("parent: " + parent);

        // make all child object inactive
        foreach (Transform child in parent.transform) {
            child.gameObject.SetActive(false);
        }

        GoToFirstPanel();
    }

    private void GoToFirstPanel() {
        StateNameController.CurrentActivePanel = Narrator01;
        _nextInstruction = Narrator01;
        StateNameController.SwitchPanel(_nextInstruction);

        var child2 = _nextInstruction.transform.GetChild(1).gameObject;
        StartCoroutine(ActionAfterAudioStop(child2, clipCase1HistoryNarrator));
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
        if (panelNumber is 1 or 15) {
            audioPlayCounter++;
        }
        else {
            audioPlayCounter = 0;
        }
        
        Debug.Log("Instruction Panel: " + panelNumber);
        audioSource.Stop();
        switch (panelNumber) {
            case 1:
                _nextInstruction = _Instruction01;
                if (audioPlayCounter < 2) {
                    StartCoroutine(ActionAfterAudioStop(null, clipCase1HistoryInstruction1));
                }
                break;
            case 2:
                _nextInstruction = _Instruction02;
                GoToInstructionNumber(panelNumber);
                break;
            case 3:
                _nextInstruction = _Instruction03;
                break;
            case 4:
                _nextInstruction = _Instruction04;
                GoToInstructionNumber(panelNumber);
                break;
            case 5:
                _nextInstruction = _Instruction05;
                break;
            case 6:
                _nextInstruction = _Instruction06;
                GoToInstructionNumber(panelNumber);
                break;
            case 7:
                _nextInstruction = _Instruction07;
                GoToInstructionNumber(panelNumber);
                break;
            case 8:
                GoToInstruction08();
                break;
            case 9:
                GoToInstruction09();
                break;
            case 10:
                _nextInstruction = _Instruction10;
                GoToInstructionNumber(panelNumber);
                break;
            case 11:
                _nextInstruction = _Instruction11;
                GoToInstructionNumber(panelNumber);
                break;
            case 12:
                _nextInstruction = _Instruction12;
                GoToInstructionNumber(panelNumber);
                break;
            case 13:
                _nextInstruction = _Instruction13;
                GoToInstructionNumber(panelNumber);
                break;
            case 14:
                _nextInstruction = _Instruction14;
                GoToInstructionNumber(panelNumber);
                break;
            case 15:
                GoToInstruction15();
                break;
        }
        StateNameController.SwitchPanel(_nextInstruction);
        BackgroundScript.ActivateBackground(true);
        ChangeFeedbackBackground(false);
    }

    public void GoToFeedBack(int value) {
        AudioClip nextAudioClip = null;

        // Get current feedback panel
        _nextFeedback = value switch {
            1 => _Feedback01,
            2 => _Feedback02,
            3 => _Feedback03,
            4 => _Feedback04,
            5 => _Feedback04_1,
            6 => _Feedback05,
            7 => _Feedback06,
            8 => _Feedback07,
            _ => _nextFeedback
        };
        var child2 = _nextFeedback.transform.GetChild(1).gameObject;

        // Get next audio feedback clip
        nextAudioClip = value switch {
            1 => clipCase1HistoryFeedback1,
            2 => clipCase1HistoryFeedback2,
            3 => clipCase1HistoryFeedback3,
            4 => clipCase1HistoryFeedback4,
            5 => clipCase1HistoryFeedback4_1,
            6 => clipCase1HistoryFeedback5,
            7 => clipCase1HistoryFeedback6,
            8 => clipCase1HistoryFeedback7,
            _ => nextAudioClip
        };

        ChangeFeedbackBackground(true);
        StateNameController.SwitchPanel(_nextFeedback);

        // Play audio and control the button activation
        StartCoroutine(ActionAfterAudioStop(child2, nextAudioClip));

    }
    
    // Instruction for hearing abilities option
    private void GoToInstruction08() {
        _counter = 0;
        _nextInstruction = _Instruction08;
        var child1 = _nextInstruction.transform.GetChild(1).gameObject;
        var child2 = _nextInstruction.transform.GetChild(2).gameObject;

        child2.SetActive(false);

        if (_isFirstTime) {
            foreach (Transform child in child1.transform) {
                child.gameObject.SetActive(false);
            }
        }

        _isFirstTime = false;

        foreach (Transform child in child1.transform) {
            if (child.gameObject.name is "Option_A" or "Option_B" or "Option_C") {
                child.gameObject.SetActive(true);
            }

            if (child.gameObject.GetComponent<Image>().color == Color.grey) {
                child.gameObject.SetActive(false);
                if (child.gameObject.activeSelf == false) {
                    _counter++;
                }
            }

            switch (_counter) {
                case 1: {
                    if (child.gameObject.name == "Option_D") {
                        child.gameObject.SetActive(true);
                    }

                    break;
                }
                case 2: {
                    if (child.gameObject.name == "Option_E") {
                        child.gameObject.SetActive(true);
                    }

                    break;
                }
                case 3: {
                    if (child.gameObject.name == "Option_F") {
                        child.gameObject.SetActive(true);
                    }

                    break;
                }
                case 4: {
                    if (child.gameObject.name == "Option_G") {
                        child.gameObject.SetActive(true);
                    }

                    break;
                }
                case 7:
                    child2.SetActive(true);
                    _isFirstTime = true;
                    break;
            }
        }
        _counter = 0;
    }

    // Instruction for vertigo option
    private void GoToInstruction09() {
        _counter = 0;
        _nextInstruction = _Instruction09;
        var child1 = _nextInstruction.transform.GetChild(1).gameObject;
        var child2 = _nextInstruction.transform.GetChild(2).gameObject;

        child2.SetActive(false);

        if (_isFirstTime1) {
            foreach (Transform child in child1.transform) {
                child.gameObject.SetActive(false);
            }
        }

        _isFirstTime1 = false;

        foreach (Transform child in child1.transform) {
            if (child.gameObject.GetComponent<Image>().color == Color.grey) {
                child.gameObject.SetActive(false);
                if (child.gameObject.activeSelf == false) {
                    _counter++;
                }
            }

            switch (_counter) {
                case 0: {
                    if (child.gameObject.name == "Option_A") {
                        child.gameObject.SetActive(true);
                    }
                    break;
                }
                case 1: {
                    if (child.gameObject.name == "Option_B") {
                        child.gameObject.SetActive(true);
                    }

                    break;
                }
                case 2: {
                    if (child.gameObject.name is "Option_C" or "Option_D" or "Option_E") {
                        child.gameObject.SetActive(true);
                    }

                    break;
                }
                case 3: {
                    if (child.gameObject.name == "Option_F") {
                        child.gameObject.SetActive(true);
                    }

                    break;
                }
                case 4: {
                    if (child.gameObject.name == "Option_G") {
                        child.gameObject.SetActive(true);
                    }

                    break;
                }
                case 7:
                    // child2.SetActive(true);
                    _isFirstTime1 = true;
                    GoToInstruction(7);
                    break;
            }
        }
        _counter = 0;
    }
    
     private void GoToInstruction15() {
         _nextInstruction = _Instruction15;
        var child1 = _nextInstruction.transform.GetChild(1).gameObject;
        var child2 = _nextInstruction.transform.GetChild(2).gameObject;

        child2.SetActive(false);
        
        if (audioPlayCounter < 2) {
            StartCoroutine(ActionAfterAudioStop(child1, clipCase1HistoryNarrator2));
        }
        else {
            child1.SetActive(true);
        }
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
        
        // Debug.Log("_Counter:" + _counter);
        if (_counter == 2 && instructionNumber == 2 ||
            _counter == 1 && instructionNumber == 4 ||
            _counter == 6 && instructionNumber == 6 ||
            _counter == 3 && instructionNumber == 10 ||
            _counter == 2 && instructionNumber == 11 ||
            _counter == 1 && instructionNumber == 12 ||
            _counter == 1 && instructionNumber == 13 ||
            _counter == 1 && instructionNumber == 14) {
            child2.SetActive(true);
        }
        else if (_counter == 7 && instructionNumber == 7) {
            GoToInstruction(15);
        }
    }

    public void ReturnToFromVideo() {
        if (StateNameController.CurrentActivePanel == _Instruction02) {
            GoToInstruction(2);
        }
        else if (StateNameController.CurrentActivePanel == _Instruction04) {
            GoToInstruction(4);
        }
        else if (StateNameController.CurrentActivePanel == _Instruction06) {
            GoToInstruction(6);
        }
        else if (StateNameController.CurrentActivePanel == _Instruction08) {
            GoToInstruction(8);
        }
        else if (StateNameController.CurrentActivePanel == _Instruction09) {
            GoToInstruction(9);
        }
        else if (StateNameController.CurrentActivePanel == _Instruction10) {
            GoToInstruction(10);
        }
        else if (StateNameController.CurrentActivePanel == _Instruction11) {
            GoToInstruction(11);
        }
        else if (StateNameController.CurrentActivePanel == _Instruction12) {
            GoToInstruction(12);
        }
        else if (StateNameController.CurrentActivePanel == _Instruction13) {
            GoToInstruction(13);
        }
        else if (StateNameController.CurrentActivePanel == _Instruction14) {
            GoToInstruction(14);
        }
    }
    
    // Control the doctor images behavior
    void ChangeFeedbackBackground(bool isFeedback) {
        BackgroundScript.DeactivateBackground();
        BackgroundScript.DeactivateDocImages();

        if (isFeedback) {
            if (_nextFeedback != _Feedback04 && _nextFeedback != _Feedback04_1) {
                BackgroundScript.GetBackground()[1].gameObject.SetActive(true);
                BackgroundScript.GetDocImages()[1].gameObject.SetActive(true);
            }
            else {
                BackgroundScript.GetBackground()[2].gameObject.SetActive(true);
                BackgroundScript.GetDocImages()[2].gameObject.SetActive(true);
            }
        }
        else {
            BackgroundScript.GetBackground()[0].gameObject.SetActive(true);
            BackgroundScript.GetDocImages()[0].gameObject.SetActive(true);
        }
    }
}