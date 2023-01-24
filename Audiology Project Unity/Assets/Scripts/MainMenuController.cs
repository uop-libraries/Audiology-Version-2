using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void LoadClinicalCase(int caseNumber)
    {
        StateNameController.clinicalCaseNumber = caseNumber;
    }
    
    public void QuitApp()
    {
        Application.Quit();
    }
}
