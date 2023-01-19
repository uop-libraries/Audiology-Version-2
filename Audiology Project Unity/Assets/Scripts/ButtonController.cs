using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Slider = UnityEngine.UI.Slider;

public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    private const float TotalTime = 1f;
    bool gazedStatus;
    
    public GameObject button;
    public Slider cursorTimer;
    public bool enableButtonSound = true;
    public bool isInteractable = true;
    public float gazedTimer;
    public AudioSource soundSource;
    public AudioClip clickClip;
    
    public UnityEvent GVRClick;


    void Start()
    {
        cursorTimer.value = 0;
        gazedStatus = false;
    }
    
    void Update()
    {
        if (isInteractable == false)
        {
            return;
        }
        
        if (gazedStatus)
        {
            button.GetComponent<Animator>().StopPlayback();
            gazedTimer += Time.deltaTime;
            cursorTimer.value = gazedTimer / TotalTime;
            StartCoroutine(PlayHoverOn());
        }
        
        if (gazedTimer > TotalTime)
        {
            if (enableButtonSound == true && soundSource != null)
            {
                soundSource.PlayOneShot(clickClip);
            }
            GVRClick.Invoke();
        }
    }
    
    public void OnPointerOn()
    {
        gazedStatus = true;
    }

    public void OnPointerOff()
    {
        gazedStatus = false;
        gazedTimer = 0;
        cursorTimer.value = 0;
        button.GetComponent<Animator>().Play("HoverOffAnimation");
    }

    IEnumerator PlayHoverOn()
    {
        button.GetComponent<Animator>().Play("HoverOnAnimation");
        yield return null;
    }


}
