using System;
using System.Collections;
using System.Threading.Tasks;
using Michsky.MUIP;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Slider = UnityEngine.UI.Slider;

public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float gazeTime = .8f;
    [SerializeField] public float delayTime = .8f;
    
    // Set this variable to true for desktop version
    // bool _isDesktopVersion = true;
    bool _gazedStatus;
    
    
    // public Slider cursorTimer;

    private Image _image;
    private UIGradient _uiGradient;
    private Animator _animatorButton;
    private Button _newButton;
    
    public bool enableButtonSound = true;
    // public bool isInteractable = true;
    private bool _isClick;
    
    private GameObject _continueButton;
    
    private float _gazedTimer;
    private float _delayTimer;
    
    // Used to resync main menu button animations
    private GameObject _syncAnimationObject;
    private Animator _syncAnimationAnimator;
    private Image _syncAnimationImage;
    
    public AudioSource soundSource;
    public AudioClip clickClip;
    
    // public UnityEvent GVRClick;

    void Start()
    {
        _continueButton = GameObject.Find("ContinueButton");
        _syncAnimationObject = GameObject.Find("Sync_Animation_Dummy");
        if (_syncAnimationObject != null)
        {
            _syncAnimationAnimator = _syncAnimationObject.GetComponent<Animator>();
            _syncAnimationImage = _syncAnimationObject.GetComponent<Image>();
        }
        // cursorTimer.value = 0;
        _gazedStatus = false;
        _animatorButton = GetComponent<Animator>();
        _image = GetComponent<Image>();
        _uiGradient = GetComponent<UIGradient>();
        _newButton = GetComponent<Button>();
    }
    
    void Update()
    {
        if (_newButton != null)
        {
            if (_newButton.interactable == false)
            {
                return;
            }
        }
        
        
        // Hovering 
        if (_gazedStatus && _newButton.interactable)
        {  
            _animatorButton.StopPlayback();
            if (StateNameController.IsDesktopVersion) {
                _delayTimer += Time.deltaTime;
                // Debug.Log("Is Desktop Version" + StateNameController.IsDesktopVersion );
            }
            
            // cursorTimer.value = gazedTimer / TotalTime;
            Hovering();
        }
        
        // If isDesktop Version do not proceed to next step
        if (StateNameController.IsDesktopVersion)
            return;
        
        if (_delayTimer > delayTime)
        {
            _gazedTimer += Time.deltaTime;
        }
        
        // Selecting 
        if (_gazedTimer > gazeTime)
        {
            // if (enableButtonSound == true && soundSource != null)
            // {
            //     soundSource.PlayOneShot(clickClip);
            // }
            // _gazedTimer = 0;
            // _delayTimer = 0;
            // // cursorTimer.value = 0;
            // _isClick = true;
            // StateNameController.IsClick = true;
            // // GVRClick.Invoke();
            // _gazedStatus = false;
            OnButtonClick();
        }
        
        // Already selected and is not continuous button
        // if (_isClick && !_continueButton)
        // {
        //     // _newButton.interactable = false;
        //     ChangeColor();
        // }
    }

    public void OnButtonClick() {
        Debug.Log("Button is Click");
        if (enableButtonSound == true && soundSource != null)
        {
            soundSource.PlayOneShot(clickClip);
        }
        StateNameController.IsClick = true;
        if (!_continueButton && !CompareTag("MenuButton") && !CompareTag("MainMenuButton"))
        {
            ChangeColor();
        }
        _isClick = true;
        _gazedTimer = 0;
        _delayTimer = 0;
        _gazedStatus = false;
        // Debug.Log("button is being press");
    }
    
    public void ChangeColor()
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
        _gazedTimer = 0;
        _delayTimer = 0;
        // cursorTimer.value = 0;
        
        // Allows main menu buttons to retain their flashing animation while
        // other buttons (choices, control buttons, etc...) remain as normal
        if (CompareTag("MainMenuButton"))
        {
            StartCoroutine("PlayHoverOff");    
        }
        else
        {
            _animatorButton.Play("HoverOffAnimation");
        }
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

    IEnumerator PlayHoverOff()
    {
        // Finishes the hovering animation and then waits until the button animations are synced to start flashing again
        // Has a fade effect into the flashing animation to smooth it out in case of any sudden changes
        _animatorButton.Play("HoverOffAnimation");
        AnimatorClipInfo[] animInfo = _animatorButton.GetCurrentAnimatorClipInfo(0);
        float clipLength = animInfo[0].clip.length;
        yield return new WaitForSeconds(clipLength);
        yield return new WaitUntil(() => (_syncAnimationImage.color.a >= 0.95f));
        _animatorButton.CrossFade("StartAnimation", 0.2f, 0, _syncAnimationAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime); 
    }
}
