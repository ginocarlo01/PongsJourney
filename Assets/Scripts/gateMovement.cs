using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gateMovement : MonoBehaviour
{
    public Transform objective;

    public bool movement;

    public float speed;

    private bool played = false, stopped = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetString(SceneManager.GetActiveScene().name + "_cp") == "") 
        { 
            if (movement)
            {
                if (!played)
                {
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
                        audioManager.instance.StartBGM();
                        Behaviour.instance.canMove = true;
                    }
                }
            }
        }
        else{
            if (!played)
            {
                Behaviour.instance.canMove = true;
                audioManager.instance.StartBGM();
                played = true;
            }
            
        }
}
}
