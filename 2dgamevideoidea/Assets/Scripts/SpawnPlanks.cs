using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlanks : MonoBehaviour
{

    public GameObject plank;
    public Transform spawnPoint;
    float cooldown = 3.0f;
    float lastSpawn = -100.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float timeSinceLastSpawn = Time.time - lastSpawn;

        if(Input.touchCount > 0 && timeSinceLastSpawn > cooldown)
        {
            Instantiate(plank, spawnPoint.position, transform.rotation);
            lastSpawn = Time.time;
        }
    }
}
