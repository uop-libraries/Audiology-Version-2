using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    // Environment GameObject
    private static List<GameObject> _docImagesList = new List<GameObject>();
    private static List<GameObject> _backgroundList = new List<GameObject>();
    private static GameObject _background;
    
    // Start is called before the first frame update
    void Start()
    {
        InitializeBackground();
        // Set Initial Doctor images
        InitializeDocImages();
    }

    private static void InitializeBackground()
    {
        _background = GameObject.Find("Background");
        
        _backgroundList.Add(_background.transform.GetChild(0).gameObject);
        _backgroundList.Add(_background.transform.GetChild(1).gameObject);
        _backgroundList.Add(_background.transform.GetChild(2).gameObject);
    }

    public static void DeactivateBackground()
    {
        foreach (GameObject bg in _backgroundList)
        {
            bg.gameObject.SetActive(false);
        }
    }

    public static List<GameObject> GetBackground()
    {
        return _backgroundList;
    }

    public static void ActivateBackground(bool value)
    {
        _background.SetActive(value);
    }

    private static void InitializeDocImages()
    {
        var docImage1 = GameObject.Find("DocImage1");
        var docImage2 = GameObject.Find("DocImage2");
        var docImage3 = GameObject.Find("DocImage3");
        var docImage4 = GameObject.Find("DocImage4");
        
        _docImagesList.Add(docImage1);
        _docImagesList.Add(docImage2);
        _docImagesList.Add(docImage3);
        _docImagesList.Add(docImage4);
        
        DeactivateDocImages();
        
        _docImagesList[3].gameObject.SetActive(true);
    }
    
    public static void DeactivateDocImages()
    {
        foreach (var images in _docImagesList)
        {
            images.gameObject.SetActive(false);
        }
    }

    public static List<GameObject> GetDocImages()
    {
        return _docImagesList;
    }
    
    
     // Set all UI and background images inactive
     public void SetBackgroundToInactive() {
        StateNameController.CurrentActivePanel.SetActive(false);
        DeactivateDocImages();
        ActivateBackground(false);
    }
}
