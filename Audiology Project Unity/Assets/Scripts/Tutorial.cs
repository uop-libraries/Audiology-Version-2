using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial: MonoBehaviour
{
    
    public GameObject settingsPanel;

     
    public Slider volumeSlider;

    
    public Dropdown narratorDropdown;

    
    public AudioSource narratorAudioSource;

    
    public List<AudioClip> narratorAudioClips;

    void Start()
    {
      
        volumeSlider.value = AudioListener.volume;

      
        narratorDropdown.options.Clear();
        foreach (AudioClip clip in narratorAudioClips)
        {
            narratorDropdown.options.Add(new Dropdown.OptionData(clip.name));
        }
    }

 
    public void OnVolumeSliderValueChanged()
    {
        
        AudioListener.volume = volumeSlider.value;
    }

   
}