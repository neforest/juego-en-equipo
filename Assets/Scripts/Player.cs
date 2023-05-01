using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField]private float _movementSpeed = 10.0f;
    [SerializeField]private float _jumpForce = 1000.0f;
    private Animator animator;
    private SpriteRenderer sprite;
    private Rigidbody2D rigid; 
    private bool isGrounded;

    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        jump();
    }

    void move() {

        float horizontalInput = Input.GetAxis("Horizontal") * _movementSpeed * Time.deltaTime;

        if (horizontalInput > 0 ) {
            sprite.flipX = false;
        } 
        if (horizontalInput < 0) {
            sprite.flipX = true;
        }

        animator.SetFloat("PlayerIsRunning", Mathf.Abs(horizontalInput));

        transform.position = transform.position + new Vector3(horizontalInput, 0 , 0);

        /*if(_moveHorizontal <= transform.position.x || transform.position.x <= (_moveHorizontal * -1)) 
        {
            transform.position = transform.position - new Vector3(horizontalInput, 0 , 0);
        } */

    }

    void jump() {
        if (Input.GetKeyDown("space") && isGrounded)
        {
           rigid.AddForce(Vector2.up * _jumpForce);
           isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
     {
        Debug.Log("entro a collision");
        Debug.Log("collision other: " + other.gameObject.name);
        Debug.Log("collision isgroundend: " + isGrounded);

         if (other.gameObject.name == "Collider" && isGrounded == false)
         {
             isGrounded = true;
         }
     }
}
