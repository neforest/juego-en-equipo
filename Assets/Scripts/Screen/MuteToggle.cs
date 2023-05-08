using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteToggle : MonoBehaviour
{
    
    private Toggle myToggle;

    void Start()
    {
        myToggle = GetComponent<Toggle>();
        if(AudioListener.volume == 0) {
            myToggle.isOn = false;
        }
    }

    public void ToggleAudioOnValueChange(bool audioIn) {
        if (audioIn){
            AudioListener.volume = 1;
            Parameters.ActivateBackgroundMusic();
        } else {
            AudioListener.volume = 0;
            Parameters.DeactivateBackgroundMusic();
        }
    }

    void Update()
    {
        
    }
}
