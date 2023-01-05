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
        // Get the animator component
        animator = GetComponent<Animator>();
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