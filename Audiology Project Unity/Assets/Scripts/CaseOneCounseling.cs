using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


public class CaseOneCounseling : MonoBehaviour {
    // PanelType _currentPanelType;

    GameObject _nextNarration;
    GameObject _nextInstruction;
    GameObject _nextFeedback;
    GameObject _nextTopic;
    GameObject _nextExplanation;
    [SerializeField] GameSceneMainCanvas _gameSceneMainCanvasScript;

    [Header("Narrator Panel")]
    [SerializeField] GameObject _C1C_Narrator_01;
    [SerializeField] GameObject _C1C_Narrator_02;
    [SerializeField] GameObject _C1C_Narrator_03;

    [Header("Instruction Panel")]
    [SerializeField] GameObject _C1C_Instruction_01;
    [SerializeField] GameObject _C1C_Instruction_02;
    [SerializeField] GameObject _C1C_Instruction_03;
    [SerializeField] GameObject _C1C_Instruction_04;
    [SerializeField] GameObject _C1C_Instruction_05;
    [SerializeField] GameObject _C1C_Instruction_06;
    [SerializeField] GameObject _C1C_Instruction_07;
    [SerializeField] GameObject _C1C_Instruction_08;
    [SerializeField] GameObject _C1C_Instruction_09;
    [SerializeField] GameObject _C1C_Instruction_10;
    [SerializeField] GameObject _C1C_Instruction_11;
    [SerializeField] GameObject _C1C_Instruction_12;

    [Header("Feedback Panel")]
    [SerializeField] GameObject _C1C_Feedback_01;
    [SerializeField] GameObject _C1C_Feedback_02;
    [SerializeField] GameObject _C1C_Feedback_03;
    [SerializeField] GameObject _C1C_Feedback_04;
    [SerializeField] GameObject _C1C_Feedback_05;
    [SerializeField] GameObject _C1C_Feedback_06;
    [SerializeField] GameObject _C1C_Feedback_07;
    [SerializeField] GameObject _C1C_Feedback_08;

    [Header("Topic Panel")]
    [SerializeField] GameObject _C1C_Topic_01_1;
    [SerializeField] GameObject _C1C_Topic_01_2;
    [SerializeField] GameObject _C1C_Topic_02;
    [SerializeField] GameObject _C1C_Topic_03;
    [SerializeField] GameObject _C1C_Topic_04;
    [SerializeField] GameObject _C1C_Topic_05_1;
    [SerializeField] GameObject _C1C_Topic_05_2;
    [SerializeField] GameObject _C1C_Topic_05_3;
    [SerializeField] GameObject _C1C_Topic_05_4;
    [SerializeField] GameObject _C1C_Topic_06_1;
    [SerializeField] GameObject _C1C_Topic_06_2;
    [SerializeField] GameObject _C1C_Topic_07_1;
    [SerializeField] GameObject _C1C_Topic_07_2;
    [SerializeField] GameObject _C1C_Topic_07_3;
    
    [Header("Explanation Panel")]
    [SerializeField] GameObject _C1C_Explanation_01_1;
    [SerializeField] GameObject _C1C_Explanation_01_2;
    [SerializeField] GameObject _C1C_Explanation_01_3;
    [SerializeField] GameObject _C1C_Explanation_02_1;
    [SerializeField] GameObject _C1C_Explanation_02_2;
    [SerializeField] GameObject _C1C_Explanation_02_3;

    [Header("AudioSource")]
    [SerializeField] private AudioSource audioSource;

    [Header("AudioClip")]
    // Narration audio clip
    [SerializeField] AudioClip clipC1CNarration01;
    [SerializeField] AudioClip clipC1CNarration02;
    [SerializeField] AudioClip clipC1CNarration03;

    // Instruction audio clip
    [SerializeField] AudioClip clipC1CInstruction01;

    // Feedback audio clip
    [SerializeField] AudioClip clipC1CFeedback01;
    [SerializeField] AudioClip clipC1CFeedback02;
    [SerializeField] AudioClip clipC1CFeedback03;
    [SerializeField] AudioClip clipC1CFeedback04;
    [SerializeField] AudioClip clipC1CFeedback05;
    [SerializeField] AudioClip clipC1CFeedback06;
    [SerializeField] AudioClip clipC1CFeedback07;
    [SerializeField] AudioClip clipC1CFeedback08;

    // Topic audio clip
    [SerializeField] AudioClip clipC1CTopic01_1;
    [SerializeField] AudioClip clipC1CTopic01_2;
    [SerializeField] AudioClip clipC1CTopic02;
    [SerializeField] AudioClip clipC1CTopic03;
    [SerializeField] AudioClip clipC1CTopic04;
    [SerializeField] AudioClip clipC1CTopic05_1;
    [SerializeField] AudioClip clipC1CTopic05_2;
    [SerializeField] AudioClip clipC1CTopic05_3;
    [SerializeField] AudioClip clipC1CTopic05_4;
    [SerializeField] AudioClip clipC1CTopic06_1;
    [SerializeField] AudioClip clipC1CTopic06_2;
    [SerializeField] AudioClip clipC1CTopic07_1;
    [SerializeField] AudioClip clipC1CTopic07_2;
    [SerializeField] AudioClip clipC1CTopic07_3;
    
