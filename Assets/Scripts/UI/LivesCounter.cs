using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesCounter : MonoBehaviour
{
    public static LivesCounter instance;

    [SerializeField]
    private float _liveImageWidth = 300f;
    [SerializeField]
    private float _maxNumOfLives, _numOfLives;

    private RectTransform _rect;

    private void Awake() {
        instance = this;
        _rect = transform as RectTransform;
    }

    // Start is called before the first frame update
    void Start()
    {
        _maxNumOfLives = PlayerHealthControl.instance.maxHealth;
        _numOfLives = _maxNumOfLives;
    }

    public void SetNumLives(int damage) {
        _numOfLives -= damage;
        _rect.sizeDelta = new Vector2(x:_liveImageWidth * _numOfLives, _rect.sizeDelta.y);
    }
}
