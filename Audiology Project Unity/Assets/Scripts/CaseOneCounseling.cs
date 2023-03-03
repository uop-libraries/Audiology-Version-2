using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CaseOneCounseling : MonoBehaviour
{
    private GameObject _nextNarration;
    private GameObject _nextInstruction;
    private GameObject _nextFeedback;
    private GameObject _nextTopic;
    private GameObject _nextExplanation;
    
    [Header("Narrator Panel")]
    [SerializeField] private GameObject _C1C_Narrator_01;
    [SerializeField] private GameObject _C1C_Narrator_02;
    [SerializeField] private GameObject _C1C_Narrator_03;
    
    [Header("Instruction Panel")]
    [SerializeField] private GameObject _C1C_Instruction_01;
    [SerializeField] private GameObject _C1C_Instruction_02;
    [SerializeField] private GameObject _C1C_Instruction_03;
    [SerializeField] private GameObject _C1C_Instruction_04;
    [SerializeField] private GameObject _C1C_Instruction_05;
    [SerializeField] private GameObject _C1C_Instruction_06;
    [SerializeField] private GameObject _C1C_Instruction_07;
    [SerializeField] private GameObject _C1C_Instruction_08;
    [SerializeField] private GameObject _C1C_Instruction_09;
    [SerializeField] private GameObject _C1C_Instruction_10;
    [SerializeField] private GameObject _C1C_Instruction_11;
    [SerializeField] private GameObject _C1C_Instruction_12;
    
    [Header("Feedback Panel")]
    [SerializeField] private GameObject _C1C_Feedback_01;
    [SerializeField] private GameObject _C1C_Feedback_02;
    [SerializeField] private GameObject _C1C_Feedback_03;
    [SerializeField] private GameObject _C1C_Feedback_04;
    [SerializeField] private GameObject _C1C_Feedback_05;
    [SerializeField] private GameObject _C1C_Feedback_06;
    [SerializeField] private GameObject _C1C_Feedback_07;
    [SerializeField] private GameObject _C1C_Feedback_08;
    
    [Header("Topic Panel")]
    [SerializeField] private GameObject _C1C_Topic_01_1;
    [SerializeField] private GameObject _C1C_Topic_01_2;
    [SerializeField] private GameObject _C1C_Topic_02;
    [SerializeField] private GameObject _C1C_Topic_03;
    [SerializeField] private GameObject _C1C_Topic_04;
    [SerializeField] private GameObject _C1C_Topic_05_1;
    [SerializeField] private GameObject _C1C_Topic_05_2;
    [SerializeField] private GameObject _C1C_Topic_05_3;
    [SerializeField] private GameObject _C1C_Topic_05_4;

    [Header("Explanation Panel")]
    [SerializeField] private GameObject _C1C_Explanation_01_1;
    [SerializeField] private GameObject _C1C_Explanation_01_2;
    [SerializeField] private GameObject _C1C_Explanation_01_3;
    [SerializeField] private GameObject _C1C_Explanation_02_1;
    [SerializeField] private GameObject _C1C_Explanation_02_2;
    [SerializeField] private GameObject _C1C_Explanation_02_3;
    
    [Header("AudioSource")] 
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clipC1CNarration01;
    [SerializeField] private AudioClip clipC1CNarration02;
    [SerializeField] private AudioClip clipC1CNarration03;

    public void StartCase1Counseling()
    {
        InitializePanel();
    }
    
    private void InitializePanel()
    {
        // Initial first panel so it is not null
        StateNameController.CurrentActivePanel = _C1C_Narrator_01;
        
        var currentPanel = "Case1_counseling";
        var parent = GameObject.Find(currentPanel);
        
        Debug.Log("parent: " + parent);
        
        Debug.Log("parent: " + parent);
        
        // make all child object inactive
        foreach (Transform child in parent.transform)
        {
            child.gameObject.SetActive(false);
        }
        
        GoToNarratorPanel(1);
    }
    
    public void GoToNarratorPanel(int panelNum)
    {
        AudioClip _nextClip = null;
        
        if (panelNum == 1)
        {
            _nextInstruction = _C1C_Narrator_01;
            _nextClip = clipC1CNarration01;
        }
        else if (panelNum == 2)
        {
            _nextInstruction = _C1C_Narrator_02;
            _nextClip = clipC1CNarration02;
        }
        else if (panelNum == 3)
        {
            _nextInstruction = _C1C_Narrator_03;
            _nextClip = clipC1CNarration03;
        }
        
        StateNameController.SwitchPanel(_nextInstruction);
        
        var child2 = _nextInstruction.transform.GetChild(1).gameObject;
        StartCoroutine(ActionAfterAudioStop(child2, _nextClip));
    }
    
    private IEnumerator  ActionAfterAudioStop(GameObject button, AudioClip currentClip)
    {
        if (button != null)
        {
            button.gameObject.SetActive(false);
        }
        if (currentClip != null)
        {
            audioSource.clip = currentClip;
            audioSource.Play();
        }
        
        yield return new WaitForSeconds(audioSource.clip.length);
        if (button != null)
        {
            button.gameObject.SetActive(true);
        }
    }


    

}