    // Explanation audio clip
    [SerializeField] AudioClip clipC1CExplanation01_1;
    [SerializeField] AudioClip clipC1CExplanation01_2;
    [SerializeField] AudioClip clipC1CExplanation01_3;
    [SerializeField] AudioClip clipC1CExplanation02_1;
    [SerializeField] AudioClip clipC1CExplanation02_2;
    [SerializeField] AudioClip clipC1CExplanation02_3;
    
    private int _counter;

    public enum Panel {
        Narrator,
        Instruction,
        Feedback,
        Topic,
        Explanation,
    }

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
        Panel narratorPanel = Panel.Narrator;

        switch (panelNum) {
            case 1:
                _nextNarration = _C1C_Narrator_01;
                _nextClip = clipC1CNarration01;
                break;
            case 2:
                _nextNarration = _C1C_Narrator_02;
                _nextClip = clipC1CNarration02;
                break;
            case 3:
                _nextNarration = _C1C_Narrator_03;
                _nextClip = clipC1CNarration03;
                break;
        }

        StateNameController.SwitchPanel(_nextNarration);
        ChangeBackground(narratorPanel);

        var child2 = _nextNarration.transform.GetChild(1).gameObject;
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
        audioSource.Stop();
        const Panel instructionPanel = Panel.Instruction;

