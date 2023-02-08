using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
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
    [SerializeField] private GameObject _Feedback04_1;
    [SerializeField] private GameObject _Feedback05;
    [SerializeField] private GameObject _Feedback06;
    [SerializeField] private GameObject _Feedback07;
    
    [Header("AudioSource")] 
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clipCase1HistoryNarrator;
    [SerializeField] private AudioClip clipCase1HistoryInstruction1;
    
    private List<GameObject> _docImages = new List<GameObject>();
    
    // Environment
    private GameObject _currentGameObject;
    private GameObject _docInstructionImage;
    private GameObject _background;
    private GameObject _case1Object;
    
    private int _counter;
    private int _nextPanel;
    private bool _isFirstTime = true;
    private bool _isFirstTime1 = true;
    private bool _firstPanel = true;

    void Start()
    {
        _counter = 0;
        _nextPanel = 0;
        InitializeDocImage();
        // _docInstructionImage = GameObject.Find("DocImage1");
        _background = GameObject.Find("Background");

        if (!_firstPanel) return;
        GoToNarrator();
    }
    
    private void InitializeDocImage()
    {
        var docImage1 = GameObject.Find("DocImage1");
        var docImage2 = GameObject.Find("DocImage2");
        var docImage3 = GameObject.Find("DocImage3");
        var docImage4 = GameObject.Find("DocImage4");
        
        _docImages.Add(docImage1);
        _docImages.Add(docImage2);
        _docImages.Add(docImage3);
        _docImages.Add(docImage4);
        
        RemoveDocImages();
        
        // Set Initial Doctor images
        _docImages[3].gameObject.SetActive(true);
    }

    private void RemoveDocImages()
    {
        foreach (var images in _docImages)
        {
            images.gameObject.SetActive(false);
        }
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
    
    private void GoToNarrator()
    {
        _nextInstruction = Narrator01;
        GameObject child2 = _nextInstruction.transform.GetChild(1).gameObject;
        
        child2.gameObject.SetActive(false);
        StartCoroutine(ActionAfterAudioStop(child2, clipCase1HistoryNarrator));
    }
     
    private IEnumerator  ActionAfterAudioStop(GameObject obj, AudioClip currentClip)
    {
        audioSource.clip = currentClip;
        audioSource.Play();

        yield return new WaitForSeconds(audioSource.clip.length);
        if (obj != null)
        {
            obj.gameObject.SetActive(true);
        }
    }
    
    public void GoToInstruction(int instructNumber)
    {
        Debug.Log("Instruction Panel: " + instructNumber);
        switch(instructNumber)
        {
            case 1:
                _nextInstruction = _Instruction01;
                StartCoroutine(ActionAfterAudioStop(null, clipCase1HistoryInstruction1));
                break;
            case 2:
                _nextInstruction = _Instruction02;
                GoToInstructionNumber(instructNumber);
                break;
            case 3:
                _nextInstruction = _Instruction03;
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
                GoToInstructionNumber(instructNumber);
                break;
            case 13:
                _nextInstruction = _Instruction13;
                GoToInstructionNumber(instructNumber);
                break;
            case 14:
                _nextInstruction = _Instruction14;
                GoToInstructionNumber(instructNumber);
                break;
            case 15:
                _nextInstruction = _Instruction15;
                GoToInstructionNumber(instructNumber);
                break;
        }
        SwitchPanel(_nextInstruction);
        ReturnToBackgroundObjects();
        ChangeFeedbackBackground(false);
    }
    
    public void GoToFeedBack(int value)
    {
        _nextFeedback = value switch
        {
            1 => _Feedback01,
            2 => _Feedback02,
            3 => _Feedback03,
            4 => _Feedback04,
            5 => _Feedback04_1,
            6 => _Feedback05,
            7 => _Feedback06,
            8 => _Feedback07,
            _ => _nextFeedback
        };
        ChangeFeedbackBackground(true);
        SwitchPanel(_nextFeedback);
    }

    private void SwitchPanel(GameObject next)
    {
        StateNameController.currentActivePanel.SetActive(false);
        StateNameController.currentActivePanel = next;
        StateNameController.currentActivePanel.SetActive(true);
    }
    
    // Instruction for hearing abilities option
    private void GoToInstruction08()
    {
        _counter = 0;
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
                    _counter++;
                }
            }

            switch (_counter)
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
        _counter = 0;
    }
    
    // Instruction for vertigo option
     private void GoToInstruction09()
    {
        _counter = 0;
        _nextInstruction = _Instruction09;
        var child1 = _nextInstruction.transform.GetChild(1).gameObject;
        var child2 = _nextInstruction.transform.GetChild(2).gameObject;
        
        //Todo Debug
        child2.SetActive(false);
        //Todo Debug
        
        if (_isFirstTime1)
        {
            foreach (Transform child in child1.transform)
            {
                child.gameObject.SetActive(false);
            }
        }

        _isFirstTime1 = false;

        foreach (Transform child in child1.transform)
        {
            if (child.gameObject.GetComponent<Image>().color == Color.grey)
            {
                child.gameObject.SetActive(false);
                if (child.gameObject.activeSelf == false)
                {
                    _counter++;
                }
            }
            
            switch (_counter)
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
                case 7:
                    child2.SetActive(true);
                    _isFirstTime1 = true;
                    break;
            }
        }
        _counter = 0;
    }

     private void GoToInstructionNumber(int instructionNumber)
     {
         _counter = 0;
         var child1 = _nextInstruction.transform.GetChild(1).gameObject;
         var child2 = _nextInstruction.transform.GetChild(2).gameObject;
        
         //Todo Debug
         child2.SetActive(false);
         //Todo Debug
        
         foreach (Transform child in child1.transform)
         {
             if (child.gameObject.GetComponent<Image>().color == Color.grey)
             {
                 if (instructionNumber == 7)
                 {
                     child.gameObject.SetActive(false);
                 }

                 _counter++;
                 // if (child.gameObject.activeSelf == false)
                 // {
                 //     _counter++;
                 // }
             }
         }
         
         if (_counter == 2 && instructionNumber == 2 ||
             _counter == 1 && instructionNumber == 4 ||
             _counter == 6 && instructionNumber == 6 ||
             _counter == 7 && instructionNumber == 7 ||
             _counter == 3 && instructionNumber == 10 ||
             _counter == 2 && instructionNumber == 11 || 
             _counter == 1 && instructionNumber == 12 ||
             _counter == 1 && instructionNumber == 13 ||
             _counter == 1 && instructionNumber == 14)
         {
             child2.SetActive(true);
         }
     }
     
    public void ReturnToFromVideo()
    {
        if (StateNameController.currentActivePanel == _Instruction02)
        {
            GoToInstruction(2);
        }
        else if (StateNameController.currentActivePanel == _Instruction04)
        {
            GoToInstruction(4);
        }
        else if (StateNameController.currentActivePanel == _Instruction06)
        {
            GoToInstruction(6);
        }
        else if (StateNameController.currentActivePanel == _Instruction08)
        {
            GoToInstruction(8);
        }
        else if (StateNameController.currentActivePanel == _Instruction09)
        {
            GoToInstruction(9);
        }
        else if (StateNameController.currentActivePanel == _Instruction10)
        {
            GoToInstruction(10);
        }
        else if (StateNameController.currentActivePanel == _Instruction11)
        {
            GoToInstruction(11);
        }
        else if (StateNameController.currentActivePanel == _Instruction12)
        {
            GoToInstruction(12);
        }
        else if (StateNameController.currentActivePanel == _Instruction13)
        {
            GoToInstruction(13);
        }
        else if (StateNameController.currentActivePanel == _Instruction14)
        {
            GoToInstruction(14);
        }
    }

    public void ChangeFeedbackBackground(bool isFeedback)
    {
        var child0 = _background.transform.GetChild(0).gameObject;
        var child1 = _background.transform.GetChild(1).gameObject;
        var child2 = _background.transform.GetChild(2).gameObject;
        
        foreach (Transform child in _background.transform)
        {
            if (child.gameObject.activeSelf)
            {
                child.gameObject.SetActive(false);
            }
        }
        
        RemoveDocImages();

        if (isFeedback)
        {
            if (_nextFeedback != _Feedback04 && _nextFeedback != _Feedback04_1)
            {
                child1.gameObject.SetActive(true);
                _docImages[1].gameObject.SetActive(true);
            }
            else
            {
                child2.gameObject.SetActive(true);
                _docImages[2].gameObject.SetActive(true);
            }
        }
        else
        {
            child0.gameObject.SetActive(true);
            _docImages[0].gameObject.SetActive(true);
        }
    }
    
    public void ReturnToBackgroundObjects()
    {
        _docInstructionImage?.SetActive(true);
        _background?.SetActive(true);
    }
    
    public void VideoTransition()
    {
        StateNameController.currentActivePanel.SetActive(false);
        RemoveDocImages();
        _background.SetActive(false);
    }
}
