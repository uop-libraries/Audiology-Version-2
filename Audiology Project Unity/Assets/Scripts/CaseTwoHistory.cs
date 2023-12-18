using System.Collections;
using System.Collections.Generic;
using Michsky.MUIP;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CaseTwoHistory : MonoBehaviour {
    // private GameObject _currentPanel;
    GameObject _nextInstruction;
    GameObject _nextFeedback;

    [Header("Dependencies Script")]
    [SerializeField] BackgroundScript backgroundScript;

    [Header("Narrator Panel")]
    [SerializeField] GameObject c2HNarrator01;

    [Header("Instruction Panel")]
    [SerializeField] GameObject c2HInstruction01;
    [SerializeField] GameObject c2HInstruction02;
    [SerializeField] GameObject c2HInstruction03;
    [SerializeField] GameObject c2HInstruction04;
    [SerializeField] GameObject c2HInstruction05;
    [SerializeField] GameObject c2HInstruction06;
    [SerializeField] GameObject c2HInstruction07;
    [SerializeField] GameObject c2HInstruction08;
    [SerializeField] GameObject c2HInstruction09;
    [SerializeField] GameObject c2HInstruction10;
    [SerializeField] GameObject c2HInstruction11;
    [SerializeField] GameObject c2HInstruction12;
    [SerializeField] GameObject c2HInstruction13;
    [SerializeField] GameObject c2HInstruction14;
    [SerializeField] GameObject c2HInstruction15;
    
    [Header("Feedback Panel")]
    [SerializeField] GameObject c2HFeedback01;
    [SerializeField] GameObject c2HFeedback02;
    [SerializeField] GameObject c2HFeedback03;
    [SerializeField] GameObject c2HFeedback04;
    [SerializeField] GameObject c2HFeedback05;
    [SerializeField] GameObject c2HFeedback06;
    [SerializeField] GameObject c2HFeedback07;
    [SerializeField] GameObject c2HFeedback08;

    [Header("AudioSource")]
    [SerializeField] public AudioSource audioSource;
    
    // Note Some audio clip can be reuse from Case 1 History to save memory space
    [Header("AudioClip")]
    [SerializeField] AudioClip clipC2HNarrator;
    [SerializeField] AudioClip clipC2HNarrator2;

    // Note Some audio clip can be reuse from Case 1 History to save memory space
    [SerializeField] AudioClip clipC2HInstruction1;

    // Note Some audio clip can be reuse from Case 1 History to save memory space
    [SerializeField] AudioClip clipC2HFeedback01;
    [SerializeField] AudioClip clipC2HFeedback02;
    [SerializeField] AudioClip clipC2HFeedback03;
    [SerializeField] AudioClip clipC2HFeedback04;
    [SerializeField] AudioClip clipC2HFeedback05;
    [SerializeField] AudioClip clipC2HFeedback06;
    [SerializeField] AudioClip clipC2HFeedback07;
    [SerializeField] AudioClip clipC2HFeedback08;

    // Array of each choice in Case Two
    // Allows for a total reset if the player chooses to play again after finishing the case
    [Header("Choices")] 
    [SerializeField] private Image[] choices;
    
    private int _counter;
    int audioPlayCounter;
    private bool _isFirstTime = true;
    private bool _isFirstTime1 = true;
    
    // Static info that is used to return to the case if the
    // player has gone back to the main menu and returned to the case again
    private static int _returnPanelNumber;
    private static int _returnFeedbackNumber;
    private static bool _hasGoneBack = false;
    private static bool _wasOnFeedback = false;
    
    private static bool _hasCompleted = false;

    public void StartCase2History() {
        _counter = 0;
        InitializePanel();
    }

    private void InitializePanel() {
        var currentPanel = "Case2_history";
        var parent = GameObject.Find(currentPanel);

        Debug.Log("parent: " + parent);

        // make all child object inactive
        foreach (Transform child in parent.transform) {
            child.gameObject.SetActive(false);
        }

        // Simple logic to check if the player is just starting the case, returning to it, or restarting it
        if (_hasCompleted)
        {
            _hasGoneBack = false;
        }
        
        if (!_hasGoneBack)
        {
            GoToFirstPanel();
        }
        else if (_hasGoneBack && _wasOnFeedback)
        {
            GoToFeedBack(_returnFeedbackNumber);
        }
        else if (_hasGoneBack && !_wasOnFeedback)
        {
            GoToInstruction(_returnPanelNumber);
        }
    }

    private void GoToFirstPanel() {
        ResetComplete();
        StateNameController.CurrentActivePanel = c2HNarrator01;
        _nextInstruction = c2HNarrator01;
        StateNameController.SwitchPanel(_nextInstruction);

        var child2 = _nextInstruction.transform.GetChild(1).gameObject;
        StartCoroutine(ActionAfterAudioStop(child2, clipC2HNarrator));
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
        
        // Turns on "_hasGoneBack", meaning the player will now return
        // to their last spot in the case if they go to the menu and come back
        if (panelNumber >= 1)
        {
            _hasGoneBack = true;
        }

        // Getting current panel info for return states
        _returnPanelNumber = panelNumber;
        _wasOnFeedback = false;
        
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
                _nextInstruction = c2HInstruction01;
                if (audioPlayCounter < 2) {
                    StartCoroutine(ActionAfterAudioStop(null, clipC2HInstruction1));
                }
                break;
            case 2:
                _nextInstruction = c2HInstruction02;
                GoToInstructionNumber(panelNumber);
                break;
            case 3:
                _nextInstruction = c2HInstruction03;
                break;
            case 4:
                _nextInstruction = c2HInstruction04;
                GoToInstructionNumber(panelNumber);
                break;
            case 5:
                // _nextInstruction = c2HInstruction05;
                GoToInstruction05();
                break;
            case 6:
                _nextInstruction = c2HInstruction06;
                GoToInstruction06();
                break;
            case 7:
                // _nextInstruction = c2HInstruction07;
                GoToInstruction07();
                break;
            case 8:
                _nextInstruction = c2HInstruction08;
                GoToInstructionNumber(panelNumber);
                // GoToInstruction08();
                break;
            case 9:
                GoToInstruction09();
                break;
            case 10:
                _nextInstruction = c2HInstruction10;
                GoToInstructionNumber(panelNumber);
                break;
            case 11:
                _nextInstruction = c2HInstruction11;
                GoToInstructionNumber(panelNumber);
                break;
            case 12:
                _nextInstruction = c2HInstruction12;
                GoToInstructionNumber(panelNumber);
                break;
            case 13:
                _nextInstruction = c2HInstruction13;
                GoToInstructionNumber(panelNumber);
                break;
            case 14:
                _nextInstruction = c2HInstruction14;
                GoToInstructionNumber(panelNumber);
                break;
            case 15:
                _nextInstruction = c2HInstruction15;
                GoToInstruction15();
                break;
        }
        StateNameController.SwitchPanel(_nextInstruction);
        BackgroundScript.ActivateBackground(true);
        ChangeFeedbackBackground(false);
    }

    public void GoToFeedBack(int value) {
        
        // Getting current panel info for return states
        _wasOnFeedback = true;
        _returnFeedbackNumber = value;
        
        AudioClip nextAudioClip = null;

        // Get current feedback panel
        _nextFeedback = value switch {
            1 => c2HFeedback01,
            2 => c2HFeedback02,
            3 => c2HFeedback03,
            4 => c2HFeedback04,
            5 => c2HFeedback05,
            6 => c2HFeedback06,
            7 => c2HFeedback07,
            8 => c2HFeedback08,
            _ => _nextFeedback
        };
        var child2 = _nextFeedback.transform.GetChild(1).gameObject;

        // Get next audio feedback clip
        nextAudioClip = value switch {
            1 => clipC2HFeedback01,
            2 => clipC2HFeedback02,
            3 => clipC2HFeedback03,
            4 => clipC2HFeedback04,
            5 => clipC2HFeedback05,
            6 => clipC2HFeedback06,
            7 => clipC2HFeedback07,
            8 => clipC2HFeedback08,
            _ => nextAudioClip
        };

        ChangeFeedbackBackground(true);
        StateNameController.SwitchPanel(_nextFeedback);

        // Play audio and control the button activation
        StartCoroutine(ActionAfterAudioStop(child2, nextAudioClip));

    }
    
    private void GoToInstruction05() {
        _counter = 0;
        _nextInstruction = c2HInstruction05;
        var child1 = _nextInstruction.transform.GetChild(1).gameObject;
        var child2 = _nextInstruction.transform.GetChild(2).gameObject;

        child2.SetActive(false);

        foreach (Transform child in child1.transform) {
            if (child.gameObject.GetComponent<Image>().color == Color.grey) {
                if (child.gameObject.name is "Option_A" or "Option_B") {
                    child.gameObject.SetActive(false);
                }
                
                if (child.gameObject.activeSelf == false) {
                    _counter++;
                }
            }

            if (_counter == 2) {
                // child2.SetActive(true);
                child.gameObject.SetActive(false);
                GoToInstruction(8);
            }
        }
        _counter = 0;
    }
    
     // Instruction for Tinnitus option
    private void GoToInstruction06() {
        _counter = 0;
        _nextInstruction = c2HInstruction06;
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
                case 7: {
                    child2.SetActive(true);
                    _isFirstTime = true;
                    break;
                }
            }
        }
        _counter = 0;
    }
    
    // Instruction for hearing abilities option
    private void GoToInstruction07() {
        _counter = 0;
        _nextInstruction = c2HInstruction07;
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
                case 5: {
                    if (child.gameObject.name == "Option_H") {
                        child.gameObject.SetActive(true);
                    }

                    break;
                }
                case 6: {
                    if (child.gameObject.name == "Option_I") {
                        child.gameObject.SetActive(true);
                    }

                    break;
                }
                case 9: {
                    child2.SetActive(true);
                    _isFirstTime = true;
                    break;
                }
            }
        }
        _counter = 0;
    }

    // Instruction for vertigo option
    private void GoToInstruction09() {
        _counter = 0;
        _nextInstruction = c2HInstruction09;
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
                    child2.SetActive(true);
                    _isFirstTime1 = true;
                    break;
            }
        }
        _counter = 0;
    }
    
    private void GoToInstruction15() {
        _nextInstruction = c2HInstruction15;
        var child1 = _nextInstruction.transform.GetChild(1).gameObject;
        var child2 = _nextInstruction.transform.GetChild(2).gameObject;

        child2.SetActive(false);
        
        if (audioPlayCounter < 2) {
            StartCoroutine(ActionAfterAudioStop(child1, clipC2HNarrator2));
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
                if (instructionNumber == 8) {
                    child.gameObject.SetActive(false);
                }

                _counter++;
            }
        }

        if (_counter == 2 && instructionNumber == 2 ||
            _counter == 1 && instructionNumber == 4 ||
            _counter == 7 && instructionNumber == 6 ||
            _counter == 1 && instructionNumber == 10 ||
            _counter == 2 && instructionNumber == 11 ||
            _counter == 1 && instructionNumber == 12 ||
            _counter == 1 && instructionNumber == 13 ||
            _counter == 1 && instructionNumber == 14) {
            child2.SetActive(true);
        }
        else if (_counter == 6 && instructionNumber == 8) {
            GoToInstruction(15);
        }
    }

    public void ReturnToFromVideo() {
        if (StateNameController.CurrentActivePanel == c2HInstruction02) {
            GoToInstruction(2);
        }
        else if (StateNameController.CurrentActivePanel == c2HInstruction04) {
            GoToInstruction(4);
        }
        else if (StateNameController.CurrentActivePanel == c2HInstruction06) {
            GoToInstruction(6);
        }
        else if (StateNameController.CurrentActivePanel == c2HInstruction07) {
            GoToInstruction(7);
        }
        else if (StateNameController.CurrentActivePanel == c2HInstruction08) {
            GoToInstruction(8);
        }
        else if (StateNameController.CurrentActivePanel == c2HInstruction09) {
            GoToInstruction(9);
        }
        else if (StateNameController.CurrentActivePanel == c2HInstruction10) {
            GoToInstruction(10);
        }
        else if (StateNameController.CurrentActivePanel == c2HInstruction11) {
            GoToInstruction(11);
        }
        else if (StateNameController.CurrentActivePanel == c2HInstruction12) {
            GoToInstruction(12);
        }
        else if (StateNameController.CurrentActivePanel == c2HInstruction13) {
            GoToInstruction(13);
        }
        else if (StateNameController.CurrentActivePanel == c2HInstruction14) {
            GoToInstruction(14);
        }
    }

    // Control the doctor images behavior
    void ChangeFeedbackBackground(bool isFeedback) {
        BackgroundScript.DeactivateBackground();
        BackgroundScript.DeactivateDocImages();

        if (isFeedback) {
            if (_nextFeedback != c2HFeedback04 && _nextFeedback != c2HFeedback05) {
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
    
    // Runs once the case has been completed
    public void SetComplete()
    {
        // Set "_hasCompleted" to true, which will make it so ResetComplete() will run if the case is chosen again
        _hasCompleted = true;
        
        // Gets the color to reset each button
        byte R = 227;
        byte G = 88;
        byte B = 0;
        byte A = 255;
        
        // Resets each button; makes it look like it was never pressed
        foreach (var choice in choices)
        {
            UIGradient uiGrad = choice.gameObject.GetComponent<UIGradient>();
            choice.color = new Color32(R, G, B, A);
            uiGrad.enabled = true;
        }

        // For loops to reset "scrolling"/"counter" choices
        // AKA choice menus that reveal more choices after one has been pressed
        for (int i = 0; i < 4; i++)
        {
            int offset = 33;
            choices[offset + i].gameObject.SetActive(false);
        }
        for (int i = 0; i < 6; i++)
        {
            int offset = 40;
            choices[offset + i].gameObject.SetActive(false);
        }
        for (int i = 0; i < 6; i++)
        {
            int offset = 53;
            choices[offset + i].gameObject.SetActive(false);
        }
    }

    // Turns off "_hasCompleted", allows the player to go through the case again
    public void ResetComplete()
    {
        _hasCompleted = false;
    }
}