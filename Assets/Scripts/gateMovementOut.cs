using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gateMovementOut : MonoBehaviour
{
    public Transform objective;

    public bool movement;

    public float speed;

    public bool played = false, stopped = false;

    void Start()
    {
        Behaviour.instance.canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (movement)
        {
            if (!played)
            {
                audioManager.instance.StopBGM();
                audioManager.instance.playSFX(3);
                played = true;
            }
            
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, objective.position.y, transform.position.z), speed * Time.deltaTime);

            if (transform.position.y == objective.position.y)
            {
                movement = false;

                if (!stopped)
                {
                    audioManager.instance.stopSFX(3);
                    stopped = true;
                    
                    Behaviour.instance.canMove = true;
                }
            }
        }

    }
}
