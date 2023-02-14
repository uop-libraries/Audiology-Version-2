using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneMainCanvas : MonoBehaviour
{
    // GameObject
    [SerializeField] private GameObject _case1History;
    [SerializeField] private GameObject _case1Counseling;
    [SerializeField] private GameObject _case2History;
    [SerializeField] private GameObject _case2Counseling;
    [SerializeField] private GameObject _case1HistoryFirstPanel;
    [SerializeField] private GameObject _case2HistoryFirstPanel;
    private GameObject _currentChildCaseScenario;
    private CaseOneHistory _caseOneHistoryObject = new CaseOneHistory();
    private void Start()
    {   
        //Todo change this back after debug
        StateNameController.clinicalCaseNumber = 1;
        
        //Todo change this back after debug
        ChangeClinicalCase();
    }

    public void ChangeClinicalCase()
    {
        _case1History.SetActive(false);
        _case1Counseling.SetActive(false);
        _case2History.SetActive(false);
        _case2Counseling.SetActive(false);
        _case1HistoryFirstPanel.SetActive(false);

        if (StateNameController.clinicalCaseNumber == 1)
        {
            _case1History.SetActive(true);
            StateNameController.currentActivePanel = _case1HistoryFirstPanel;
            _caseOneHistoryObject.ActivateCase1HistoryPanel();
            // _case1History.GetComponentInChildren<GameObject>()
        }
        else if (StateNameController.clinicalCaseNumber == 2)
        {
            _case2History.SetActive(true);
            StateNameController.currentActivePanel = _case2HistoryFirstPanel;
            // _case1History.GetComponentInChildren<GameObject>()
        }
        else if (StateNameController.clinicalCaseNumber == 3)
        {
            _case1Counseling.SetActive(true);
            StateNameController.currentActivePanel = _case1Counseling;
            // _case1History.GetComponentInChildren<GameObject>()
        }
        else if (StateNameController.clinicalCaseNumber == 4)
        {
            _case2Counseling.SetActive(true);
            StateNameController.currentActivePanel = _case2Counseling;
        }
    }
    
    // OnClick() event for quit button
    public void QuitApp()
    {
        Application.Quit();
    }
    
    
}
