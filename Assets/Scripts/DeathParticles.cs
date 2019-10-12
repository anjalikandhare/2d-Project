using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathParticles : MonoBehaviour
{
    public void Destroy() {
        Destroy(gameObject);
    }
}
