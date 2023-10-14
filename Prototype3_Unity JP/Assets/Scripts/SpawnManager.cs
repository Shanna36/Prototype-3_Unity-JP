using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3 (25,0,0); 

    private float startDelay = 2;
     
    //private float repeatRate = 2;

    private PlayerController playerControllerScript;

    private float spawnInterval; //added this to make it more random and fun


    // Start is called before the first frame update
    void Start()
    {
        spawnInterval = UnityEngine.Random.Range(01.0f,3.0f);
        InvokeRepeating ("SpawnObstacle", startDelay, spawnInterval);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle(){
        
        if (playerControllerScript.isGameOver == false){
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
