using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCrabController : MonoBehaviour
{
    public Transform[] patrolPoints;
    private int currentPoint;

    public float mSpeed, waitTime;
    private float waitCounter;

    public Rigidbody2D enemyRB;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        waitCounter = waitTime;
        enemyRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        foreach(Transform pPoint in patrolPoints) {
            pPoint.SetParent(null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x - patrolPoints[currentPoint].position.x) > .2f) {
            if (transform.position.x < patrolPoints[currentPoint].position.x) {
                enemyRB.velocity = new Vector2(mSpeed, enemyRB.velocity.y);
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else {
                enemyRB.velocity = new Vector2(-mSpeed, enemyRB.velocity.y);
                transform.localScale = Vector3.one;
            }
        }
        else {
            enemyRB.velocity = new Vector2(0f, enemyRB.velocity.y);

            waitCounter -= Time.deltaTime;
            if (waitCounter <= 0) {
                waitCounter = waitTime;

                currentPoint++;

                if (currentPoint >= patrolPoints.Length) {
                    currentPoint = 0;
                }
            }
        }

        anim.SetBool("isMoving", enemyRB.velocity.x != 0);
    }
}
