using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    [SerializeField]
    private Canvas _winGame;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            Instantiate(_winGame, transform.position, transform.rotation);
            GameSystemManager.instance.GameOver();
        }
    }
}
