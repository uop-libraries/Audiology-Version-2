using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneButtons : MonoBehaviour
{
    
    public Button volumeButton;

   
    public Button exitButton;

   
    public GameObject volumeSlider;

    void Start()
    {
      
        volumeButton.onClick.AddListener(OnVolumeButtonClicked);

     
        exitButton.onClick.AddListener(OnExitButtonClicked);
    }

   
    public void OnVolumeButtonClicked()
    {
        
        volumeSlider.SetActive(!volumeSlider.activeSelf);
    }

     
   public void OnExitButtonClicked()
    {
        
        Application.Quit();
    }
}
