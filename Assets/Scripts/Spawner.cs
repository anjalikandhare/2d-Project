using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Object;
    bool spawni = false;
    public Transform spawnLocation;
    public bool cine = false;
    public void Spawn() {
        if (!spawni) {

            Instantiate(Object , spawnLocation.transform.position, spawnLocation.rotation);
            cine = true;
            spawni = true;
            
        }
    }
}
