using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
        if ( Parameters.isBackgroundMusicActive()) {
            AudioListener.volume = 1;
        } else {
            AudioListener.volume = 0;
        }
        
    }

}
