using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinArea : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        birdBehaviour.instance.points++;
        
        audioManager.instance.playSFX(0);
        if (birdBehaviour.instance.points >= birdBehaviour.instance.minPoints)
        {
            birdBehaviour.instance.pipeSpeed += 0.2f;

        }
        if (birdBehaviour.instance.points >= birdBehaviour.instance.minPoints2)
        {

            birdBehaviour.instance.waitTimerPipe -= 0.1f;
        }
    }
}

