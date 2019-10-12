using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour {
    public Player player;

    void OnCollisionEnter2D(Collision2D col) {

        if (col.gameObject.tag == "Player") {
            player.Death();
        }
    }
}
