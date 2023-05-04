using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField]private float _movementSpeed = 10.0f;
    [SerializeField]private float _jumpForce = 12.0f;
    private Animator animator;
    private SpriteRenderer sprite;
    private Rigidbody2D rigid; 
    private bool isGrounded;
    private bool _isJumpOnWall;
    private float horizontalInput;

    [SerializeField]private float _timer = 0.3f;
    private float _initialTime = 0;
    private bool _waitMove = false;

    [SerializeField]private float _impulseHorizontalInWall = 6.0f;
    [SerializeField]private float _impulseVerticalInWall = 12.0f;

    private bool _faceToRight = false;
    private bool _faceToLeft = false;
    private bool _jumpOnTheRightWall = false;
    private bool _jumpOnTheLeftWall = false;

    private bool _enableJumpOnWall = false;

    private PlayerAbilityControl _abilityControl;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        isGrounded = true;

        _abilityControl = GetComponent<PlayerAbilityControl>();
    }

    // Update is called once per frame
    void Update()
    {

        //esperar el valor de _timer para poder moverse luego de un salto en la pared, 
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

        playerDirection();

        animator.SetFloat("PlayerIsRunning", Mathf.Abs(horizontalInput));

        transform.position = transform.position + new Vector3(horizontalInput, 0 , 0);

    }

    void playerDirection() {

        Vector3 currentScale = transform.localScale;
        if (horizontalInput > 0 ) {
            currentScale.x = Mathf.Abs(currentScale.x);
            _faceToRight = true;
            _faceToLeft = false;
            Debug.Log("_faceToRight derecha: " + _faceToRight);
        } 
        if (horizontalInput < 0) {
            currentScale.x = Mathf.Abs(currentScale.x) * -1;
            _faceToRight = false;
            _faceToLeft = true;
            Debug.Log("_faceToRight izquierda: " + _faceToRight);
        }
        transform.localScale = currentScale;
    }

    void jump() {

        if (Input.GetKeyDown("space") && isGrounded)
        {
            rigid.velocity = new Vector2(0, _jumpForce);

            isGrounded = false;
        }

        
        if (Input.GetKeyDown("space") && _isJumpOnWall && _enableJumpOnWall) {
            JumpOnWall();
        }

    }

    void JumpOnWall() {
        //si es salto en pared entonces hay un impulso hacia arriba 
        //y hacia el lado opuesto a la direccion del jugador

        //si salto hacia la izquierda, el impulso es hacia la derecha
        if (horizontalInput < 0) {
            rigid.velocity = new Vector2(_impulseHorizontalInWall, _impulseVerticalInWall);
            _jumpOnTheRightWall = false;
            _jumpOnTheLeftWall = true;
            Debug.Log("_jumpOnTheRightWall izquierda: " + _jumpOnTheRightWall);
        }

        //si salto hacia la derecha, el impulso es hacia la izquierda
        if (horizontalInput > 0) {
            rigid.velocity = new Vector2(-1 * _impulseHorizontalInWall, _impulseVerticalInWall);
            _jumpOnTheRightWall = true;
            _jumpOnTheLeftWall = false;
            Debug.Log("_jumpOnTheRightWall derecha: " + _jumpOnTheRightWall);
        }
        _isJumpOnWall = false;
        isGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D other)
     {
        Debug.Log("entro a collision");
        Debug.Log("collision other: " + other.gameObject.name);
        Debug.Log("collision isgroundend: " + isGrounded);

         if (other.gameObject.name == "Collider" && isGrounded == false)
         {
            isGrounded = true;
            _isJumpOnWall = false;

            _faceToRight = false;
            _faceToLeft = false;
            _jumpOnTheRightWall = false;
            _jumpOnTheLeftWall = false;
         }

         if (other.gameObject.name == "Wall")
         { 
            if ((_faceToRight != _jumpOnTheRightWall || _faceToLeft != _jumpOnTheLeftWall) && isGrounded == false) {
                _isJumpOnWall = true;
                _waitMove = true;
            } else {
                _isJumpOnWall = false;
                _waitMove = false;
            }
         }

         if (_abilityControl.canWallJump) { 
         //if (other.gameObject.name == "PowerUpJumpOnWall") {

            _enableJumpOnWall = true;

            //Destroy(other.gameObject);

         }
     }
}
