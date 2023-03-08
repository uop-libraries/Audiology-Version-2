using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour {
    // Environment GameObject
    static List<GameObject> _docImagesList = new List<GameObject>();
    static List<GameObject> _backgroundList = new List<GameObject>();
    static List<GameObject> _diagramList = new List<GameObject>();
    static GameObject _background;

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
        }
    }

    public static void DeactivateBackground() {
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