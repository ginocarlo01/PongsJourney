using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPipes : MonoBehaviour
{
    public GameObject pipe;
    public float height;
    public float timer;

    public bool canSpawn;

    void Start()
    {
        //canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        canSpawn = gameManager.instance.start;
        if (canSpawn)
        {
            if (timer > birdBehaviour.instance.maxTimePipe)
            {
                spawnPipe();
                timer = 0;
            }

            timer += Time.deltaTime;
        }
        
    }

    void spawnPipe()
    {
        GameObject newPipe = Instantiate(pipe);
        newPipe.transform.position = transform.position + new Vector3(20, Random.Range(-height, height), 0);
        Destroy(newPipe, 25f);
    }
}
