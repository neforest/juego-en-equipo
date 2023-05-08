using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthControl : MonoBehaviour
{
    public static PlayerHealthControl instance;

    public int currentHealth, maxHealth;

    [SerializeField]
    private Canvas _gameOver;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer(int damageAmount) {
        currentHealth -= damageAmount;
        LivesCounter.instance.SetNumLives(damageAmount);

        if ( currentHealth <= 0) {
            currentHealth = 0;
            GameSystemManager.instance.GameOver();
            gameObject.SetActive(false);
            Instantiate(_gameOver, transform.position, transform.rotation);
            TimePlaying.instance.isRunningTime = false;
        }
    }
}
