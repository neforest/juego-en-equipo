using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystemManager : MonoBehaviour
{
    public static GameSystemManager instance;
    [SerializeField]private float _delayToNextEscene = 0.5f;
    [SerializeField]private float _delayOfGameOver = 5.0f;

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
        yield return new WaitForSeconds(_delayToNextEscene);
        SceneManager.LoadScene(nameScene);
    }

    IEnumerator GameOverCoroutine() {
        yield return new WaitForSeconds(_delayOfGameOver);
        Parameters.SetOffsetTime(0.0f);
        SceneManager.LoadScene("Creditos");
    }

}
