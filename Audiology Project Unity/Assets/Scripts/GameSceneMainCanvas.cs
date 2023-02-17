using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneMainCanvas : MonoBehaviour
{
    // GameObject
    [SerializeField] private GameObject _case1History;
    [SerializeField] private GameObject _case1Counseling;
    [SerializeField] private GameObject _case2History;
    [SerializeField] private GameObject _case2Counseling;

    private GameObject _currentChildCaseScenario;
    private void Start()
    {   
        //Todo change this back after debug
        // StateNameController.SetClinicalCaseNumber(2);
        
        StateNameController.SetIsGameStarted(false);
        //Todo change this back after debug
        ChangeClinicalCase();
    }

    private void ChangeClinicalCase()
    {
        _case1History.SetActive(false);
        _case1Counseling.SetActive(false);
        _case2History.SetActive(false);
        _case2Counseling.SetActive(false);

        if (StateNameController.GetClinicalCaseNumber() == 1)
        {
            _case1History.SetActive(true);
        }
        else if (StateNameController.GetClinicalCaseNumber() == 2)
        {
            _case2History.SetActive(true);
        }
        else if (StateNameController.GetClinicalCaseNumber() == 3)
        {
            _case1Counseling.SetActive(true);
        }
        else if (StateNameController.GetClinicalCaseNumber() == 4)
        {
            _case2Counseling.SetActive(true);
        }
        Debug.Log("Current case Number: " + StateNameController.GetClinicalCaseNumber());
        StateNameController.SetIsGameStarted(true); 
    }
    
    // OnClick() event for quit button
    public void QuitApp()
    {
        Application.Quit();
    }
    
    public void LoadScene(int scene)
    {
        // scene 0 is Title screen
        // scene 1 is Main Menu
        // scene 2 is Game scene
        SceneManager.LoadScene(scene);
    }
}
