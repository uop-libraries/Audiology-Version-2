using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CaseOneHistory : MonoBehaviour
{
    private GameObject _currentPanel;
    private GameObject _nextInstruction;
    private GameObject _nextfeedback;
    
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
    
    // Environment
    private GameObject _currentGameObject;
    private GameObject _DocImage;
    private GameObject _background;
    void Start()
    {
        // _currentCaseInstruction.SetActive(true);
        // _nextCaseInstruction.SetActive(false);
        // _feedbackInstruction.SetActive(false);
        _DocImage = GameObject.Find("DocImage");
        _background = GameObject.Find("MainBackground");

    }
    
    public void CorrectAnswer()
    {
        // _currentCaseInstruction.SetActive(false);
        // _nextCaseInstruction.SetActive(true);
        // _currentGameObject = _nextCaseInstruction.GameObject();
    }
    
    public void WrongAnswer()
    {
        // _currentCaseInstruction.SetActive(false);
        // _feedbackInstruction.SetActive(true);
        // _currentGameObject = _feedbackInstruction.GameObject();
    }

    public void VideoTransition()
    {
        _currentGameObject.SetActive(false);
        _DocImage.SetActive(false);
        _background.SetActive(false);
    }

    public void ReturnToGameFromFeedback()
    {
        // _feedbackInstruction.SetActive(false);
        // _nextCaseInstruction.SetActive(true);
        // _currentGameObject = _nextCaseInstruction.GameObject();
    }

    public void ReturnToGame()
    {
        _currentGameObject.SetActive(true);
        _DocImage.SetActive(true);
        _background.SetActive(true);
    }
}