        switch (panelNumber) {
            case 1:
                _nextInstruction = _C1C_Instruction_01;
                StartCoroutine(ActionAfterAudioStop(null, clipC1CInstruction01));
                break;
            case 2:
                _nextInstruction = _C1C_Instruction_02;
                break;
            case 3:
                _nextInstruction = _C1C_Instruction_03;
                break;
            case 4:
                _nextInstruction = _C1C_Instruction_04;
                break;
            case 5:
                _nextInstruction = _C1C_Instruction_05;
                break;
            case 6:
                _nextInstruction = _C1C_Instruction_06;
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
                break;
            case 11:
                _nextInstruction = _C1C_Instruction_11;
                break;
            case 12:
                _nextInstruction = _C1C_Instruction_12;
                GoToInstructionNumber(panelNumber);
                break;

        }
        StateNameController.SwitchPanel(_nextInstruction);
        BackgroundScript.ActivateBackground(true);
        ChangeBackground(instructionPanel);
    }

    private void GoToInstructionNumber(int instructionNumber) {
        _counter = 0;
        var child1 = _nextInstruction.transform.GetChild(1).gameObject;
        var child2 = _nextInstruction.transform.GetChild(2).gameObject;

        child2.SetActive(false);

        foreach (Transform child in child1.transform) {
            if (child.gameObject.GetComponent<Image>().color == Color.grey) {
                // if (instructionNumber == 7) {
                //     child.gameObject.SetActive(false);
                // }

                _counter++;
            }
        }

        if (_counter == 2 && instructionNumber == 7 ||
            _counter == 2 && instructionNumber == 12) {
            child2.SetActive(true);
        }
    }

    private void DeactivateBackground() {
        BackgroundScript.DeactivateBackground();
        BackgroundScript.DeactivateDocImages();
        BackgroundScript.DeactivateDiagram();
    }
    // Control the doctor images and other diagram behavior
    public void ChangeBackground(Panel panel) {
        DeactivateBackground();

        Debug.Log("Panel type: " + panel);
        switch (panel) {
            case Panel.Narrator:
                BackgroundScript.GetBackground()[0].gameObject.SetActive(true);
                BackgroundScript.GetDocImages()[3].gameObject.SetActive(true);
                break;
            case Panel.Instruction:
                BackgroundScript.GetBackground()[0].gameObject.SetActive(true);
                BackgroundScript.GetDocImages()[0].gameObject.SetActive(true);
                break;
            case Panel.Feedback:
                BackgroundScript.GetBackground()[1].gameObject.SetActive(true);
                BackgroundScript.GetDocImages()[1].gameObject.SetActive(true);
                break;
            case Panel.Topic or Panel.Explanation:
                BackgroundScript.GetBackground()[2].gameObject.SetActive(true);
                BackgroundScript.GetDocImages()[1].gameObject.SetActive(true);

                // Get Audio gram Diagram for current topic
                if (StateNameController.CurrentActivePanel == _C1C_Topic_01_1 ||
                    StateNameController.CurrentActivePanel == _C1C_Topic_01_2 ||
                    StateNameController.CurrentActivePanel == _C1C_Topic_02) {
                    BackgroundScript.GetDiagram()[0].gameObject.SetActive(true);
                }
                // Get Hearing Aid diagram for current topic
                else if (StateNameController.CurrentActivePanel == _C1C_Topic_05_1 ||
                    StateNameController.CurrentActivePanel == _C1C_Topic_05_2 ||
                    StateNameController.CurrentActivePanel == _C1C_Topic_05_3 ||
                    StateNameController.CurrentActivePanel == _C1C_Topic_05_4) {
                    BackgroundScript.GetDiagram()[1].gameObject.SetActive(true);
                }
                break;
        }

    }

    public void GoToFeedBack(int value) {
        const Panel feedbackPanel = Panel.Feedback;
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

        StateNameController.SwitchPanel(_nextFeedback);
        BackgroundScript.ActivateBackground(true);
        ChangeBackground(feedbackPanel);

        // Play audio and control the button activation
        StartCoroutine(ActionAfterAudioStop(child2, nextAudioClip));
    }

    public void GoToTopic(int panelNumber) {
        Debug.Log("Topic Panel: " + panelNumber);
        const Panel topicPanel = Panel.Topic;
        AudioClip nextAudioClip = null;

        // Get current feedback panel
        _nextTopic = panelNumber switch {
            1 => _C1C_Topic_01_1,
            2 => _C1C_Topic_01_2,
            3 => _C1C_Topic_02,
            4 => _C1C_Topic_03,
            5 => _C1C_Topic_04,
            6 => _C1C_Topic_05_1,
            7 => _C1C_Topic_05_2,
            8 => _C1C_Topic_05_3,
            9 => _C1C_Topic_05_4,
            10 => _C1C_Topic_06_1,
            11 => _C1C_Topic_06_2,
            12 => _C1C_Topic_07_1,
            13 => _C1C_Topic_07_2,
            14 => _C1C_Topic_07_3,
            _ => _nextFeedback,
        };
        var child2 = _nextTopic.transform.GetChild(1).gameObject;

        // Get next audio feedback clip
        nextAudioClip = panelNumber switch {
            1 => clipC1CTopic01_1,
            2 => clipC1CTopic01_2,
            3 => clipC1CTopic02,
            4 => clipC1CTopic03,
            5 => clipC1CTopic04,
            6 => clipC1CTopic05_1,
            7 => clipC1CTopic05_2,
            8 => clipC1CTopic05_3,
            9 => clipC1CTopic05_4,
            10 => clipC1CTopic06_1,
            11 => clipC1CTopic06_2,
            12 => clipC1CTopic07_1,
            13 => clipC1CTopic07_2,
            14 => clipC1CTopic07_3,
            _ => nextAudioClip,
        };

        StateNameController.SwitchPanel(_nextTopic);
        BackgroundScript.ActivateBackground(true);
        ChangeBackground(topicPanel);

        // Play audio and control the button activation
        StartCoroutine(ActionAfterAudioStop(child2, nextAudioClip));
    }
    
    public void GoToExplanation(int value) {
        const Panel explanationPanel = Panel.Explanation;
        AudioClip nextAudioClip = null;

        // Get current feedback panel
        _nextExplanation = value switch {
            1 => _C1C_Explanation_01_1,
            2 => _C1C_Explanation_01_2,
            3 => _C1C_Explanation_01_3,
            4 => _C1C_Explanation_02_1,
            5 => _C1C_Explanation_02_2,
            6 => _C1C_Explanation_02_3,
            _ => _nextFeedback,
        };
        var child2 = _nextExplanation.transform.GetChild(1).gameObject;

        // Get next audio feedback clip
        nextAudioClip = value switch {
            1 => clipC1CExplanation01_1,
            2 => clipC1CExplanation01_2,
            3 => clipC1CExplanation01_3,
            4 => clipC1CExplanation02_1,
            5 => clipC1CExplanation02_2,
            6 => clipC1CExplanation02_3,
            _ => nextAudioClip
        };

        StateNameController.SwitchPanel(_nextExplanation);
        BackgroundScript.ActivateBackground(true);
        ChangeBackground(explanationPanel);

        // Play audio and control the button activation
        StartCoroutine(ActionAfterAudioStop(child2, nextAudioClip));
    }

    public void ReturnToFromVideo() {
        if (StateNameController.CurrentActivePanel == _C1C_Instruction_07) {
            GoToInstruction(7);
        }
        else if (StateNameController.CurrentActivePanel == _C1C_Topic_07_2) {
            GoToTopic(14);
        }
        else if (StateNameController.CurrentActivePanel == _C1C_Topic_07_3) {
            GoToInstruction(12);
        }
        else if (StateNameController.CurrentActivePanel == _C1C_Instruction_12) {
            GoToInstruction(12);
            _gameSceneMainCanvasScript.Case1CounselingDone();
        }
    }

}