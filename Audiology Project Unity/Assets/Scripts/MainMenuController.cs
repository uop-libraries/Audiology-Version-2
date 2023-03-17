// using Google.XR.Cardboard.Editor;

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

public class MainMenuController : MonoBehaviour {
    [SerializeField] GameObject MainMenuObject;
    [SerializeField] GameObject MainCanvasObject;
    [SerializeField] GameSceneMainCanvas GameSceneMainCanvasScript;
    
    // Main Menu 
    GameObject _mainMenuPanelGameObject;
    
    // Main Canvas
    GameObject _mainCanvas;
    
    GameObject _case1HistoryObject;
    GameObject _case2HistoryObject;
    GameObject _case1CounselingObject;
    GameObject _case2CounselingObject;

    TextMeshProUGUI _case1HistoryText;
    TextMeshProUGUI _case2HistoryText;
    TextMeshProUGUI _case1CounselingText;
    TextMeshProUGUI _case2CounselingText;

    Animator _case1HistoryAnimator;
    Animator _case2HistoryAnimator;
    Animator _case1CounselingAnimator;
    Animator _case2CounselingAnimator;

    Button _case1HistoryButton;
    Button _case2HistoryButton;
    Button _case1CounselingButton;
    Button _case2CounselingButton;

    bool _isVRMode;

    void Awake() {
        _mainCanvas = GameObject.Find("Main_Canvas");
        _mainMenuPanelGameObject = GameObject.Find("MainMenuPanel");
        
        // Make Main Menu active and disable main canvas
        if (_mainCanvas && _mainMenuPanelGameObject) {
            _mainCanvas.SetActive(false);
            _mainMenuPanelGameObject.SetActive(true);
            
            // Make all game objects in main menu active
            foreach (Transform child in _mainMenuPanelGameObject.transform) {
                child.gameObject.SetActive(true);
            }
        }
    }

    // Start is called before the first frame update
    void Start() {
        _case1HistoryObject = GameObject.Find("Case_1_Button");
        _case2HistoryObject = GameObject.Find("Case_2_Button");
        _case1CounselingObject = GameObject.Find("Case_1_Counseling_Button");
        _case2CounselingObject = GameObject.Find("Case_2_Counseling_Button");

        if (_case1HistoryObject != null && _case2HistoryObject != null &&
            _case1CounselingObject != null && _case2CounselingObject != null) {
            _case1HistoryText = _case1HistoryObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            _case2HistoryText = _case2HistoryObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            _case1CounselingText = _case1CounselingObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            _case2CounselingText = _case2CounselingObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();

            _case1HistoryAnimator = _case1CounselingObject.GetComponent<Animator>();
            _case2HistoryAnimator = _case2CounselingObject.GetComponent<Animator>();
            _case1CounselingAnimator = _case1CounselingObject.GetComponent<Animator>();
            _case2CounselingAnimator = _case2CounselingObject.GetComponent<Animator>();

            _case1HistoryButton = _case1CounselingObject.GetComponent<Button>();
            _case2HistoryButton = _case2CounselingObject.GetComponent<Button>();
            _case1CounselingButton = _case1CounselingObject.GetComponent<Button>();
            _case2CounselingButton = _case2CounselingObject.GetComponent<Button>();
        }
    }

    // Update is called once per frame
    void Update() {
        if (_case1HistoryObject != null && _case2HistoryObject != null &&
            _case1CounselingObject != null && _case2CounselingObject != null) {
            SetCounselingButton();
        }
        // if (_isVRMode) {
        //     XRSettings.LoadDeviceByName("daydream");
        //     XRSettings.enabled = true;
        // }
        // else {
        //     XRSettings.LoadDeviceByName("");
        //     XRSettings.enabled = false;
        // }
    }

    // Keep counseling button lock until respective case history is complete
    private void SetCounselingButton() {
        if (!StateNameController.IsCase1HistoryDone) {
            _case1CounselingAnimator.enabled = false;
            _case1CounselingButton.interactable = false;
            _case1CounselingText.text = "Case 1 Counseling (Lock)";
        }
        else {
            _case1CounselingAnimator.enabled = true;
            _case1CounselingButton.interactable = true;
            if (!StateNameController.IsCase1CounselingDone) {
                _case1CounselingText.text = "Case 1 Counseling";
            }
            else {
                _case1CounselingText.text = "Case 1 Counseling (Completed)";
            }
            _case1HistoryText.text = "Case 1 History (Completed)";
        }

        if (!StateNameController.IsCase2HistoryDone) {
            _case2CounselingAnimator.enabled = false;
            _case2CounselingButton.interactable = false;
            _case2CounselingText.text = "Case 2 Counseling (Lock)";
        }
        else {
            _case2CounselingAnimator.enabled = true;
            _case2CounselingButton.interactable = true;
            if (!StateNameController.IsCase2CounselingDone) {
                _case2CounselingText.text = "Case 2 Counseling";
            }
            else {
                _case2CounselingText.text = "Case 2 Counseling (Completed)";
            }
            _case2HistoryText.text = "Case 2 History (Completed)";
        }
    }
    public void LoadCasePanel(int panel) {
        LoadClinicalCase(panel);
        Debug.Log("StateNameController.ClinicalCaseNumber: " + StateNameController.ClinicalCaseNumber);
        MainMenuObject.SetActive(!MainMenuObject.activeSelf);
        MainCanvasObject.SetActive(!MainCanvasObject.activeSelf);
        GameSceneMainCanvasScript.Startgame();
    }

    public void ReturnToMainMenu() {
        MainMenuObject.SetActive(!MainMenuObject.activeSelf);
        MainCanvasObject.SetActive(!MainCanvasObject.activeSelf);
    }

    // Case 1 and 2 button used this function in OnClick() event
    public void LoadScene(int scene) {
        // scene 0 is Title screen
        // scene 1 is Main Menu
        // scene 2 is Game scene
        SceneManager.LoadScene(scene);
    }

    // Case 1 and 2 button used this function in OnClick() event
    public void LoadClinicalCase(int caseNumber) {
        // caseNumber 1 is Case 1 History
        // caseNumber 2 is Case 2 History
        // caseNumber 3 is Case 1 Counseling
        // caseNumber 4 is Case 2 Counseling
        StateNameController.ClinicalCaseNumber = caseNumber;
    }

    // OnClick() event for quit button
    public void QuitApp() {
        Application.Quit();
    }

    // public void ToggleVRMode() {
    //     _isVRMode = !_isVRMode;
    // }
}