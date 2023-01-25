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
        SceneManager.LoadScene(scene);
    }

    // Case 1 and 2 button used this function in OnClick() event
    public void LoadClinicalCase(int caseNumber)
    {
        StateNameController.clinicalCaseNumber = caseNumber;
    }
    
    // OnClick() event for quit button
    public void QuitApp()
    {
        Application.Quit();
    }
}
