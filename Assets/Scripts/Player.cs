using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed;
    Spawner spawner;
    public float crouchSpeed;
    public bool cinematics = false;
    public GameObject deathParticles;
    [System.NonSerialized]public bool dead;
    public bool enemyInRange;
    bool jumping;
    bool crouch;
    bool attacking;
    Enemy enemy;
    bool grounded;
    public float runSpeedBak;
    float hMove;
    Animator anim; 
    Rigidbody2D rb;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        dead = false;
        jumping = false;
        crouch = false;
        grounded = true;
        runSpeedBak = runSpeed;
    }

    
    void Update()
    {   

        if (!cinematics) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                jump();
                grounded = false;
            }

            if (Input.GetKeyDown(KeyCode.Z) && grounded == true) {
                attack();
            }

        
            if (Input.GetKey(KeyCode.C)) {

                crouch = true;
                runSpeed = crouchSpeed;
                anim.SetBool("Crouch", true);

            } else {

                if (Input.GetKeyUp(KeyCode.C)) {

                    crouch = false;
                    runSpeed = runSpeedBak;
                    anim.SetBool("Crouch", false);
                    

                }
            
            }

            hMove = Input.GetAxisRaw("Horizontal");

            if (hMove != 0) {
                anim.SetBool("IsRunning", true);
            } else {
                anim.SetBool("IsRunning", false);
            }
        }

        if (cinematics)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            anim.SetBool("IsRunning", false);
        }
        
    }

    void FixedUpdate() {
        
        controller.Move(hMove * runSpeed * Time.deltaTime, crouch, jumping);
        jumping = false;

    }

    public void Death() {

        Instantiate (deathParticles, transform.position, transform.rotation);
        Destroy (gameObject);
        dead = true;
        
    }

    public void OnLandEvent() {

        grounded = true;
       //anim.Play("Idle");
       //anim.SetBool("JumpB", false);

    }

    public void attackOver() {

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        attacking = false;

    }

    void attack() {
        if (grounded){

            anim.SetTrigger("Attack");
            attacking = true;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;

            if (enemyInRange) {
                enemy.Death();
            }
        }

        
    }
    void jump() {

        jumping = true;
        anim.SetTrigger("Jump");
        grounded = false;

    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Enemy")) {
            enemy = other.gameObject.GetComponent<Enemy>();
            enemyInRange = true;
        }

        if (other.CompareTag("Spawner")) {
            spawner = other.gameObject.GetComponent<Spawner>();
            spawner.Spawn();
        }

    }
    void OnTriggerExit2D(Collider2D other) {

        if (other.CompareTag("Enemy")) {
            enemy = other.gameObject.GetComponent<Enemy>();
            enemyInRange = false;

        }
    }
}
