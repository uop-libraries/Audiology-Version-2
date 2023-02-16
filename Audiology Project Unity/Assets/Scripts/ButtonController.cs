using System;
using System.Collections;
using System.Threading.Tasks;
using Michsky.MUIP;
using TMPro;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Slider = UnityEngine.UI.Slider;

public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float TotalTime = 2f;
    bool _gazedStatus;
    
    
    public Slider cursorTimer;

    private Image _image;
    private UIGradient _uiGradient;
    private Animator _animatorButton;
    private Button _newButton;
    
    public bool enableButtonSound = true;
    // public bool isInteractable = true;
    private bool _isClick;
    
    private GameObject _continueButton;
    
    public float gazedTimer;
    
    public AudioSource soundSource;
    public AudioClip clickClip;
    
    public UnityEvent GVRClick;

    private GameObject _case1CounselingButton;
    private GameObject _case2CounselingButton;


    void Start()
    {
        _continueButton = GameObject.Find("ContinueButton");
        cursorTimer.value = 0;
        _gazedStatus = false;
        _animatorButton = GetComponent<Animator>();
        _image = GetComponent<Image>();
        _uiGradient = GetComponent<UIGradient>();
        _newButton = GetComponent<Button>();
        _case1CounselingButton = GameObject.Find("Case_1_Counseling_Button");
        _case2CounselingButton = GameObject.Find("Case_2_Counseling_Button");

        // SetCounselingButton();
        // Debug.Log("gameObject: " + gameObject);
        
    }
    
    void Update()
    {
        SetCounselingButton();
        
        if (_newButton.interactable == false)
        {
            return;
        }

        //Todo 
        // if (_gazedStatus)
        // Hovering 
        if (_gazedStatus && _newButton.interactable)
        {
            _animatorButton.StopPlayback();
            gazedTimer += Time.deltaTime;
            cursorTimer.value = gazedTimer / TotalTime;
            Hovering();
        }
        
        // Selecting 
        if (gazedTimer > TotalTime)
        {
            if (enableButtonSound == true && soundSource != null)
            {
                soundSource.PlayOneShot(clickClip);
            }
            gazedTimer = 0;
            cursorTimer.value = 0;
            _isClick = true;
            StateNameController.isClick = true;
            GVRClick.Invoke();
            _gazedStatus = false;
        }
        
        // Already selected and is not continuous button
        if (_isClick && !_continueButton)
        {
            // _newButton.interactable = false;
            ChangeColor();
        }
    }

    private void SetCounselingButton()
    {
        if (_case1CounselingButton == null && _case2CounselingButton == null ||
            _case1CounselingButton.name != name && _case2CounselingButton.name != name)
        {
            return;
        }
        
        if (!StateNameController.isCase1HistoryDone)
        {
            SetButton(_case1CounselingButton, false);
            _case1CounselingButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Case 1 Counseling (Lock)";
        }
        else if (StateNameController.isCase1HistoryDone)
        {
            SetButton(_case1CounselingButton, true);
            _case1CounselingButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Case 1 Counseling";
        }
        
        if (!StateNameController.isCase2HistoryDone)
        {
            SetButton(_case2CounselingButton, false);
            _case2CounselingButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Case 2 Counseling (Lock)";
        }
        else if (StateNameController.isCase2HistoryDone)
        {
            SetButton(_case2CounselingButton, true);
            _case2CounselingButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Case 2 Counseling";
        }
    }

    private void SetButton(GameObject buttonObject, bool isEnable)
    {
        buttonObject.GetComponent<Button>().interactable = isEnable;
        buttonObject.GetComponent<Animator>().enabled = isEnable;
    }
    
    private void ChangeColor()
    {
        _image.color = Color.grey;
        if (_uiGradient != null)
        {
            _uiGradient.enabled = false;
        }
    }
    
    public void OnPointerOn()
    {
        _gazedStatus = true;
    }

    public void OnPointerOff()
    {
        _gazedStatus = false;
        gazedTimer = 0;
        cursorTimer.value = 0;
        _animatorButton.Play("HoverOffAnimation");
    }
    
    private void Hovering()
    {
        StartCoroutine(PlayHoverOn());
    }
    
    IEnumerator PlayHoverOn()
    {
        _animatorButton.Play("HoverOnAnimation");
        yield return null;
    }
}
