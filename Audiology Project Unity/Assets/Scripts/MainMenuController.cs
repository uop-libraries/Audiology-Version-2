using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
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
