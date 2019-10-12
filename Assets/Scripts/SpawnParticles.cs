using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticles : MonoBehaviour
{
    public GameObject InstantiateObject;

    public void Spawn() {
        Instantiate(InstantiateObject, this.transform);
        
    }
}
