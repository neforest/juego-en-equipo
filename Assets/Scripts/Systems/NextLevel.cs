using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public string nameScene;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            GameSystemManager.instance.ChangeScene(nameScene);
        }
    }

}
