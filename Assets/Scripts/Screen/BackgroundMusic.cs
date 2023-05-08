using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip _backgroudMusic;
    private AudioSource _audioSource;

    void Start()
    {

        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _backgroudMusic;
        _audioSource.Play();
        
        if ( Parameters.isBackgroundMusicActive()) {
            AudioListener.volume = 1;
        } else {
            AudioListener.volume = 0;
        }
        
    }

}
