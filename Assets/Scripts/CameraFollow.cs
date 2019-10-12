using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Player Player;
    public float FollowSpeed = 2f;
    public Transform Target;

    private void Update()
    {
        if(Player.dead != true) {
            Vector3 newPosition = Target.position;
            newPosition.z = -10;
            transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * Time.deltaTime);
        }
    }
}
