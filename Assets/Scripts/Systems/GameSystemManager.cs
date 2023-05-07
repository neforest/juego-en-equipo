using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystemManager : MonoBehaviour
{
    public static GameSystemManager instance;

    private void Awake() {
        instance = this;
    }

    public void ChangeScene(string nameScene) {
        StartCoroutine(ChangeSceneCoroutine(nameScene));
    }

    public void GameOver() {
        StartCoroutine(GameOverCoroutine());
    }

    IEnumerator ChangeSceneCoroutine(string nameScene) {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(nameScene);
    }

    IEnumerator GameOverCoroutine() {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Creditos");
    }

}
