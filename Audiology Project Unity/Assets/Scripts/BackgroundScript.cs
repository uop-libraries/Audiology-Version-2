using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour {
    // Environment GameObject
    static List<GameObject> _docImagesList = new List<GameObject>();
    static List<GameObject> _backgroundList = new List<GameObject>();
    static List<GameObject> _diagramList = new List<GameObject>();
    // [SerializeField] GameObject _docImagesObject;
    // [SerializeField] GameObject _backgroundObject;
    // [SerializeField] GameObject _diagramObject;
    [SerializeField] static GameObject _background;
    static BackgroundScript instance;
    

    // Start is called before the first frame update
    public void BackgroundScriptStart() {
        InitializeDiagram();
        InitializeBackground();
        // Set Initial Doctor images
        InitializeDocImages();
        
    }
    public static void InitializeBackground() {
        _background = GameObject.Find("Background");
        
        // child 0 is blue background
        // child 1 is red background
        // child 2 is green background
        foreach (Transform child in _background.transform) {    
            _backgroundList.Add(child.gameObject);
            // Debug.Log("background is: " + child.gameObject);
        }
        // foreach (Transform child in _backgroundObject.transform) {    
        //     _backgroundList.Add(child.gameObject);
        //     Debug.Log("background is: " + child.gameObject);
        // }
    }

    public static void DeactivateBackground() {
        if (_backgroundList[0] == null) {
            Debug.Log("background is null");
            InitializeBackground();
        }
        foreach (GameObject bg in _backgroundList) {
            bg.gameObject.SetActive(false);
        }
    }

    public static List<GameObject> GetBackground() {
        return _backgroundList;
    }
    
    public static void ActivateBackground(bool value) {
        _background.SetActive(value);
    }

    private static void InitializeDocImages() {
        // Doc Images is not in their own parent object due to the order of layer placement
        var _docImages = GameObject.Find("DocImages");

        foreach (Transform child in _docImages.transform) {    
            _docImagesList.Add(child.gameObject);
        }
    
        DeactivateDocImages();
    
        _docImagesList[3].gameObject.SetActive(true);
    }

    public static void DeactivateDocImages() {
    
        foreach (var images in _docImagesList) {
            images.gameObject.SetActive(false);
        }
    }
    
    public static List<GameObject> GetDocImages() {
        return _docImagesList;
    }
    
    public static void InitializeDiagram() {
        var diagram = GameObject.Find("Diagram");
        
        // Child 0 is Diagram Case 1
        // Child 0 is Diagram Case 2
        foreach (Transform child in diagram.transform) {    
            _diagramList.Add(child.gameObject);
        }
    }
    
    public static void DeactivateDiagram() {
        foreach (var diagram in _diagramList) {
            diagram.gameObject.SetActive(false);
        }
    }
    
    public static List<GameObject> GetDiagram() {
        return _diagramList;
    }
    
    
    // Set all UI and background images inactive
    public void SetBackgroundToInactive() {
        StateNameController.CurrentActivePanel.SetActive(false);
        DeactivateDocImages();
        DeactivateDiagram();
        ActivateBackground(false);
    }
}