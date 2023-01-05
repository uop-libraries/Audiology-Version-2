using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
     
    private Animator animator;

    
    public string correctAnimationName = "Correct";
    public string incorrectAnimationName = "Incorrect";

    
    void Start()
    {
  
        animator = GetComponent<Animator>();
    }



private bool IsAnswerCorrect()
{
    
    Vector3 gazeDirection = Gaze.Instance.GazeNormal;

    
    RaycastHit hit;
    bool answerIsCorrect = Physics.Raycast(transform.position, gazeDirection, out hit, Mathf.Infinity);

    
    if (answerIsCorrect)
    {
        if (hit.collider.tag == "CorrectAnswer")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    else
    {
        return false;
    }
}


    
    void Update()
    {
        
        bool answerIsCorrect = IsAnswerCorrect();

       
        if (answerIsCorrect)
        {
            animator.Play(correctAnimationName);
        }
        else
        {
            animator.Play(incorrectAnimationName);
        }
    }
}