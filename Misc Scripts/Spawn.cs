using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    private Transform SpawnT;
    private Transform CamSpawn;
    private GameObject playerOb;
    private GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        SpawnT = this.gameObject.transform;
        CamSpawn = this.gameObject.transform;
        playerOb = GameObject.FindGameObjectWithTag("Player");
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        playerOb.transform.position = SpawnT.position;
        camera.transform.position = CamSpawn.position;
        playerOb.transform.rotation = SpawnT.rotation;
        camera.transform.rotation = CamSpawn.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
