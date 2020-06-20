using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour{

    public static PlayerController sharedInstance;

    public float jumpForce = 5f;

    public Animator animator;

    public float runningSpeed = 1.5f;

    private Rigidbody2D rigidbody;

    private Vector3 startPosition;

    public LayerMask groundLayer;

    void Awake(){
        sharedInstance = this;
        rigidbody = GetComponent<Rigidbody2D>();
        startPosition = this.transform.position;
    }

    // Start is called before the first frame update
    public void StartGame(){
        animator.SetBool("isAlive", true);
        animator.SetBool("isGrounded", true);
        this.transform.position = startPosition;
    }

    // Update is called once per frame
    void Update(){
        if (GameManager.sharedInstance.currentGameState == GameState.inGame){
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                //Aquí, el usuario acaba de bajar la tecla espacio
                Jump();
            }
        }

        animator.SetBool("isGrounded", IsTouchingTheGround());
    }

    void FixedUpdate() {
        if (GameManager.sharedInstance.currentGameState == GameState.inGame){
            if (rigidbody.velocity.x < runningSpeed){
                rigidbody.velocity = new Vector2(runningSpeed, rigidbody.velocity.y);
            }
        }
    }

    void Jump(){
        //f = m * a ========> a = F/m
        if (IsTouchingTheGround()){
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    bool IsTouchingTheGround(){
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 0.2f, groundLayer)){
            return true;
        }else{
            return false;
        }
        
    }

    public void Kill(){
        GameManager.sharedInstance.GameOver();
        this.animator.SetBool("isAlive", false);
    }
}
