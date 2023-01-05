using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
 
    Animator animator;

    void Start()
    {
      
        animator = GetComponent<Animator>();
    }
 
    public void OnPointerEnter()
    {
       
        animator.SetTrigger("Solid");
    }

 
    public void OnPointerExit()
    {
    
        animator.SetTrigger("Flash");
    }

    
    public void OnClick()
    {
        
    }
}
