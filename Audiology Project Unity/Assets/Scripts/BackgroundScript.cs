using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    private static List<GameObject> _docImages = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        // Set Initial Doctor images
        InitializeDocImages();
    }

    private static void InitializeDocImages()
    {
        var docImage1 = GameObject.Find("DocImage1");
        var docImage2 = GameObject.Find("DocImage2");
        var docImage3 = GameObject.Find("DocImage3");
        var docImage4 = GameObject.Find("DocImage4");
        
        _docImages.Add(docImage1);
        _docImages.Add(docImage2);
        _docImages.Add(docImage3);
        _docImages.Add(docImage4);
        
        DeactivateDocImages();
        
        _docImages[3].gameObject.SetActive(true);
    }
    
    public static void DeactivateDocImages()
    {
        foreach (var images in _docImages)
        {
            images.gameObject.SetActive(false);
        }
    }

    public static List<GameObject> GetDocImages()
    {
        return _docImages;
    }
}
