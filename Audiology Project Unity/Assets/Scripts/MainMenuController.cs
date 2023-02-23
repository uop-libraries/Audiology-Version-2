using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    private GameObject _case1CounselingObject;
    private GameObject _case2CounselingObject;

    private TextMeshProUGUI _case1CounselingText;
    private TextMeshProUGUI _case2CounselingText;

    private Animator _case1CounselingAnimator;
    private Animator _case2CounselingAnimator;

    private Button _case1CounselingButton;
    private Button _case2CounselingButton;

    // Start is called before the first frame update
    void Start()
    {
        _case1CounselingObject = GameObject.Find("Case_1_Counseling_Button");
        _case2CounselingObject = GameObject.Find("Case_2_Counseling_Button");

        if (_case1CounselingObject != null && _case2CounselingObject != null)
        {
            _case1CounselingText = _case1CounselingObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            _case2CounselingText = _case1CounselingObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();

            _case1CounselingAnimator = _case1CounselingObject.GetComponent<Animator>();
            _case2CounselingAnimator = _case2CounselingObject.GetComponent<Animator>();

            _case1CounselingButton = _case1CounselingObject.GetComponent<Button>();
            _case2CounselingButton = _case2CounselingObject.GetComponent<Button>();
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (_case1CounselingObject != null && _case2CounselingObject != null)
        {
            SetCounselingButton();
        }
    }
    
    private void SetCounselingButton()
    {
        if (!StateNameController.isCase1HistoryDone)
        {
            _case1CounselingAnimator.enabled = false;
            _case1CounselingButton.interactable = false;
            _case1CounselingText.text = "Case 1 Counseling (Lock)";
        }
        else
        {
            _case1CounselingAnimator.enabled = true;
            _case1CounselingButton.interactable = true;
            _case1CounselingText.text = "Case 1 Counseling";
        }
        
        if (!StateNameController.isCase2HistoryDone)
        {
            _case2CounselingAnimator.enabled = false;
            _case2CounselingButton.interactable = false;
            _case2CounselingText.text = "Case 2 Counseling (Lock)";
        }
        else
        {
            _case2CounselingAnimator.enabled = true;
            _case2CounselingButton.interactable = true;
            _case2CounselingText.text = "Case 2 Counseling";
        }
    }
    
    // Case 1 and 2 button used this function in OnClick() event
    public void LoadScene(int scene)
    {
        // scene 0 is Title screen
        // scene 1 is Main Menu
        // scene 2 is Game scene
        SceneManager.LoadScene(scene);
    }

    // Case 1 and 2 button used this function in OnClick() event
    public void LoadClinicalCase(int caseNumber)
    {
        // caseNumber 1 is Case 1 History
        // caseNumber 2 is Case 2 History
        // caseNumber 3 is Case 1 Counseling
        // caseNumber 4 is Case 2 Counseling
        StateNameController.clinicalCaseNumber = caseNumber;
    }
    
    // OnClick() event for quit button
    public void QuitApp()
    {
        Application.Quit();
    } 
}
