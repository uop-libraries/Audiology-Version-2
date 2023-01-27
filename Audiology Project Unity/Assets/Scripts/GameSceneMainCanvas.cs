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

    private void Start()
    {   
        //Todo change this back after debug
        _case1History.SetActive(true);
        _case1HistoryFirstPanel.SetActive(true);
        StateNameController.CurrentActivePanel = _case1HistoryFirstPanel;
        
        //Todo change this back after debug
        // ChangeClinicalCase();
    }

    public void ChangeClinicalCase()
    {
        if (StateNameController.clinicalCaseNumber == 1)
        {
            _case1History.SetActive(true);
            _case1Counseling.SetActive(false);
            _case2History.SetActive(false);
            _case2Counseling.SetActive(false);
            _case1HistoryFirstPanel.SetActive(true);
            StateNameController.CurrentActivePanel = _case1HistoryFirstPanel;

            // _case1History.GetComponentInChildren<GameObject>()
        }
        else
        {
            _case1History.SetActive(false);
            _case1Counseling.SetActive(false);
            _case2History.SetActive(true);
            _case2Counseling.SetActive(false);
            _case2HistoryFirstPanel.SetActive(true);
            StateNameController.CurrentActivePanel = _case2HistoryFirstPanel;
        }
    }
    
    // OnClick() event for quit button
    public void QuitApp()
    {
        Application.Quit();
    }
    
    
}
