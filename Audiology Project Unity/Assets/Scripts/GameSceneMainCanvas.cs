using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameSceneMainCanvas : MonoBehaviour {
    // GameObject
    [SerializeField] private GameObject _case1History;
    [SerializeField] private GameObject _case1Counseling;
    [SerializeField] private GameObject _case2History;
    [SerializeField] private GameObject _case2Counseling;
    [SerializeField] private GameObject _ModuleText;
    [SerializeField] private bool _testingMode;
    [SerializeField] private int _testingCaseNumber;

    private List<GameObject> _moduleTextList = new List<GameObject>();
    private List<GameObject> _ModulePanelList = new List<GameObject>();

    [SerializeField] BackgroundScript backgroundScript;
    [SerializeField] CaseOneHistory caseOneHistoryScript;
    [SerializeField] CaseOneCounseling caseOneCounselingScript;

    private GameObject _currentChildCaseScenario;
    private int _nextPanel;

    private void Start() {
        // Todo change this back after debug ----------------------------( START )
        if (_testingMode) {
            StateNameController.ClinicalCaseNumber = _testingCaseNumber;
            Debug.LogWarningFormat("Testing Mode is Enable");
        }
        // Todo change this back after debug -----------------------------( END )

        _nextPanel = 1;
        backgroundScript.BackgroundScriptStart();
        InitializeModuleText();
        InitializeClinicalCasePanel();
        GoToClinicalCase(StateNameController.ClinicalCaseNumber);

    }

    private void Update() {
        // Todo Disable after testing ----------------------( START )

        if (Input.GetKeyDown(KeyCode.N)) {
            _nextPanel++;
            if (StateNameController.ClinicalCaseNumber == 1) {
                caseOneHistoryScript.GoToInstruction(_nextPanel);
            }
            else if (StateNameController.ClinicalCaseNumber == 3) {
                if (_nextPanel < 4) {
                    caseOneCounselingScript.GoToNarratorPanel(_nextPanel);
                }
                else if (_nextPanel >= 4) {
                    caseOneCounselingScript.GoToInstruction(_nextPanel - 3);
                }
            }
            Debug.Log("_nextPanel: " + _nextPanel);
        }
        if (Input.GetKeyDown(KeyCode.B)) {
            _nextPanel--;
            if (StateNameController.ClinicalCaseNumber == 1) {
                caseOneHistoryScript.GoToInstruction(_nextPanel);
            }
            else if (StateNameController.ClinicalCaseNumber == 3) {
                if (_nextPanel < 4) {
                    caseOneCounselingScript.GoToNarratorPanel(_nextPanel);
                }
                else if (_nextPanel >= 4) {
                    caseOneCounselingScript.GoToInstruction(_nextPanel - 3);
                }
            }
            Debug.Log("_nextPanel: " + _nextPanel);
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(1);
        }
        // Todo Disable after testing --------------------------( END )
    }

    private void InitializeModuleText() {
        // Put each text module into a list
        foreach (Transform child in _ModuleText.transform) {
            _moduleTextList.Add(child.GameObject());
            child.GameObject().SetActive(false);
        }
    }

    private void InitializeClinicalCasePanel() {
        // Put each Panel into a list
        _ModulePanelList.Add(_case1History);
        _ModulePanelList.Add(_case2History);
        _ModulePanelList.Add(_case1Counseling);
        _ModulePanelList.Add(_case2Counseling);
    }

    private void GoToClinicalCase(int caseNumber) {
        // Make all panels inactive
        foreach (GameObject child in _ModulePanelList) {
            child.GameObject().SetActive(false);
        }

        // Set the corresponding case number/panel active
        try {
            Debug.Log("Current case Number: " + caseNumber);
            _ModulePanelList[caseNumber - 1].GameObject().SetActive(true);
            _moduleTextList[caseNumber - 1].GameObject().SetActive(true);

            if (caseNumber == 1) {
                caseOneHistoryScript.StartCase1History();
            }
            if (caseNumber == 3) {
                caseOneCounselingScript.StartCase1Counseling();
            }
            // TODO Add script start here ================================
        }
        catch (Exception e) {
            Console.WriteLine(e);
            Debug.LogErrorFormat("ERROR: Need to go to GameManager and enable Testing Mode including specific case # or " +
                "Play in Main Menu Scene");
            throw;
        }
    }

    public void Case1Done() {
        Debug.Log("Case1HistoryDone");
        StateNameController.IsCase1HistoryDone = true;
        SceneManager.LoadScene(1);
    }

    public void Case2Done() {
        Debug.Log("Case2HistoryDone");
        StateNameController.IsCase2HistoryDone = true;
        SceneManager.LoadScene(1);
    }

    // OnClick() event for quit button
    public void QuitApp() {
        Application.Quit();
    }


}