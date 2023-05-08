using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimePlaying : MonoBehaviour
{

    public TMP_Text _timePlaying;
    private float _countTime = 0.0f;
    [SerializeField]private float _delayToCaptureTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
        _timePlaying.text = "Tiempo Jugando: " + Parameters.GetOffsetTime();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(updateTimePlaying());

        _timePlaying.text = "Tiempo Jugando: " + Mathf.Round(_countTime);
    }

    IEnumerator updateTimePlaying() {
        yield return new WaitForSeconds(_delayToCaptureTime);
        _countTime = Time.time;
    }

    void RebootTime() {
        _countTime = 0.0f;
    }
}
