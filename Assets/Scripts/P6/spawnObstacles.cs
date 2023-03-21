using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObstacles : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>();

    public List<Transform> positions = new List<Transform>();

    public float iniPipeSpeed, randomSpeedPipe, spawnPipeTimer, downSpawnSpeed, upPipeSpeed, minimumSpawnSpeed, downPipeSpeed;

    private float timer;

    public bool colored;

    public static spawnObstacles instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }

    void Update()
    {
        if (timer > spawnPipeTimer)
        {
            spawnObject();
            timer = 0;
        }

        timer += Time.deltaTime;

        

        iniPipeSpeed += Time.deltaTime / upPipeSpeed;

        if (spawnPipeTimer >= minimumSpawnSpeed)
        {
            spawnPipeTimer -= Time.deltaTime / downSpawnSpeed;
        }
    }

    private void spawnObject()
    {
        int randomObj;

        randomObj = Random.Range(0, objects.Count);

        int randomPos;

        randomPos = Random.Range(0, positions.Count);

        GameObject newObs = Instantiate(objects[randomObj]);
        newObs.transform.position = positions[randomPos].position;
        if (newObs.GetComponent<coloredObstacle>() != null)
        {
            newObs.GetComponent<coloredObstacle>().vel = iniPipeSpeed; //Random.Range(-randomSpeedPipe, randomSpeedPipe) +
        }
        else
        {
            newObs.GetComponent<obstacle>().vel = iniPipeSpeed; //Random.Range(-randomSpeedPipe, randomSpeedPipe) +
        }
        
        Destroy(newObs, 25f);
    }
}
