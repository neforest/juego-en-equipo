using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField]private float _movementSpeed = 10.0f;
    [SerializeField]private float _jumpForce = 20.0f;
    private Animator animator;
    private SpriteRenderer sprite;
    private Rigidbody2D rigid; 
    private bool isGrounded;
    private bool jumpInWall;
    private float horizontalInput;

    [SerializeField]private float _timer = 0.5f;
    private float _initialTime = 0;
    private bool _waitMove = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {

        //esperar el valor de _timer para poder moverse, 
        //esto para que el salto del personaje sobre la pared sea mas limpio.
        if (!_waitMove) {
            move();
        } else {
            wait();
        }
        
        jump();
    }

    void wait() {
        _initialTime = _initialTime + Time.deltaTime;

        if (_initialTime > _timer){
            
            _waitMove = false;

            _initialTime = 0.0f;

        } else {
            _waitMove = true;
        }

    }

    void move() {

        horizontalInput = Input.GetAxis("Horizontal") * _movementSpeed * Time.deltaTime;

        Vector3 currentScale = transform.localScale;

        if (horizontalInput > 0 ) {

            currentScale.x = Mathf.Abs(currentScale.x);
            transform.localScale = currentScale;

            //sprite.flipX = false;
        } 
        if (horizontalInput < 0) {

            currentScale.x = Mathf.Abs(currentScale.x) * -1;
            transform.localScale = currentScale;
            //sprite.flipX = true;
        }

        animator.SetFloat("PlayerIsRunning", Mathf.Abs(horizontalInput));

        transform.position = transform.position + new Vector3(horizontalInput, 0 , 0);

        /*if(_moveHorizontal <= transform.position.x || transform.position.x <= (_moveHorizontal * -1)) 
        {
            transform.position = transform.position - new Vector3(horizontalInput, 0 , 0);
        } */

    }

    void jump() {

        if (Input.GetKeyDown("space") && (isGrounded || jumpInWall))
        {
            rigid.AddForce(new Vector2(0, 1) * _jumpForce , ForceMode2D.Impulse);
            Debug.Log("jumpInWall: " + jumpInWall);
            if (jumpInWall) {
                
                if (horizontalInput < 0) {
                    rigid.AddForce(new Vector2(1, 1) * _jumpForce / 2 , ForceMode2D.Impulse);
                }

                if (horizontalInput > 0) {
                    rigid.AddForce(new Vector2(-1, 1) * _jumpForce / 2 , ForceMode2D.Impulse);
                }
                jumpInWall = false;
            }

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
             jumpInWall = false;
         }

         if (other.gameObject.name == "Wall")
         {
             jumpInWall = true;
             _waitMove = true;
         }
     }
}
