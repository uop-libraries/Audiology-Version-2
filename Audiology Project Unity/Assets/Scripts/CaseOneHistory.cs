using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    private int _nextPanel = 0;
    private bool _isFirstTime = true;

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

    private void Update()
    {
        // Todo Disable after testing
        if (Input.GetKeyDown(KeyCode.N))
        {
            _nextPanel++;
            GoToInstruction(_nextPanel);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            _nextPanel--;
            GoToInstruction(_nextPanel);
        }
    }


    public void GoToInstruction(int instructNumber)
    {
        Debug.Log("Instruction Panel: " + instructNumber);
        switch(instructNumber)
        {
            case 1:
                _nextInstruction = _Instruction01;
                break;
            case 2:
                _nextInstruction = _Instruction02;
                GoToInstructionNumber(instructNumber);
                break;
            case 3:
                _nextInstruction = _Instruction03;
                _counter = 0;
                break;
            case 4:
                _nextInstruction = _Instruction04;
                GoToInstructionNumber(instructNumber);
                break;
            case 5:
                _nextInstruction = _Instruction05;
                break;
            case 6:
                _nextInstruction = _Instruction06;
                GoToInstructionNumber(instructNumber);
                break;
            case 7:
                _nextInstruction = _Instruction07;
                GoToInstructionNumber(instructNumber);
                break;
            case 8:
                GoToInstruction08();
                break;
            case 9:
                GoToInstruction09();
                break;
            case 10:
                _nextInstruction = _Instruction10;
                GoToInstructionNumber(instructNumber);
                break;
            case 11:
                _nextInstruction = _Instruction11;
                GoToInstructionNumber(instructNumber);
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
        SwitchPanel(_nextInstruction);
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

    // Instruction for hearing abilities option
    private void GoToInstruction08()
    {
        _counter1 = 0;
        _nextInstruction = _Instruction08;
        var child1 = _nextInstruction.transform.GetChild(1).gameObject;
        
        var child2 = _nextInstruction.transform.GetChild(2).gameObject;
        
        //Todo Debug
        child2.SetActive(false);
        //Todo Debug

        if (_isFirstTime)
        {
            foreach (Transform child in child1.transform)
            {
                child.gameObject.SetActive(false);
            }
        }

        _isFirstTime = false;

        foreach (Transform child in child1.transform)
        {
            if (child.gameObject.name is "Option_A" or "Option_B" or "Option_C")
            {
                child.gameObject.SetActive(true);
            }
            
            if (child.gameObject.GetComponent<Image>().color == Color.grey)
            {
                child.gameObject.SetActive(false);
                if (child.gameObject.activeSelf == false)
                {
                    _counter1++;
                }
            }

            switch (_counter1)
            {
                case 1:
                {
                    if (child.gameObject.name == "Option_D")
                    {
                        child.gameObject.SetActive(true);
                    }

                    break;
                }
                case 2:
                {
                    if (child.gameObject.name == "Option_E")
                    {
                        child.gameObject.SetActive(true);
                    }

                    break;
                }
                case 3:
                {
                    if (child.gameObject.name == "Option_F")
                    {
                        child.gameObject.SetActive(true);
                    }

                    break;
                }
                case 4:
                {
                    if (child.gameObject.name == "Option_G")
                    {
                        child.gameObject.SetActive(true);
                    }

                    break;
                }
                case 7:
                    child2.SetActive(true);
                    _isFirstTime = true;
                    break;
            }
        }
        _counter1 = 0;
    }
    
    // Instruction for vertigo option
     private void GoToInstruction09()
    {
        _counter1 = 0;
        _nextInstruction = _Instruction09;
        var child1 = _nextInstruction.transform.GetChild(1).gameObject;
        var child2 = _nextInstruction.transform.GetChild(2).gameObject;
        
        //Todo Debug
        child2.SetActive(false);
        //Todo Debug

        if (_isFirstTime)
        {
            foreach (Transform child in child1.transform)
            {
                child.gameObject.SetActive(false);
            }
        }

        _isFirstTime = false;

        foreach (Transform child in child1.transform)
        {
            
            switch (_counter1)
            {
                case 0:
                {
                    if (child.gameObject.name == "Option_A")
                    {
                        child.gameObject.SetActive(true);
                    }
                    break;
                }
                case 1:
                {
                    if (child.gameObject.name == "Option_B")
                    {
                        child.gameObject.SetActive(true);
                    }

                    break;
                }
                case 2:
                {
                    if (child.gameObject.name is "Option_C" or "Option_D" or "Option_E")
                    {
                        child.gameObject.SetActive(true);
                    }

                    break;
                }
                case 3:
                {
                    if (child.gameObject.name == "Option_F")
                    {
                        child.gameObject.SetActive(true);
                    }

                    break;
                }
                case 4:
                {
                    if (child.gameObject.name == "Option_G")
                    {
                        child.gameObject.SetActive(true);
                    }

                    break;
                }
                case 6:
                    child2.SetActive(true);
                    _isFirstTime = true;
                    break;
            }
            
            if (child.gameObject.GetComponent<Image>().color == Color.grey)
            {
                child.gameObject.SetActive(false);
                if (child.gameObject.activeSelf == false)
                {
                    _counter1++;
                }
            }
        }
        _counter1 = 0;
    }

     private void GoToInstructionNumber(int instructionNumber)
     {
         _counter1 = 0;
         var child1 = _nextInstruction.transform.GetChild(1).gameObject;
         var child2 = _nextInstruction.transform.GetChild(2).gameObject;
        
         //Todo Debug
         child2.SetActive(false);
         //Todo Debug
        
         foreach (Transform child in child1.transform)
         {
             if (child.gameObject.GetComponent<Image>().color == Color.grey)
             {
                 child.gameObject.SetActive(false);
                 _counter1++;
             }
             else
             {
                 _counter = 0;
             }
         }
         
         if (_counter1 == 2 && instructionNumber == 2 ||
             _counter1 == 1 && instructionNumber == 4 ||
             _counter1 == 6 && instructionNumber == 6 ||
             _counter1 == 7 && instructionNumber == 7 ||
             _counter1 == 3 && instructionNumber == 10 ||
             _counter1 == 2 && instructionNumber == 11)
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
        else if (StateNameController.CurrentActivePanel == _Instruction08)
        {
            GoToInstruction(8);
        }
        else if (StateNameController.CurrentActivePanel == _Instruction09)
        {
            GoToInstruction(9);
        }
        else if (StateNameController.CurrentActivePanel == _Instruction10)
        {
            GoToInstruction(10);
        }
        else if (StateNameController.CurrentActivePanel == _Instruction11)
        {
            GoToInstruction(11);
        }
    }

    public void ReturnToBackgroundObjects()
    {
        _docImage?.SetActive(true);
        _background?.SetActive(true);
    }
}
