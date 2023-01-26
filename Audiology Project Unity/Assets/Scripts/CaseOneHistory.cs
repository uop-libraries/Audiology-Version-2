using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CaseOneHistory : MonoBehaviour
{
    private GameObject _currentPanel;
    private GameObject _nextInstruction;
    private GameObject _nextFeedback;
    
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
    [SerializeField] private GameObject _Feedback05;
    [SerializeField] private GameObject _Feedback06;
    [SerializeField] private GameObject _Feedback07;
    
    [Header("Array")]
    [SerializeField] List<GameObject> _instructionPanels = new List<GameObject>();
    [SerializeField] List<GameObject> _feedbackPanels = new List<GameObject>();
    
    // Environment
    private GameObject _currentGameObject;
    private GameObject _DocImage;
    private GameObject _background;
    private GameObject _case1Object;

    private int _counter = 0;
    void Start()
    {
        // _currentCaseInstruction.SetActive(true);
        // _nextCaseInstruction.SetActive(false);
        // _feedbackInstruction.SetActive(false);
        
        _instructionPanels.Clear();
        _feedbackPanels.Clear();
        
        _DocImage = GameObject.Find("DocImage");
        _background = GameObject.Find("MainBackground");
        InitializeArrays();
        
    }

    private void InitializeArrays()
    {
        _instructionPanels.Add(_Instruction01);
        _instructionPanels.Add(_Instruction02);
        _instructionPanels.Add(_Instruction03);
        _instructionPanels.Add(_Instruction04);
        _instructionPanels.Add(_Instruction05);
        _instructionPanels.Add(_Instruction06);
        _instructionPanels.Add(_Instruction07);
        _instructionPanels.Add(_Instruction08);
        _instructionPanels.Add(_Instruction09);
        _instructionPanels.Add(_Instruction10);
        _instructionPanels.Add(_Instruction11);
        _instructionPanels.Add(_Instruction12);
        _instructionPanels.Add(_Instruction13);
        _instructionPanels.Add(_Instruction14);
        _instructionPanels.Add(_Instruction15);
        
        _feedbackPanels.Add(_Feedback01);
        _feedbackPanels.Add(_Feedback02);
        _feedbackPanels.Add(_Feedback03);
        _feedbackPanels.Add(_Feedback04);
        _feedbackPanels.Add(_Feedback05);
        _feedbackPanels.Add(_Feedback06);
        _feedbackPanels.Add(_Feedback07);
    }

    public void GoToInstruction01()
    {
        Debug.Log("First Instruction Panel");
        _nextInstruction = _Instruction01;
        SwitchPanel( _nextInstruction, _nextFeedback);
    }

    private void SwitchPanel(GameObject next, GameObject feedback)
    {
        StateNameController.CurrentActivePanel.SetActive(false);
        StateNameController.CurrentActivePanel = next;
        StateNameController.CurrentActivePanel.SetActive(true);
    }
    public void GoToInstruction02()
    {
        _nextInstruction = _Instruction02;
        _nextFeedback = _Feedback01;
        GameObject child = _nextInstruction.transform.GetChild(1).gameObject;
        GameObject option2 = child.transform.GetChild(1).gameObject;
        GameObject next = child.transform.GetChild(2).gameObject;
        
        option2.SetActive(_counter != 0);
        next.SetActive(_counter > 1);
        
        _counter++;
        SwitchPanel(_nextInstruction, _nextFeedback);
        ReturnToBackgroundObjects();
    }
    
    public void GoToInstruction03()
    {
        _nextInstruction = _Instruction03;
        _nextFeedback = _Feedback02;
        SwitchPanel(_nextInstruction, _nextFeedback);
        ReturnToBackgroundObjects();
    }

    public void GoToFeedBack01()
    {
        StateNameController.CurrentActivePanel.SetActive(false);
        StateNameController.CurrentActivePanel = _Feedback01;
        StateNameController.CurrentActivePanel.SetActive(true);
    }

    public void VideoTransition()
    {
        StateNameController.CurrentActivePanel.SetActive(false);
        _DocImage.SetActive(false);
        _background.SetActive(false);
    }

    public void ReturnToGameFromFeedback()
    {
        // _feedbackInstruction.SetActive(false);
        // _nextCaseInstruction.SetActive(true);
        // _currentGameObject = _nextCaseInstruction.GameObject();
    }

    public void ReturnToBackgroundObjects()
    {
        _DocImage?.SetActive(true);
        _background?.SetActive(true);
    }
}
