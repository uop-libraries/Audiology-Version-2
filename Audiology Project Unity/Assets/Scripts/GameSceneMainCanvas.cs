using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameSceneMainCanvas : MonoBehaviour
{
    // GameObject
    [SerializeField] private GameObject _case1History;
    [SerializeField] private GameObject _case1Counseling;
    [SerializeField] private GameObject _case2History;
    [SerializeField] private GameObject _case2Counseling;
    [SerializeField] private GameObject _ModuleText;
    [SerializeField] private bool _testingMode;

    private List<GameObject> ModuleTextList = new List<GameObject>();

    private GameObject _currentChildCaseScenario;
    private void Start()
    {   
        //Todo change this back after debug
        if (_testingMode)
        {
            StateNameController.ClinicalCaseNumber = 1;
        }
        StateNameController.IsStart = false;
        //Todo change this back after debug
        InitializeModuleText();
        ChangeClinicalCase(StateNameController.ClinicalCaseNumber);
        
    }

    private void InitializeModuleText()
    {
        foreach (Transform child in _ModuleText.transform)
        {
            ModuleTextList.Add(child.GameObject());
            child.GameObject().SetActive(false);
            // Debug.Log(child.GameObject());
        }
    }

    private void ChangeClinicalCase(int caseNumber)
    {
        _case1History.SetActive(false);
        _case1Counseling.SetActive(false);
        _case2History.SetActive(false);
        _case2Counseling.SetActive(false);

        switch (caseNumber)
        {
            case 1:
                _case1History.SetActive(true);
                break;
            case 2:
                _case2History.SetActive(true);
                break;
            case 3:
                _case1Counseling.SetActive(true);
                break;
            case 4:
                _case2Counseling.SetActive(true);
                break;
        }
        
        ModuleTextList[caseNumber - 1].GameObject().SetActive(true);
        Debug.Log("Current case Number: " + caseNumber);
        StateNameController.IsStart = true;
    }

    public void Case1Done()
    {
        Debug.Log("Case1HistoryDone");
        StateNameController.IsCase1HistoryDone = true;
        SceneManager.LoadScene(1);
    }
    
    public void Case2Done()
    {
        Debug.Log("Case2HistoryDone");
        StateNameController.IsCase2HistoryDone = true;
        SceneManager.LoadScene(1);
    }
    
    // OnClick() event for quit button
    public void QuitApp()
    {
        Application.Quit();
    }
    
    
}
