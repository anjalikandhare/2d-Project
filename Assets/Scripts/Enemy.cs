using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    Player player;
    public GameObject deathEffect;
    public float walkSpeed = 1.0f;
    public float wallLeft = 0.0f;
    public float wallRight = 5.0f;
    float walkingDirection = 1.0f;
    Vector2 walkAmount;
    float originalX;

    void Start() {
       // wallLeft = transform.position.x - 2.5f;
       // wallRight = transform.position.x + 2.5f;
    }
    
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            player = other.gameObject.GetComponent<Player>();
            player.Death();
        }
    }

    public void Death() {
        Instantiate(deathEffect, transform.position , transform.rotation);
        Destroy(gameObject);
    }

    private void FixedUpdate() {
        walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;

            if (walkingDirection > 0.0f && transform.position.x >= originalX + wallRight) {

                walkingDirection = -1.0f;
                Vector3 lTemp = transform.localScale;
                lTemp.x *= -1;
                transform.localScale = lTemp;

            } else if (walkingDirection < 0.0f && transform.position.x <= originalX - wallLeft) {

                walkingDirection = 1.0f;
                Vector3 lTemp = transform.localScale;
                lTemp.x *= -1;
                transform.localScale = lTemp;
            }
        transform.Translate(walkAmount);
    }
}
