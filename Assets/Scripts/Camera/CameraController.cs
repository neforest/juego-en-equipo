using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Player _player;
    [SerializeField]private float _verticalOffset = 0.0f;
    [SerializeField]private float _horizontalOffset = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_player != null) {
            transform.position = new Vector3(_player.transform.position.x + _verticalOffset, 
            _player.transform.position.y + _horizontalOffset, transform.position.z);
        }
    }
}
