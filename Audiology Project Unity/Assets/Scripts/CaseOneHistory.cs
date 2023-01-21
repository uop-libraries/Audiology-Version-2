using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CaseOneHistory : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private GameObject _currentCaseInstruction;
    [SerializeField] private GameObject _nextCaseInstruction;
    [SerializeField] private GameObject _feedbackInstruction;
    private GameObject _currentGameObject;
    private GameObject _DocImage;
    void Start()
    {
        _currentCaseInstruction.SetActive(true);
        _nextCaseInstruction.SetActive(false);
        _feedbackInstruction.SetActive(false);
        _DocImage = GameObject.Find("DocImage");

    }
    
    public void CorrectAnswer()
    {
        _currentCaseInstruction.SetActive(false);
        _nextCaseInstruction.SetActive(true);
        _currentGameObject = _nextCaseInstruction.GameObject();
    }
    
    public void WrongAnswer()
    {
        _currentCaseInstruction.SetActive(false);
        _feedbackInstruction.SetActive(true);
        _currentGameObject = _feedbackInstruction.GameObject();
    }

    public void VideoTransition()
    {
        _currentGameObject.SetActive(false);
        _DocImage.SetActive(false);
    }

    public void ReturnToGame()
    {
        _currentGameObject.SetActive(true);
        _DocImage.SetActive(true);
    }
}
