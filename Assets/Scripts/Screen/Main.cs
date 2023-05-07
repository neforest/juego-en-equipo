using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{

    [SerializeField]private float _timerNextScene = 0.0f;

    public void CallLoadPlayScene()
    {
        Invoke("PlayScene",_timerNextScene);
    }

    private void PlayScene()
    {
        
        SceneManager.LoadScene("Level1");
        
    }

    public void CallLoadCreditScene()
    {
        Invoke("CreditScene",_timerNextScene);
    }

    private void CreditScene()
    {
        
        SceneManager.LoadScene("Creditos");
        
    }
}
