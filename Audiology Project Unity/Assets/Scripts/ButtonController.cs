using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Slider = UnityEngine.UI.Slider;

public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject button;
    public Slider cursorTimer;
    [FormerlySerializedAs("GVRclick")] public UnityEvent GVRClick;
    private const float TotalTime = 1f;
    bool gazedStatus;
    public float gazedTimer;
    public AudioSource source;
    public AudioClip clickClip;


    void Start()
    {
        cursorTimer.value = 0;
        gazedStatus = false;
    }
    
    void Update()
    {
        if (gazedStatus)
        {
            button.GetComponent<Animator>().StopPlayback();
            gazedTimer += Time.deltaTime;
            cursorTimer.value = gazedTimer / TotalTime;
            StartCoroutine(PlayHoverOn());
        }
        
        if (gazedTimer > TotalTime)
        {
            source.PlayOneShot(clickClip);
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
