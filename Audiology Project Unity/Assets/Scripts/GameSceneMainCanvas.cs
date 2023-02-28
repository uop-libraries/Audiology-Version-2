using System;
using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] private bool _testingMode;

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
        ChangeClinicalCase();
    }

    private void ChangeClinicalCase()
    {
        _case1History.SetActive(false);
        _case1Counseling.SetActive(false);
        _case2History.SetActive(false);
        _case2Counseling.SetActive(false);

        if (StateNameController.ClinicalCaseNumber == 1)
        {
            _case1History.SetActive(true);
        }
        else if (StateNameController.ClinicalCaseNumber == 2)
        {
            _case2History.SetActive(true);
        }
        else if (StateNameController.ClinicalCaseNumber == 3)
        {
            _case1Counseling.SetActive(true);
        }
        else if (StateNameController.ClinicalCaseNumber == 4)
        {
            _case2Counseling.SetActive(true);
        }
        Debug.Log("Current case Number: " + StateNameController.ClinicalCaseNumber);
        StateNameController.IsStart = true;
    }
    
    // OnClick() event for quit button
    public void QuitApp()
    {
        Application.Quit();
    }
    
    
}
