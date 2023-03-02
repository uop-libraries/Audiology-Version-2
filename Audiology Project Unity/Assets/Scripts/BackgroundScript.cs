using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    private static List<GameObject> _docImages = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        var docImage1 = GameObject.Find("DocImage1");
        var docImage2 = GameObject.Find("DocImage2");
        var docImage3 = GameObject.Find("DocImage3");
        var docImage4 = GameObject.Find("DocImage4");
        
        _docImages.Add(docImage1);
        _docImages.Add(docImage2);
        _docImages.Add(docImage3);
        _docImages.Add(docImage4);
        
        RemoveDocImages();
        
        // Set Initial Doctor images
        _docImages[3].gameObject.SetActive(true);
    }
    
    public void RemoveDocImages()
    {
        foreach (var images in _docImages)
        {
            images.gameObject.SetActive(false);
        }
    }

    public List<GameObject> GetDocImages()
    {
        return _docImages;
    }
}
