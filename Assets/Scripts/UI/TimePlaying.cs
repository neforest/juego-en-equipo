using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimePlaying : MonoBehaviour
{

    public static TimePlaying instance;

    public TMP_Text _timePlaying;
    private float _countTime = 0.0f;
    [SerializeField]private float _delayToCaptureTime = 1.0f;
    public bool isRunningTime;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _countTime = Parameters.GetOffsetTime();
        _timePlaying.text = "Tiempo Jugando: " + Parameters.GetOffsetTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunningTime) {
            StartCoroutine(updateTimePlaying());
        }

        _timePlaying.text = "Tiempo Jugando: " + Mathf.Round(_countTime);
    }

    IEnumerator updateTimePlaying() {
        yield return new WaitForSeconds(_delayToCaptureTime);
        _countTime = Parameters.GetOffsetTime() + Time.deltaTime;
        Parameters.SetOffsetTime(_countTime);
    }

    void RebootTime() {
        _countTime = 0.0f;
    }

}
