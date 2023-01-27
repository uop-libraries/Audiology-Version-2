using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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
    private GameObject _docImage;
    private GameObject _background;
    private GameObject _case1Object;

    private int _counter = 0;
    private int _counter1 = 0;

    void Start()
    {
        _instructionPanels.Clear();
        _feedbackPanels.Clear();
        
        _docImage = GameObject.Find("DocImage");
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

    public void GoToInstruction(int index)
    {
        Debug.Log("Instruction Panel: " + index);
        switch(index)
        {
            case 1:
                _nextInstruction = _Instruction01;
                break;
            case 2:
                GoToInstruction02();
                break;
            case 3:
                _nextInstruction = _Instruction03;
                _counter = 0;
                break;
            case 4:
                GoToInstruction04();
                break;
            case 5:
                _nextInstruction = _Instruction05;
                break;
            case 6:
                GoToInstruction06();
                break;
            case 7:
                _nextInstruction = _Instruction07;
                break;
            case 8:
                _nextInstruction = _Instruction08;
                break;
            case 9:
                _nextInstruction = _Instruction09;
                break;
            case 10:
                _nextInstruction = _Instruction10;
                break;
            case 11:
                _nextInstruction = _Instruction11;
                break;
            case 12:
                _nextInstruction = _Instruction12;
                break;
            case 13:
                _nextInstruction = _Instruction13;
                break;
            case 14:
                _nextInstruction = _Instruction14;
                break;
            case 15:
                _nextInstruction = _Instruction15;
                break;
        }
        SwitchPanel( _nextInstruction);
        ReturnToBackgroundObjects();
    }
    
    public void GoToFeedBack(int value)
    {
        StateNameController.CurrentActivePanel.SetActive(false);
        
        StateNameController.CurrentActivePanel = value switch
        {
            1 => _Feedback01,
            2 => _Feedback02,
            3 => _Feedback03,
            4 => _Feedback04,
            5 => _Feedback05,
            6 => _Feedback06,
            7 => _Feedback07,
            _ => StateNameController.CurrentActivePanel
        };
        
        StateNameController.CurrentActivePanel.SetActive(true);
    }

    private void SwitchPanel(GameObject next)
    {
        StateNameController.CurrentActivePanel.SetActive(false);
        StateNameController.CurrentActivePanel = next;
        StateNameController.CurrentActivePanel.SetActive(true);
    }
    private void GoToInstruction02()
    {
        _nextInstruction = _Instruction02;
        GameObject child = _nextInstruction.transform.GetChild(1).gameObject;
        GameObject option2 = child.transform.GetChild(1).gameObject;
        GameObject next = child.transform.GetChild(2).gameObject;
        
        option2.SetActive(_counter != 0);
        next.SetActive(_counter > 1);
        
        _counter++;
    }
    
    private void GoToInstruction04()
    {
        _nextInstruction = _Instruction04;
        GameObject child = _nextInstruction.transform.GetChild(1).gameObject;
        GameObject next = child.transform.GetChild(1).gameObject;
        
        next.SetActive(_counter > 0);
        _counter++;
    }
    
    private void GoToInstruction06()
    {
        _counter1 = 0;
        _nextInstruction = _Instruction06;
        GameObject child1 = _nextInstruction.transform.GetChild(1).gameObject;
        
        GameObject child2 = _nextInstruction.transform.GetChild(2).gameObject;
        
        //Todo Debug
        // child2.SetActive(false);
        //Todo Debug
        
        foreach (Transform child in child1.transform)
        {
            // Debug.Log(child);
            if (child.gameObject.GetComponent<Image>().color == Color.grey)
            {
                _counter1++;
                Debug.Log(child + " " + " counter:" + _counter1);
            }
            else
            {
                _counter = 0;
            }
        }

        if (_counter1 == 6)
        {
            child2.SetActive(true);
        }
    }
    
    private void GoToInstruction08()
    {
        _counter1 = 0;
        _nextInstruction = _Instruction08;
        GameObject child1 = _nextInstruction.transform.GetChild(1).gameObject;
        
        GameObject child2 = _nextInstruction.transform.GetChild(2).gameObject;
        
        //Todo Debug
        child2.SetActive(false);
        //Todo Debug
        
        foreach (Transform child in child1.transform)
        {
            // Debug.Log(child);
            child.gameObject.SetActive(false);
            // if (child.gameObject.GetComponent<Image>().color == Color.grey)
            
            // if (child.gameObject.GetComponent<Image>().color == Color.grey)
            // {
            //     _counter1++;
            //     Debug.Log(child + " " + " counter:" + _counter1);
            // }
            // else
            // {
            //     _counter = 0;
            // }
        }

        if (_counter1 == 6)
        {
            child2.SetActive(true);
        }
    }
    
    public void VideoTransition()
    {
        StateNameController.CurrentActivePanel.SetActive(false);
        _docImage.SetActive(false);
        _background.SetActive(false);
    }

    public void ReturnToFromVideo()
    {
        if (StateNameController.CurrentActivePanel == _Instruction02)
        {
            GoToInstruction(2);
        }
        else if (StateNameController.CurrentActivePanel == _Instruction04)
        {
            GoToInstruction(4);
        }
        else if (StateNameController.CurrentActivePanel == _Instruction06)
        {
            GoToInstruction(6);
        }
    }

    public void ReturnToBackgroundObjects()
    {
        _docImage?.SetActive(true);
        _background?.SetActive(true);
    }
}
